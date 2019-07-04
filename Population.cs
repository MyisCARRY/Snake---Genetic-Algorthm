using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGA
{
    class Population
    {
        int size;
        Snake[] snakes;
        public int generation;
        public int current_score;
        int[,] parents;
        Boolean play;
        int top;

        public Population()
        {
            play = false;
            size = Settings.PopulationSize;
            top = (int)(size * Settings.TopPopulation);
            snakes = new Snake[size];
            parents = new int[size - top, 2];

            for (int i = 0; i < size; i++)
                snakes[i] = new Snake();
        }

        void Selection()
        {
            Array.Sort(snakes, delegate (Snake x, Snake y) { return -x.fitness.CompareTo(y.fitness); });

            double total_fitness = 0;

            for (int i = 0; i < top; i++)
                total_fitness += snakes[i].fitness;

            double p1, p2, temp;
            bool b1 = false;
            bool b2 = false;

            for (int i = 0; i < (size - top); i++)
            {
                do
                {
                    temp = 0;
                    p1 = Settings.Rand.NextDouble() * total_fitness;
                    p2 = Settings.Rand.NextDouble() * total_fitness;
                    b1 = false;
                    b2 = false;

                    for (int j = 0; j < top; j++)
                    {
                        temp += snakes[j].fitness;

                        if (p1 <= temp && !b1)
                        {
                            parents[i, 0] = j;
                            b1 = true;
                        }

                        if (p2 <= temp && !b2)
                        {
                            parents[i, 1] = j;
                            b2 = true;
                        }
                    }
                } while (parents[i, 0] == parents[i, 1]);
            }
        }

        void Breeding()
        {
                string query = "INSERT INTO snakes (IdPopulation, Generation, Score) VALUES ";

            for (int i = 0; i < size; i++)
            {
                if (i == size - 1)
                    query += "(" + Settings.Id.ToString() + "," + generation.ToString() + "," + snakes[i].score.ToString() + ");";
                else
                    query += "(" + Settings.Id.ToString() + "," + generation.ToString() + "," + snakes[i].score.ToString() + "), ";
            }

            DBHelper.ExecuteQuery(query);
            //DBConnection.UpdateInsert(query);

            Snake[] offspring = new Snake[size];
            Selection();

            for (int i = 0; i < top; i++)
                offspring[i] = new Snake(snakes[i]);

            for (int i = top; i < size; i++)
            {
                offspring[i] = new Snake();

                int p1 = parents[i - top, 0];
                int p2 = parents[i - top, 1];

                offspring[i].d.Crossover(snakes[p1].d, snakes[p2].d);
                offspring[i].d.Mutation();
            }

            for (int i = 0; i < size; i++)
                snakes[i] = new Snake(offspring[i]);

            generation++;
        }

        public List<Rectangle> Execute()
        {
            List<Rectangle> result = new List<Rectangle>();

            if (!play)
            {
                for (int i = 0; i < size; i++)
                {
                    while (snakes[i].living())
                        snakes[i].update();

                    if (snakes[i].score > Settings.WorldBestscore)
                        Settings.WorldBestscore = snakes[i].score;

                    if (snakes[i].score > Settings.GenerationBestscore)
                    {
                        Settings.GenerationBestscore = snakes[i].score;
                        Settings.GenerationBestSnake = i;
                    }
                }

                snakes[Settings.GenerationBestSnake].restart();
                play = true;
            }
            else
            {
                snakes[Settings.GenerationBestSnake].update();
                result = snakes[Settings.GenerationBestSnake].Show();
                current_score = snakes[Settings.GenerationBestSnake].score;

                if (!snakes[Settings.GenerationBestSnake].living())
                {

                    string query = "UPDATE population SET BestScore=" + Settings.WorldBestscore + " WHERE Id=" + Settings.Id;
                    DBHelper.ExecuteQuery(query);

                    Settings.GenerationBestscore = 0;
                    Settings.GenerationBestSnake = 0;
                    play = false;
                    Breeding();
                }
            }

            return result;
        }
    }
}

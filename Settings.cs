using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGA
{
    class Settings
    {
        public static int HiddenLayers { get; set; }
        public static int HiddenNodes { get; set; }
        public static int InputNodes { get; set; }
        public static int OutputNodes { get; set; }
        public static double MutationRate { get; set; }
        public static int Size { get; set; }
        public static double Height { get; set; }
        public static double Width { get; set; }
        public static double TopPopulation { get; set; }
        public static int GenerationBestscore { get; set; }
        public static int GenerationBestSnake { get; set; }
        public static int WorldBestscore { get; set; }
        public static int PopulationSize { get; set; }
        public static Random Rand { get; set; }
        public static int MovesForFood { get; set; }
        public static int MovesAtStart { get; set; }
        public static int Speed { get; set; }
        public static int Id { get; set; }

        public Settings()
        {
            // atributes that can be changed
            HiddenLayers = 1; // only non-negative integers
            HiddenNodes = 6; // only positive integers
            MutationRate = 0.02; // value in range <0, 1>
            TopPopulation = 0.2; // value in range (0, 1>
            PopulationSize = 2000; // only positive integers
            MovesAtStart = 100; // only positive integers
            MovesForFood = 100; // only positive integers


            // this values cant be changed
            InputNodes = 4;
            OutputNodes = 3;
            Size = 40;
            Height = 14;
            Width = 28;
            GenerationBestscore = 0;
            WorldBestscore = 0;
            GenerationBestSnake = 0;
            Rand = new Random();
            Speed = 100;
        }
    }
}

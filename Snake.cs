using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace SnakeGA
{
    class Snake
    {
        List<Vector> body;
        Vector head;
        Vector acceleration;
        Vector food;
        Matrix input;
        double[] vision = new double[4];
        double foodDistX, foodDistY;
        int len;
        public int score;
        int steps;
        int moves_left;
        public double fitness;
        Boolean alive;
        public DNA d;

        int dir = 0;
        char[] dirs = { 'w', 'd', 's', 'a' };

        public Snake()
        {
            double x = Math.Round(Settings.Width / 2);
            double y = Math.Round(Settings.Height / 2);
            head = new Vector(x, y);
            body = new List<Vector>();
            len = 1;
            acceleration = new Vector(1, 0);
            x = Settings.Rand.Next(0, (int)Settings.Width);
            y = Settings.Rand.Next(0, (int)Settings.Height);
            food = new Vector(x, y);
            score = 0;
            moves_left = Settings.MovesAtStart;
            steps = 0;
            alive = true;
            fitness = 0;
            input = new Matrix(Settings.InputNodes, 1);
            d = new DNA();
    }

        public Snake(Snake s)
        {
            double x = Math.Round(Settings.Width / 2);
            double y = Math.Round(Settings.Height / 2);
            head = new Vector(x, y);
            body = new List<Vector>();
            len = 1;
            acceleration = new Vector(1, 0);
            x = Settings.Rand.Next(0, (int)Settings.Width);
            y = Settings.Rand.Next(0, (int)Settings.Height);
            food = new Vector(x, y);
            score = 0;
            steps = 0;
            moves_left = Settings.MovesAtStart;
            alive = true;
            d = new DNA(s.d);
            fitness = 0;
            input = new Matrix(Settings.InputNodes, 1);
        }

        public List<Rectangle> Show()
        {
            List<Rectangle> rects = new List<Rectangle>();

            int s = Settings.Size;
            Rectangle h = new Rectangle((int)head.X * s, (int)head.Y * s, Settings.Size, Settings.Size);
            Rectangle f = new Rectangle((int)food.X * s, (int)food.Y * s, Settings.Size, Settings.Size);
            Rectangle[] b = new Rectangle[len - 1];

            rects.Add(h);
            rects.Add(f);

            for (int j = 0; j < len - 1; j++)
            {
                b[j] = new Rectangle((int)body[j].X * s, (int)body[j].Y * s, Settings.Size, Settings.Size);
                rects.Add(b[j]);
            }

            return rects;
        }

        public void update()
        {
            foodDistX = food.X - head.X;
            foodDistY = food.Y - head.Y;

            border_vision();

            double x = foodDistX;
            double y = -foodDistY;
            double sinus = 0;
            double angle = 0;

            switch (dir)
            {
                case 0: //w
                    input.data[0, 0] = vision[3];
                    input.data[1, 0] = vision[0];
                    input.data[2, 0] = vision[2];

                    if (y <= 0 && x > 0)
                        sinus = 1;
                    else if (y <= 0 && x < 0)
                        sinus = -1;
                    else if (x == 0 && y > 0)
                        sinus = 0;
                    else if(y > 0 && x != 0)
                    {
                        angle = Math.Atan(x / y);
                        sinus = Math.Sin(angle);
                    }

                    input.data[3, 0] = sinus;
                    break;
                case 1: //d
                    input.data[0, 0] = vision[0];
                    input.data[1, 0] = vision[2];
                    input.data[2, 0] = vision[1];

                    if (x <= 0 && y > 0)
                        sinus = -1;
                    else if (x <= 0 && y < 0)
                        sinus = 1;
                    else if (y == 0 && x > 0)
                        sinus = 0;
                    else if (x > 0 && y != 0)
                    {
                        angle = Math.Atan(-y / x);
                        sinus = Math.Sin(angle);
                    }

                    input.data[3, 0] = sinus;
                    break;
                case 2: //s
                    input.data[0, 0] = vision[2];
                    input.data[1, 0] = vision[1];
                    input.data[2, 0] = vision[3];

                    if (x < 0 && y >= 0)
                        sinus = 1;
                    else if (x > 0 && y >= 0)
                        sinus = -1;
                    else if (x == 0 && y < 0)
                        sinus = 0;
                    else if (y < 0 && x != 0)
                    {
                        angle = Math.Atan(x / y);
                        sinus = Math.Sin(angle);
                    }

                    input.data[3, 0] = sinus;
                    break;
                case 3: //a
                    input.data[0, 0] = vision[1];
                    input.data[1, 0] = vision[3];
                    input.data[2, 0] = vision[0];

                    if (x >= 0 && y > 0)
                        sinus = 1;
                    else if (x >= 0 && y < 0)
                        sinus = -1;
                    else if (y == 0 && x < 0)
                        sinus = 0;
                    else if (x < 0 && y != 0)
                    {
                        angle = Math.Atan(-y / x);
                        sinus = Math.Sin(angle);
                    }

                    input.data[3, 0] = sinus;
                    break;
            }

            int temp = d.Compute(input);

            dir += temp;

            if (dir > 3)
                dir = 0;
            else if (dir < 0)
                dir = 3;

            direction(dirs[dir]);

            if (body.Count > 0)
            {
                for (int i = body.Count - 1; i > 0; i--)
                    body[i] = body[i - 1];
                body[0] = head;
            }

            head += acceleration;

            moves_left--;
            steps++;

            if(moves_left <= 0 || collision())
            {
                calculate_fitness();
                alive = false;
            }

            eat();
        }

        void eat()
        {
            if (food.X == head.X && food.Y == head.Y)
            {
                len++;
                score += 1;
                body.Insert(0, new Vector(head.X, head.Y));

                moves_left += Settings.MovesForFood;

                Boolean contains;
                double x;
                double y;

                do
                {
                    x = Settings.Rand.Next(0, (int)Settings.Width);
                    y = Settings.Rand.Next(0, (int)Settings.Height);
                    contains = false;

                    foreach (Vector b in body)
                    {
                        if (b.X == x && b.Y == y)
                            contains = true;
                    }
                } while (contains);

                food = new Vector(x, y);
            }
        }

        Boolean collision()
        { 
            Boolean collision = false;

            foreach (Vector b in body)
                if (b.X == head.X && b.Y == head.Y)
                {
                    collision = true;
                }

            if (head.X < 0 || head.X >= Settings.Width || head.Y < 0 || head.Y >= Settings.Height)
                collision = true;

            return collision;
        }

        void direction(char dir)
        {
            switch (dir)
            {
                case 'w':
                    acceleration = new Vector(0, -1);
                    break;
                case 's':
                    acceleration = new Vector(0, 1);
                    break;
                case 'a':
                    acceleration = new Vector(-1, 0);
                    break;
                case 'd':
                    acceleration = new Vector(1, 0);
                    break;
            }
        }

        public Boolean living()
        {
            return alive;
        }

        public void restart()
        {
            double x = Math.Round(Settings.Width / 2);
            double y = Math.Round(Settings.Height / 2);
            head = new Vector(x, y);
            body.Clear();
            len = 1;
            acceleration = new Vector(Settings.Size, 0);
            x = Settings.Rand.Next(0, (int)Settings.Width);
            y = Settings.Rand.Next(0, (int)Settings.Height);
            food = new Vector(x, y);
            score = 0;
            moves_left = Settings.MovesAtStart;
            steps = 0;
            alive = true;
            fitness = 0;
        }

        void calculate_fitness()
        {
            if (score < 10)
            {
                fitness = steps * steps;
                fitness *= Math.Pow(2, score);
            }
            else
            {
                fitness = steps * steps;
                fitness *= Math.Pow(2, 10);
                fitness *= (score - 9);
            }
        }

        void border_vision()
        {
            //NORTH
            vision[0] = 0;

            if (head.Y == 0)
                vision[0] = 1;

            foreach (Vector b in body)
                if (b.X == head.X && b.Y == head.Y - 1)
                    vision[0] = 1;

            //SOUTH
            vision[1] = 0;

            if (head.Y == Settings.Height - 1)
                vision[1] = 1;

            foreach (Vector b in body)
                if (b.X == head.X && b.Y == head.Y + 1)
                    vision[1] = 1;

            //EAST
            vision[2] = 0;

            if (head.X == Settings.Width - 1)
                vision[2] = 1;

            foreach (Vector b in body)
                if (b.Y == head.Y && b.X == head.X + 1)
                    vision[2] = 1;

            //WEST
            vision[3] = 0;

            if (head.X == 0)
                vision[3] = 1;

            foreach (Vector b in body)
                if (b.Y == head.Y && b.X == head.X - 1)
                    vision[3] = 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGA
{
    class Matrix
    {
        public int cols;
        public int rows;
        public double[,] data;

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.data = new double[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    this.data[i, j] = Settings.Rand.NextDouble() * 2 - 1;
                    //this.data[i, j] = r.Next(-2, 2);
        }

        public Matrix(Matrix m)
        {
            this.rows = m.rows;
            this.cols = m.cols;
            this.data = new double[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    this.data[i, j] = m.data[i, j];
        }

        public static Matrix Multiply(Matrix m, Matrix n)
        {
            Matrix result = new Matrix(m.rows, n.cols);

            for (int i = 0; i < m.rows; i++)
                for (int j = 0; j < n.cols; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < m.cols; k++)
                        sum += m.data[i, k] * n.data[k, j];
                    result.data[i, j] = sum;
                }
            return result;
        }

        public void Add(Matrix m)
        {
            for (int i = 0; i < this.rows; i++)
                for (int j = 0; j < this.cols; j++)
                    this.data[i, j] += m.data[i, j];
        }

        double Sigmoid(double x)
        {
            return (float)(1 / (1 + Math.Exp(-x)));
        }

        public void Activate()
        {
            for (int i = 0; i < this.rows; i++)
                for (int j = 0; j < this.cols; j++)
                    this.data[i, j] = Sigmoid(this.data[i, j]);
        }

        public void Show()
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                    Console.WriteLine(this.data[i, j].ToString());
                Console.WriteLine(" ");
            }
        }
    }
}

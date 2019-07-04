using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGA
{
    class DNA
    {
        int ins;
        int outs;
        int hl;
        int hn;
        public Matrix[] weights;
        public Matrix[] bias;

        public DNA()
        {
            ins = Settings.InputNodes;
            outs = Settings.OutputNodes;
            hl = Settings.HiddenLayers;
            hn = Settings.HiddenNodes;
            weights = new Matrix[hl + 1];
            bias = new Matrix[hl + 1];

            if (hl == 0)
            {
                weights[0] = new Matrix(outs, ins);
                bias[0] = new Matrix(outs, 1);
            }
            else
            {

                weights[0] = new Matrix(hn, ins);
                bias[0] = new Matrix(hn, 1);

                for (int i = 1; i < hl; i++)
                {
                    weights[i] = new Matrix(hn, hn);
                    bias[i] = new Matrix(hn, 1);
                }

                weights[hl] = new Matrix(outs, hn);
                bias[hl] = new Matrix(outs, 1);
            }
        }

        public DNA(DNA d)
        {
            ins = d.ins;
            outs = d.outs;
            hl = d.hl;
            hn = d.hn;
            weights = new Matrix[hl + 1];
            bias = new Matrix[hl + 1];

            for(int i = 0; i < hl+1; i++)
            {
                weights[i] = new Matrix(d.weights[i]);
                bias[i] = new Matrix(d.bias[i]);
            }
        }
        public int Compute(Matrix input)
        {
            int result = 'e';
            Matrix temp = Matrix.Multiply(weights[0], input);
            temp.Add(bias[0]);
            temp.Activate();

            for(int i = 1; i <= hl; i++)
            {
                temp = Matrix.Multiply(weights[i], temp);
                temp.Add(bias[i]);
                temp.Activate();
            }

            int max = 0;

            for (int i = 1; i < temp.rows; i++)
                if (temp.data[i, 0] > temp.data[max, 0])
                    max = i;

            switch (max)
            {
                case 0:
                    result = -1;
                    break;
                case 1:
                    result = 0;
                    break;
                case 2:
                    result = 1;
                    break;
            }

            return result;
        }

        public void Crossover(DNA p1, DNA p2)
        {
            double a;
            double b;

            for (int i = 0; i <= hl; i++)
            {
                a = Math.Floor(Settings.Rand.NextDouble() * weights[i].rows);
                b = Math.Floor(Settings.Rand.NextDouble() * weights[i].cols);

                for (int j = 0; j < weights[i].rows; j++)
                    for (int k = 0; k < weights[i].cols; k++)
                        if ((j < a) || (j == a && k <= b))
                            weights[i].data[j, k] = p1.weights[i].data[j, k];
                        else
                            weights[i].data[j, k] = p2.weights[i].data[j, k];

                a = Math.Floor(Settings.Rand.NextDouble() * bias[i].rows);

                for (int j = 0; j < bias[i].rows; j++)
                    if (j <= a)
                        bias[i].data[j, 0] = p1.bias[i].data[j, 0];
                    else
                        bias[i].data[j, 0] = p2.bias[i].data[j, 0];
            }
        }

        public void Mutation()
        {
            double r;

            for (int i = 0; i <= hl; i++)
            {
                for (int j = 0; j < weights[i].rows; j++)
                    for (int k = 0; k < weights[i].cols; k++)
                    {
                        r = Settings.Rand.NextDouble();
                        if (r <= Settings.MutationRate)
                            weights[i].data[j, k] = Settings.Rand.NextDouble() * 2 - 1;
                    }

                for (int j = 0; j < bias[i].rows; j++)
                {
                    r = Settings.Rand.NextDouble();
                    if (r <= Settings.MutationRate)
                        bias[i].data[j, 0] = Settings.Rand.NextDouble() * 2 - 1;
                }
            }
        }
    }
}

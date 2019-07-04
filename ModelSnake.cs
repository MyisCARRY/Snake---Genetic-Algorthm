using SnakeGA;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGA.Piotr_Bialas
{
    class ModelSnake
    {
        public Population pop = new Population();
        internal string KeyPressed(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.Speed - 10 >= 10)
                Settings.Speed -= 10;
            else if (e.KeyCode == Keys.Right && Settings.Speed + 10 <= 300)
                Settings.Speed += 10;

            return "<-- Delay: " + Settings.Speed.ToString() + " -->";
        }

        internal List<Rectangle> Print()
        {
            List<Rectangle> result = new List<Rectangle>();
            result = pop.Execute();
            return result;
        }
    }
}

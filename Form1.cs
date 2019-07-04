using SnakeGA;
using SnakeGA.Piotr_Bialas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SnakeGA
{
    public partial class Form1 : Form, IViewSnake
    {
        public event Action Print;
        public event Action KeyPressed;


        public List<Rectangle> Squares
        {
            set
            {
                Graphics canvas = this.CreateGraphics();

                for (int i = 0; i < value.Count; i++)
                {
                    if (i == 0)
                    {
                        canvas.FillRectangle(Brushes.Red, value[i]);
                    }
                    else if (i == 1)
                    {
                        canvas.FillRectangle(Brushes.Green, value[i]);
                    }
                    else
                    {
                        canvas.FillRectangle(Brushes.White, value[i]);

                    }
                }
            }
        }

        public string Title { set => this.Text = value; }
        public string Label
        {
            set
            {
                label1.Text = value;
            }
        }
        public KeyEventArgs Key { get; set; }

        public Form1()
        {
            InitializeComponent();
            new Settings();
            
            int w = (int)Settings.Width * Settings.Size;
            int h = (int)Settings.Height * Settings.Size;
            this.Size = new System.Drawing.Size(w, h);
            this.ClientSize = new System.Drawing.Size(w, h);

            label1.Location = new System.Drawing.Point(w / 2 - 80, h - 30);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Print();
            label1.Refresh();
            this.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            Key = e;
            KeyPressed();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["MainForm"].Enabled = true;
        }
    }
}

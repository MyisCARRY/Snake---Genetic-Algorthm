using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SnakeGA.Piotr_Bialas
{
    interface IViewSnake
    {
        List<Rectangle> Squares { set; }
        string Title { set; }
        string Label { set; }
        KeyEventArgs Key { get; set; }

        event Action Print;
        event Action KeyPressed;
    }
}

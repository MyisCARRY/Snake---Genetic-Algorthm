using SnakeGA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGA.Piotr_Bialas
{
    class PresenterSnake
    {
        IViewSnake view;
        ModelSnake model;

        public PresenterSnake(IViewSnake view, ModelSnake model)
        {
            this.view = view;
            this.model = model;
            this.view.KeyPressed += KeyPressed;
            this.view.Print += Print;
            this.view.Label = "<-- Delay: " + Settings.Speed.ToString() + " -->";
        }

        void KeyPressed()
        {
            view.Label = model.KeyPressed(view.Key);
        }

        void Print()
        {
            view.Squares = model.Print();
            view.Title = "Generation: " + model.pop.generation.ToString() + "  Score: " + model.pop.current_score.ToString() + "  Bestscore: " + Settings.WorldBestscore.ToString();
            Thread.Sleep(Settings.Speed);
        }
    }
}

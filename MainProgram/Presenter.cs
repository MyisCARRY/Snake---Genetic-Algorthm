using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGA
{
    class Presenter
    {
        private Model model;
        private IView view;
        public Presenter(Model m, IView v)
        {
            model = m;
            view = v;
            v.TrainNewSnake += TrainNewSnake;
            v.Reload += ReloadPopulation;
            v.PopulationChosen += CreateGraph;
            ReloadPopulation();

        }
        private void TrainNewSnake(InitList initList)
        {
            model.TrainNewSnake(initList);
            ReloadPopulation();
        }

        private void ReloadPopulation()
        {
            try
            {
                view.Populations = model.GetPopulations();
            }
            catch
            {
                view.ShowDBError();
            }
        }

        private void CreateGraph(int index)
        {
            try
            {
                view.ShowGraph(model.GetGraphData(index));
            }
            catch
            {
                view.ShowDBError();
            }
        }
    }
}

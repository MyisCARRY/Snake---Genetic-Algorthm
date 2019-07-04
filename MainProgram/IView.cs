using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGA
{
    interface IView
    {
        void ShowGraph(GraphData graphData);
        List<InitList> Populations { set; }
        event Action<InitList> TrainNewSnake;
        event Action<int> PopulationChosen;
        event Action Reload;
        void ShowDBError();
    }
}

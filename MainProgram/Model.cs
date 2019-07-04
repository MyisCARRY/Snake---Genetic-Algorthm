using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGA
{
    class Model
    {

        List<InitList> initLists;

        public GraphData GetGraphData(int indexInTheList)
        {
            int indexInDB = initLists[indexInTheList].Id;
            var points = DBHelper.GetGraphData(indexInDB);
            GraphData graphData = new GraphData(points.Item1, points.Item2, points.Item3, initLists[indexInTheList].ToString());
            return graphData;
        }

        public void TrainNewSnake(InitList initList)
        {
            SnakeShowdown m = new SnakeShowdown(initList);
            m.Run();
        }

        public List<InitList> GetPopulations()
        {
            initLists = DBHelper.GetInitLists();
            //if (initLists.Count == 0)
            //    throw new Exception("No data");
            return initLists;
        }

        private InitList ExampleInitList()
        {
            InitList testList = new InitList();
            testList.Id = 1;
            testList.HiddenLayers = 1;
            testList.HiddenNodes = 6;
            testList.Size = 2000;
            testList.MutationRate = 0.02;
            testList.TopPopulation = 0.2;
            testList.MovesAtStart = 200;
            testList.MovesForFood = 50;
            return testList;
        }
    }
}

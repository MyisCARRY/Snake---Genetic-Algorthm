using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGA
{
    public class GraphData
    {
        public int NumberOfPoints { private set; get; }
        public int[] PointsAvg { private set; get; }
        public int[] PointsMin { private set; get; }
        public int[] PointsMax { private set; get; }
        public string Title { private set; get; }

        public GraphData()
        {
            Title = "Test chart.";
            NumberOfPoints = 30;
            PointsAvg = new int[NumberOfPoints];
            PointsMin = new int[NumberOfPoints];
            PointsMax = new int[NumberOfPoints];
            for (int i = 0; i < NumberOfPoints; i++)
            {
                PointsAvg[i] = i;
                PointsMin[i] = i;
                PointsMax[i] = i + 2;
            }
        }

        public GraphData(int[] avg, int[] max, int[] min , string title)
        {
            Title = title;
            NumberOfPoints = avg.Length;
            PointsAvg = avg;
            PointsMax = max;
            PointsMin = min;
        }

       
    }
}

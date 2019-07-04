using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGA
{
    public partial class GraphForm : Form
    {
        public GraphForm()
        {
            InitializeComponent();
        }
        public GraphForm(GraphData graphData)
        {
            InitializeComponent();
            Text = graphData.Title;
            chart.Titles.Clear();
            chart.Titles.Add(graphData.Title);
            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            for (int i = 0; i < graphData.NumberOfPoints; i++)
            {
                chart.Series[0].Points.AddXY(i+1, graphData.PointsAvg[i]);
                chart.Series[1].Points.AddXY(i + 1, graphData.PointsMax[i]);
                chart.Series[2].Points.AddXY(i + 1, graphData.PointsMin[i]);
            }
            
        }
    }
}

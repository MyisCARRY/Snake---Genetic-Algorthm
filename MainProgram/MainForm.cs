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
    public partial class MainForm : Form, IView
    {
        public MainForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void ShowGraph(GraphData graphData)
        {
            ShowGraphDummy(graphData);
        }
        private void ShowGraphDummy(GraphData graphData)
        {
            GraphForm graphForm = new GraphForm(graphData);
            graphForm.Show();

        }

        public List<InitList> Populations {
            set
            {
                listView1.Items.Clear();

                foreach (var item in value)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = item.Id.ToString();
                    listViewItem.SubItems.Add( (item.Name!=null) ? item.Name : "<none>" );
                    listViewItem.SubItems.Add(item.HiddenLayers.ToString());
                    listViewItem.SubItems.Add(item.HiddenNodes.ToString());
                    listViewItem.SubItems.Add((item.MutationRate).ToString());
                    listViewItem.SubItems.Add(item.Size.ToString());
                    listViewItem.SubItems.Add((item.TopPopulation*100).ToString());
                    listViewItem.SubItems.Add(item.BestScore.ToString());
                    listView1.Items.Add(listViewItem);
                }
            }

        }

        public event Action<InitList> TrainNewSnake;

        public event Action<int> PopulationChosen;

        public event Action Reload;

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void buttonNewSnake_Click(object sender, EventArgs e)
        {

            using (InputFormNewSnake form = new InputFormNewSnake())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        InitList initList = new InitList();
                        initList.Name = form.SnakeName;
                        initList.HiddenLayers = int.Parse(form.HiddenLayers);
                        initList.HiddenNodes = int.Parse(form.HiddenNodes);
                        initList.Size = int.Parse(form.PopulationSize);
                        initList.MutationRate = double.Parse(form.MutationRate)/ 100;
                        initList.TopPopulation = double.Parse(form.TopPopulation) / 100;
                        initList.MovesAtStart = int.Parse(form.MovesAtStart);
                        initList.MovesForFood = int.Parse(form.MovesForFood);


                        if (initList.Validate())
                            TrainNewSnake?.Invoke(initList);
                        else
                            ShowWrongInput();
                    }
                    catch
                    {
                        ShowWrongInput();
                    }

                }
            }
           
        }
        private void ShowWrongInput()
        {
            MessageBox.Show("Incorrect data!", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listView1.SelectedItems[0].Index;
            PopulationChosen?.Invoke(index);
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            Reload?.Invoke();
        }
        public void ShowDBError()
        {
            MessageBox.Show("Occured error in retrieving data from database!", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

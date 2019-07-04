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
    public partial class InputFormNewSnake : Form
    {
        public InputFormNewSnake()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            textBoxHiddenLayers.Text = "1";
            textBoxHiddenNodes.Text = "6";
            textBoxPopulationSize.Text = "2000";
            textBoxMutationRate.Text = "2";
            textBoxTopPopulation.Text = "20";
            textBoxMovesAtStart.Text = "200";
            textBoxMovesForFood.Text = "50";
        }
        public string HiddenLayers
        {
            get { return (textBoxHiddenLayers.Text); }
        }
        public string HiddenNodes
        {
            get { return (textBoxHiddenNodes.Text); }
        }
        public string PopulationSize
        {
            get { return (textBoxPopulationSize.Text); }
        }
        public string MutationRate
        {
            get { return (textBoxMutationRate.Text); }
        }
        public string TopPopulation
        {
            get { return (textBoxTopPopulation.Text); }
        }
        public string MovesAtStart
        {
            get { return (textBoxMovesAtStart.Text); }
        }
        public string MovesForFood
        {
            get { return (textBoxMovesForFood.Text); }
        }
        public string SnakeName
        {
            get { return (textBoxName.Text); }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void InputFormNewSnake_Load(object sender, EventArgs e)
        {

        }
    }
}

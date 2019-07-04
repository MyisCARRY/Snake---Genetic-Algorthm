using SnakeGA;
using MySql.Data.MySqlClient;
using SnakeGA.Piotr_Bialas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGA
{
    class SnakeShowdown
    {
        public SnakeShowdown(InitList initList)
        {
            new Settings();

            Settings.HiddenLayers = initList.HiddenLayers;
            Settings.HiddenNodes = initList.HiddenNodes;
            Settings.PopulationSize = initList.Size;
            Settings.MutationRate = initList.MutationRate;
            Settings.MovesAtStart = initList.MovesAtStart;
            Settings.MovesForFood = initList.MovesForFood;

            var dbCon = DBConnection.Instance();

            if (dbCon.IsConnect())
            {
                string query = "INSERT INTO population (Name, HiddenLayers, HiddenNodes, Size, MutationRate, Top, MovesAtStart, MovesForFood) " +
                    "VALUES (\"" + initList.Name + "\", " + initList.HiddenLayers + ", " + initList.HiddenNodes + ", " + initList.Size + ", " + initList.MutationRate + ", " + initList.TopPopulation
                    + ", " + initList.MovesAtStart + ", " + initList.MovesForFood + ");";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                cmd.ExecuteNonQuery();

                query = "SELECT * FROM population WHERE Name=\"" + initList.Name + "\";";
                cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                    Settings.Id = int.Parse(reader.GetString("Id"));

                reader.Close();
                //dbCon.Close();
            }
        }

        public void Run()
        {
            ModelSnake model = new ModelSnake();
            IViewSnake view = new Form1();
            PresenterSnake presenter = new PresenterSnake(view, model);

            Form v = view as Form;
            v.Show();

            Application.OpenForms["MainForm"].Enabled = false;
        }
    }
}

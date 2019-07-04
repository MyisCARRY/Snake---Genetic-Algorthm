using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace SnakeGA
{
    class DBHelper
    {

        public static List<InitList> GetInitLists()
        {
            var dbConnection = DBConnection.Instance();
            var result = new List<InitList>();
            if(dbConnection.IsConnect())
            {
                string query = "select * from population;";

                var command = new MySqlCommand(query, dbConnection.Connection);
                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    const int DigitsToRound = 3;
                    InitList initList = new InitList();
                    initList.Id = reader.GetInt32("Id");
                    initList.Name = reader.GetString("Name");
                    initList.HiddenLayers = reader.GetInt32("HiddenLayers");
                    initList.HiddenNodes = reader.GetInt32("HiddenNodes");
                    initList.Size = reader.GetInt32("Size");
                    initList.MutationRate = Math.Round(reader.GetDouble("MutationRate"), DigitsToRound);
                    initList.TopPopulation = Math.Round(reader.GetDouble("Top"), DigitsToRound);
                    initList.MovesAtStart = reader.GetInt32("MovesAtStart");
                    initList.MovesForFood = reader.GetInt32("MovesForFood");
                    initList.BestScore = reader.GetInt32("BestScore");
                    result.Add(initList);
                }

                reader.Close();
                //dbConnection.Close();

                
            }

            return result;
        }

        public static Tuple<int[],int[], int[]> GetGraphData(int id)
        {
            int[] avg = new int[0];
            int[] min = new int[0];
            int[] max = new int[0];
            var dbConnection = DBConnection.Instance();
            if (dbConnection.IsConnect())
            {
                string query = $"select avg(Score),max(Score),min(Score), generation from snakes where IdPopulation = {id} group by generation;";
                var command = new MySqlCommand(query, dbConnection.Connection);
                var reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                int numberOfResults = dt.Rows.Count;
                avg = new int[numberOfResults];
                min = new int[numberOfResults];
                max = new int[numberOfResults];
                for (int i = 0; i < numberOfResults; i++)
                {
                    avg[i] = (int)double.Parse(dt.Rows[i][0].ToString());
                    max[i] = (int)double.Parse(dt.Rows[i][1].ToString());
                    min[i] = (int)double.Parse(dt.Rows[i][2].ToString());
                }

                reader.Close();
                //dbConnection.Close();


            }

            return new Tuple<int[], int[], int[]>(avg, max, min);
        }

        public static void ExecuteQuery(string query)
        {
            var dbConnection = DBConnection.Instance();
            if (dbConnection.IsConnect())
            {
                var command = new MySqlCommand(query, dbConnection.Connection);
                command.ExecuteNonQuery();
                //dbConnection.Close();
            }
        }

    }

    
}

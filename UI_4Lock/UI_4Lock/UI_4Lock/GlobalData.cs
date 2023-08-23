using MindFusion.Charting;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using static UI_4Lock.GlobalData;

namespace UI_4Lock
{
    public partial class GlobalData
    {
        public class Connection
        {
            public string server { get; private set; }
            public string uid { get; private set; }
            public string pwd { get; private set; }
            public string database { get; private set; }

            public Connection()
            {
                this.server = "172.32.146.209";
                this.uid = "root";
                this.pwd = "";
                this.database = "4lock";
            }
        }

        public static string Connect()
        {
            Connection connection = new Connection();
            string settings = "server=" + connection.server + ";uid=" + connection.uid + ";pwd=" + connection.pwd + ";database=" + connection.database;
            return settings;
            //"server=localhost;uid=root;pwd=Horsegrupo4;database=4lock";
        }

        public static void executeSafeQuery(MySqlConnection conn, string query, List<Tuple<string, object>> obj)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            foreach (var item in obj)
            {
                cmd.Parameters.AddWithValue(item.Item1, item.Item2);
            }
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                
            }
        }

    }
}
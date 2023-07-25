using MindFusion.Charting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;

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
                server = "localhost";
                uid = "root";
                pwd = "Horsegrupo4";
                database = "4lock";
            }
        }

        public static string Connect()
        {
            Connection connection = new Connection();
            string settings = "server=" + connection.server + ";uid=" + connection.uid + ";pwd=" + connection.pwd + ";database=" + connection.database;
            return settings;
            //"server=localhost;uid=root;pwd=Horsegrupo4;database=4lock";
        }
    }
}

/*
 class DBconnection {




    private string name;

    private string pw;

    private string db;




    void setname()...

   

    getConnection() ...




    //... funções para aceder à db

}




export? dbConnection = DBconnection();*/
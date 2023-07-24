using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_4Lock
{
    public partial class GlobalData
    {
        public string connect()
        {
            string settings = "server=localhost;uid=root;pwd=Horsegrupo4;database=4lock";
            return settings;
        }
    }
}

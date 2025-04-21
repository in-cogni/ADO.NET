using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Academy
{
    class Cache
    {
        public readonly string CONNECTION_STRING = "";
        SqlConnection connection;
        DataSet cache;
        SqlDataAdapter adapter;

        public Cache(string connection_string)
        {
            this.CONNECTION_STRING = connection_string;
            connection = new SqlConnection(CONNECTION_STRING);
            Console.WriteLine(CONNECTION_STRING);
        }
        public void Select(string tables)
        {
            cache = new DataSet();
            adapter = new SqlDataAdapter();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cargo_system
{
    class Connection
    {

        //public string constring = "Data Source=DESKTOP-1I1630E;Initial Catalog=Cargo_booking_system;Integrated Security=True";

        public SqlConnection conn = new SqlConnection();

        public void constring()
        {

            conn.ConnectionString = "Data Source=DESKTOP-1I1630E;Initial Catalog=Cargo_booking_system;Integrated Security=True";
        }
    }
}

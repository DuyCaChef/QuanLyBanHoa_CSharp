using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


//Class kết nối cơ sở dữ liệu MySQL
namespace QuanLyBanHoa
{
    public class Database
    {
        private static string connectionString = "server=localhost; database=quanlybanhoa; uid=root; pwd=Duy@2005";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

    }
}

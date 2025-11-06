using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;     
using QuanLyBanHoa_CSharp;
namespace QLHoa.Class
{
    class Functions
    {
        public static MySqlConnection Con;  
        public static void Connect()
        {
            Con = new MySqlConnection();   
            Con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + @"\Quanlybanhang.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            Con.Open();                
            if (Con.State == ConnectionState.Open)
                MessageBox.Show("Kết nối thành công");
            else MessageBox.Show("Không thể kết nối với dữ liệu");
        }
        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();   	
                Con.Dispose(); 	
                Con = null;
            }
        }
    }
}

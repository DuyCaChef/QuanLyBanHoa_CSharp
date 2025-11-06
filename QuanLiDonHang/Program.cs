using System;
using System.Windows.Forms;
using QuanLyBanHoa_CSharp.Forms;

namespace QuanLiDonHang
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormDonHang());
        }
    }
}

using System;
using System.Windows.Forms;
using QuanLyBanHoa_CSharp.Forms;

namespace ThongKeBaoCao
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormThongKeBaoCao());
        }
    }
}

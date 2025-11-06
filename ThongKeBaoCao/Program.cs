using System;
using System.Windows.Forms;

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

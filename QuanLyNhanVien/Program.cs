using System;
using System.Windows.Forms;
using QuanLyBanHoa_CSharp.Forms; // thêm dòng này để nhận các form trong thư mục Forms

namespace QuanLyBanHoa_CSharp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Thêm xử lý lỗi toàn cục
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new FrmQuanLiNhanVien());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi động ứng dụng:\n{ex.Message}\n\nChi tiết:\n{ex.StackTrace}", 
                    "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"Lỗi ứng dụng:\n{e.Exception.Message}\n\nChi tiết:\n{e.Exception.StackTrace}", 
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                MessageBox.Show($"Lỗi nghiêm trọng:\n{ex.Message}\n\nChi tiết:\n{ex.StackTrace}", 
                    "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

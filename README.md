# QuanLyBanHoa_CSharp
Đồ án Quản lý bán hàng (hoa) - C# .NET + MySQL

## 📌 Giới thiệu  
Đây là đồ án môn học về **Lập trình ứng dụng Windows (WinForms)** được thực hiện bằng ngôn ngữ **C#** và cơ sở dữ liệu **MySQL**.  
Ứng dụng hỗ trợ quản lý bán hàng cho cửa hàng hoa với các chức năng cơ bản:  
- Thêm, sửa, xóa thông tin sản phẩm (hoa).  
- Quản lý khách hàng và đơn hàng.  
- Quản lý chi tiết đơn hàng (số lượng, thành tiền).  
- Báo cáo doanh thu, in hóa đơn.  

---

## 🎯 Mục tiêu dự án
- Vận dụng kỹ thuật lập trình C# trên Windows Forms.  
- Thiết kế và triển khai một hệ thống quản lý bán hàng thực tế.  
- Nâng cao kỹ năng làm việc nhóm, sử dụng GitHub để phối hợp code.  
- Làm quen với mô hình **phân tích – thiết kế – hiện thực** phần mềm.  

---

## 🏗️ Công nghệ sử dụng
- **Ngôn ngữ:** C# (.NET Framework / .NET 8)  
- **Giao diện:** Windows Forms  
- **Cơ sở dữ liệu:** SQL Server  
- **ORM:** ADO.NET (hoặc Entity Framework Core)  
- **Quản lý mã nguồn:** Git + GitHub  
- **Thiết kế CSDL:** SSMS  
- **Vẽ sơ đồ UML/ERD:** Draw.io, Lucidchart  

---

## 📂 Cấu trúc thư mục dự án
```bash
QuanLyBanHoa_CSharp/
│
├── 📁 Database/
│   ├── DatabaseConnection.cs           // Kết nối MySQL
│   ├── QueryHelper.cs                  // Các hàm thực thi truy vấn
│
├── 📁 Models/
│   ├── Hoa.cs                          // Lớp đại diện cho 1 bông hoa
│   ├── NhanVien.cs                     // Lớp nhân viên
│   ├── KhachHang.cs                    // Lớp khách hàng
│   ├── DonHang.cs                      // Lớp đơn hàng
│
├── 📁 Services/
│   ├── HoaService.cs                   // Xử lý logic nghiệp vụ liên quan đến hoa
│   ├── NhanVienService.cs              // Xử lý logic nhân viên
│   ├── KhachHangService.cs             // Xử lý khách hàng
│   ├── DonHangService.cs               // Xử lý đơn hàng
│
├── 📁 Helpers/
│   ├── Utils.cs                        // Các hàm tiện ích chung
│   ├── Validator.cs                    // Kiểm tra dữ liệu nhập vào
│   ├── MessageHelper.cs                // Các hàm hiển thị thông báo
│
├── 📁 Forms/
│   ├── FrmDangNhap.cs                  // Form đăng nhập
│   ├── FrmDangNhap.Designer.cs
│   ├── FrmDangNhap.csproj
│   ├── FrmMain.cs                      // Form chính sau khi đăng nhập
│   ├── FrmMain.Designer.cs
│   ├── FrmHoa.cs                       // Form quản lý hoa
│   ├── FrmHoa.Designer.cs
│   ├── FrmNhanVien.cs
│   ├── FrmNhanVien.Designer.cs
│   ├── FrmKhachHang.cs
│   ├── FrmKhachHang.Designer.cs
│   ├── FrmDonHang.cs
│   ├── FrmDonHang.Designer.cs
│
├── 📁 Resources/
│   ├── images/                         // Hình ảnh giao diện (logo, banner, hoa,…)
│   ├── icons/
│
├── 📁 Properties/
│   ├── Resources.resx
│   ├── Settings.settings
│   ├── AssemblyInfo.cs
│
├── 📁 bin/
│
├── 📁 obj/
│
├── App.config                          // Cấu hình chuỗi kết nối MySQL
├── QuanLyBanHoa_CSharp.csproj
└── Program.cs                          // Điểm khởi đầu của chương trình
```

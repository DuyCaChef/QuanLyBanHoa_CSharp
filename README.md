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
- **Ngôn ngữ:** C# (.NET Framework / .NET 6)  
- **Giao diện:** Windows Forms  
- **Cơ sở dữ liệu:** MySQL  
- **ORM:** ADO.NET (hoặc Entity Framework Core)  
- **Quản lý mã nguồn:** Git + GitHub  
- **Thiết kế CSDL:** MySQL Workbench  
- **Vẽ sơ đồ UML/ERD:** Draw.io, Lucidchart  

---

## 📂 Cấu trúc thư mục dự án
QuanLyBanHoa/                # Solution folder
│
├── QuanLyBanHoa.sln         # Solution file
│
├── QuanLyBanHoa/            # Project folder
│   ├── QuanLyBanHoa.csproj  # Project file
│   ├── Program.cs           # File main (entry point)
│   ├── App.config           # File cấu hình (connection string, settings)
│   ├── FormMain.cs          # Form chính
│   ├── FormMain.Designer.cs # Mã thiết kế UI của FormMain
│   ├── FormMain.resx        # Resource của FormMain (text, icon…)
│   ├── Properties/
│   │   ├── AssemblyInfo.cs  # Thông tin project
│   │   └── Resources.resx   # Tài nguyên chung
│   └── bin/                 # File sau khi build (exe, dll)
│
└── database/                # (bạn tự thêm) script SQL tạo CSDL
    └── QuanLyBanHoa.sql


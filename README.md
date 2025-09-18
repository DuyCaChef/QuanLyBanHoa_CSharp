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

## 👨‍💻 Thành viên nhóm
- **Thành viên 1**: [Tên + MSSV] – Vai trò: Thiết kế CSDL, kết nối MySQL.  
- **Thành viên 2**: [Tên + MSSV] – Vai trò: Xây dựng giao diện WinForms.  
- **Thành viên 3**: [Tên + MSSV] – Vai trò: Xử lý chức năng và báo cáo.  

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
```bash
QuanLyBanHoa_CSharp/
│
├── src/                  # Code C# (Windows Forms)
│   ├── Forms/            # Các form giao diện
│   ├── Models/           # Lớp ánh xạ dữ liệu
│   ├── Services/         # Xử lý nghiệp vụ
│   └── Program.cs        # File main
│
├── database/             # Script SQL tạo CSDL, bảng, dữ liệu mẫu
│   └── QuanLyBanHoa.sql
│
├── docs/                 # Tài liệu phân tích, thiết kế, báo cáo
│   ├── UseCaseDiagram.png
│   ├── ERD.png
│   └── DFD_Level1.png
│
├── .gitignore            # File bỏ qua khi commit
├── README.md             # Giới thiệu dự án
└── QuanLyBanHoa.sln      # Solution file (nếu dùng Visual Studio)

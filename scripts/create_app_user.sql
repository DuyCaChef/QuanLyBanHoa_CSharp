-- Script: create_app_user.sql
-- Ch?y trên SQL Server (SSMS) b?ng tài kho?n có quy?n sysadmin
-- T?o login + user cho database 'QuanLyBanHoa' và c?p quy?n db_owner (phát tri?n)

IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'appuser')
BEGIN
    CREATE LOGIN [appuser] WITH PASSWORD = N'P@ssw0rd';
END
GO

USE QuanLyBanHoa;
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'appuser')
BEGIN
    CREATE USER [appuser] FOR LOGIN [appuser'];
END
GO

-- Thêm vào role db_owner cho dev (c?n tr?ng môi tr??ng production)
IF NOT EXISTS (SELECT * FROM sys.database_role_members drm JOIN sys.database_principals rp ON drm.role_principal_id = rp.principal_id WHERE rp.name = 'db_owner' AND drm.member_principal_id = DATABASE_PRINCIPAL_ID('appuser'))
BEGIN
    ALTER ROLE db_owner ADD MEMBER [appuser];
END
GO

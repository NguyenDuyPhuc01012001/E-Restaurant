﻿Create database ERSystem
go
USE ERSystem
GO

CREATE TABLE Staff
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL,
	sex NVARCHAR(5) NOT NULL,
	email NVARCHAR(100) UNIQUE,
	phone VARCHAR(10) UNIQUE,
	salary int NOT NULL,
	position INT NOT NULL  DEFAULT 0 -- 0: manager && 1: waiter && 2: chef
)
GO

CREATE TABLE Account
(
	id INT IDENTITY PRIMARY KEY,
	idStaff INT NOT NULL UNIQUE,
	userName VARCHAR(100) UNIQUE,	
	passWord VARCHAR(1000) NOT NULL DEFAULT '123456',

	FOREIGN KEY (idStaff) REFERENCES dbo.Staff(id)
)
GO
SELECT * FROM Account

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name VARCHAR(100) NOT NULL DEFAULT 'No name',
	status VARCHAR(100) NOT NULL DEFAULT 'Empty'	-- Empty || Using
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'No name'
)
GO

select * from FoodCategory

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'No name',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
 
CREATE TABLE Book
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	phone NVARCHAR(10) NOT NULL DEFAULT N'0123456789',
	dateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	idTable INT NOT NULL,
	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 -- 1: đã thanh toán && 0: chưa thanh toán	

	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
SELECT f.name, f.iDCategory,f.price, sum(bi.count) as OrderQuantity from Food as f, BillInfo as bi where f.id = bi.idFood group by f.name,f.iDCategory,f.price

GO

--Thêm NV
INSERT INTO dbo.Staff
(
    name,
    sex,
    email,
    phone,
    salary,
    position
)
VALUES
(   N'Duy Phúc',  -- name - nvarchar(100)
    1, -- sex - bit
    '19522038@gm.uit.edu.vn',   -- email - varchar(100)
    '1234',   -- phone - varchar(100)
    10000,    -- salary - int
    0     -- position - int
    )
GO

INSERT INTO dbo.Staff
(
    name,
    sex,
    email,
    phone,
    salary,
    position
)
VALUES
(   N'Doãn Thịnh',  -- name - nvarchar(100)
    1, -- sex - bit
    '1952@gm.uit.edu.vn',   -- email - varchar(100)
    '1351351',   -- phone - varchar(100)
    10000,    -- salary - int
    1     -- position - int
    )
GO

INSERT INTO dbo.Staff
(
    name,
    sex,
    email,
    phone,
    salary,
    position
)
VALUES
(   N'Xuân Thái',  -- name - nvarchar(100)
    1, -- sex - bit
    '19wr23r52@gm.uit.edu.vn',   -- email - varchar(100)
    '1232342',   -- phone - varchar(100)
    10000,    -- salary - int
    2     -- position - int
    )
GO

INSERT INTO dbo.Staff
(
    name,
    sex,
    email,
    phone,
    salary,
    position
)
VALUES
(   N'Hữu Phát',  -- name - nvarchar(100)
    1, -- sex - bit
    '195r3r2@gm.uit.edu.vn',   -- email - varchar(100)
    '122342334',   -- phone - varchar(100)
    10000,    -- salary - int
    1     -- position - int
    )
GO

--Thêm TK
INSERT INTO dbo.Account
(
	idStaff, 
	UserName 
)
VALUES  
(
	13,
	'manager'
)
GO

INSERT INTO dbo.Account
(
	idStaff, 
	UserName 
)
VALUES  
(
	14,
	'waiter'
)
GO

INSERT INTO dbo.Account
(
	idStaff, 
	UserName 
)
VALUES  
(
	15,
	'chef'
)
GO


-- thêm category
INSERT dbo.FoodCategory ( name )
VALUES  ( N'Hải sản')  
INSERT dbo.FoodCategory ( name )
VALUES  ( N'Nông sản' )
INSERT dbo.FoodCategory ( name )
VALUES  ( N'Lâm sản' )
INSERT dbo.FoodCategory ( name )
VALUES  ( N'Nước' )
GO

-- thêm món ăn
INSERT dbo.Food ( name, idCategory, price )
VALUES  ( N'Mực một nắng nước sa tế', 1 , 120000)
INSERT dbo.Food ( name, idCategory, price )
VALUES  ( N'Nghêu hấp xả', 1, 50000)
INSERT dbo.Food ( name, idCategory, price )
VALUES  ( N'Dú dê nướng sữa', 2, 60000)
INSERT dbo.Food ( name, idCategory, price )
VALUES  ( N'Heo rừng nướng muối ớt', 3, 75000)
INSERT dbo.Food ( name, idCategory, price )
VALUES  ( N'Cơm chiên mushi', 2, 999999)
INSERT dbo.Food ( name, idCategory, price )
VALUES  ( N'7Up', 4, 15000)
INSERT dbo.Food ( name, idCategory, price )
VALUES  ( N'Cafe', 4, 12000)
GO

--Thêm bàn
DECLARE @i INT = 1
WHILE @i <= 10
BEGIN
	INSERT dbo.TableFood (name) VALUES  ( 'Table ' + CAST(@i AS nvarchar(100)))
	SET @i = @i + 1
END
GO

--Procedure
CREATE PROC USP_Login
@userName varchar(100), @passWord varchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account
	WHERE UserName = @userName COLLATE SQL_Latin1_General_CP1_CS_AS
    AND PassWord = @passWord COLLATE SQL_Latin1_General_CP1_CS_AS
END
GO

CREATE PROC USP_GetPositionByUserName
@userName varchar(100)
AS 
BEGIN
	SELECT position FROM dbo.Account INNER JOIN dbo.Staff ON Staff.id = Account.idStaff
	WHERE UserName = @userName COLLATE SQL_Latin1_General_CP1_CS_AS
END
GO

SELECT f.name, bi.count,f.price, f.price*bi.count as totalPrice from BillInfo as bi, Bill as b , Food as f
where bi.idBill = b.id and bi.idFood = f.id and b.idTable =3
 
 
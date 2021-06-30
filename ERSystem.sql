﻿Create database ERSystem
GO 
USE ERSystem
GO
set dateformat DMY
GO 

CREATE TABLE Staff
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL,
	sex INT NOT NULL,
	email NVARCHAR(100) UNIQUE,
	phone VARCHAR(10) UNIQUE,
	salary int NOT NULL,
	position INT NOT NULL  DEFAULT 0 -- 0: manager && 1: waiter && 2: chef
)
	GO


select id from FoodCategory where name = N'Nông sản'


CREATE TABLE Account
(
	id INT IDENTITY PRIMARY KEY,
	idStaff INT NOT NULL UNIQUE,
	userName VARCHAR(100) UNIQUE,	
	passWord VARCHAR(1000) NOT NULL DEFAULT '123456',

	FOREIGN KEY (idStaff) REFERENCES dbo.Staff(id)
)
GO


CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name VARCHAR(100) NOT NULL DEFAULT N'No name',
	status VARCHAR(100) NOT NULL DEFAULT N'Empty'	-- Empty || Using
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'No name'
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'No name',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0
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

ALTER TABLE dbo.Food 
ADD Orderquantity int

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 -- 1: đã thanh toán && 0: chưa thanh toán	

	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO 

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
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

-- thêm bill
INSERT	dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckIn - date
          NULL , -- DateCheckOut - date
          3 , -- idTable - int
          0  -- status - int
        )        
INSERT	dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckIn - date
          NULL , -- DateCheckOut - date
          4, -- idTable - int
          0  -- status - int
        )
INSERT	dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckIn - date
          GETDATE() , -- DateCheckOut - date
          5 , -- idTable - int
          1  -- status - int
        )
GO 

-- thêm bill info
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          1, -- idFood - int
          2  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          3, -- idFood - int
          4  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          5, -- idFood - int
          1  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 6, -- idBill - int
          1, -- idFood - int
          2  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 2, -- idBill - int
          6, -- idFood - int
          2  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 3, -- idBill - int
          5, -- idFood - int
          2  -- count - int
          )   
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

CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
     INSERT dbo.Bill
	 (DateCheckIn,
	 DateCheckOut,
	 idTable,
	 status,
	 discount
	 )
	 VALUES
	 (GETDATE(),
	 NULL,
	 @idTable,
	 0,
	 0
	 )
	 UPDATE dbo.TableFood
	 SET status='Using'
	 WHERE id=@idTable
END
GO

CREATE PROC USP_InsertStaff
@name NVARCHAR(100),@sex INT,@email NVARCHAR(100), @phone VARCHAR(10), @salary INT,@position INT
AS
BEGIN
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
(   @name,
    @sex,
    @email, 
    @phone, 
    @salary, 
    @position 
    )
END
GO


CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT,@des NVARCHAR(100)
AS
BEGIN
  
   DECLARE @isExistBillInfo INT
   DECLARE @foodcount INT = 1 

   SELECT @isExistBillInfo = id,@foodcount=b.count
   FROM dbo.BillInfo AS b
   WHERE idBill = @idBill AND idFood = @idFood

   IF(@isExistBillInfo > 0)
   BEGIN
       DECLARE @newCount INT =@foodcount + @count
	   IF(@newCount > 0)
	     BEGIN
	      UPDATE dbo.BillInfo SET count = @newCount  WHERE idFood = @idFood
		  UPDATE dbo.BillInfo SET description = @des WHERE idFood = @idFood
		 END
       ELSE
	      DELETE dbo.BillInfo WHERE idBill=@idBill AND idFood = @idFood
		  
   END   
   ELSE
   BEGIN
     INSERT	dbo.BillInfo
        ( idBill, idFood, count,description,status )
VALUES  ( @idBill, -- idBill - int
          @idFood, -- idFood - int
          @count,  -- count - int
		  @des,
		  0
          )
	END
END
GO

Create PROC USP_SwitchTable
@idTable1 INT, @idTable2 int
AS 
BEGIN

	DECLARE @idFirstBill INT
	DECLARE @idSecondBill INT
	
	DECLARE @isFirstTablEmpty INT = 1
	DECLARE @isSecondTablEmpty INT = 1
	
	DECLARE @discountTbl1 INT = 0
	DECLARE @discountTbl2 INT = 0
	
	SELECT @idSecondBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
	
	SELECT @discountTbl1 = discount FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
	SELECT @discountTbl2 = discount FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0

	PRINT @idFirstBill
	PRINT @idSecondBill
	PRINT '----------1'
	
	IF (@idFirstBill IS NULL)
	BEGIN
		PRINT '0000001'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable,
		          status,
				  discount
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0 ,
				  0
		        )
		        
		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
		
	END
	
	SELECT @isFirstTablEmpty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill
	
	PRINT @idFirstBill
	PRINT @idSecondBill
	PRINT '----------2'
	
	IF (@idSecondBill IS NULL)
	BEGIN
		PRINT '0000002'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status,
				  discount
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0 ,
				  0
		        )
		SELECT @idSecondBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		
	END
	
	SELECT @isSecondTablEmpty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSecondBill
	
	PRINT @idFirstBill
	PRINT @idSecondBill
	PRINT '----------3'

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSecondBill
	
	UPDATE dbo.BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill
	
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)

	UPDATE dbo.Bill SET discount = @discountTbl2 WHERE id = @idFirstBill

	UPDATE dbo.Bill SET discount = @discountTbl1 WHERE id = @idSecondBill
	
	DROP TABLE IDBillInfoTable
	
	PRINT @isFirstTablEmpty
	PRINT @isSecondTablEmpty
	PRINT @discountTbl1
	PRINT @discountTbl2
	PRINT '----------4'
	IF (@isFirstTablEmpty = 0)
	BEGIN
		PRINT '1'
	    DELETE dbo.Bill WHERE idTable=@idTable2
		UPDATE dbo.TableFood SET status = N'Empty' WHERE id = @idTable2
	END
	IF (@isSecondTablEmpty = 0)
	BEGIN
		PRINT'2'
	    DELETE dbo.Bill WHERE idTable=@idTable1
		UPDATE dbo.TableFood SET status = N'Empty' WHERE id = @idTable1
	END
END
GO


CREATE PROC USP_CheckOutBill
@idTable INT, @totalPrice INT, @discount INT
AS
BEGIN
     UPDATE dbo.Bill
	 SET DateCheckOut=GETDATE(), status=1, totalPrice=@totalPrice,discount=@discount
	 WHERE idTable=@idTable AND status=0

	 UPDATE dbo.TableFood
	 SET status='Empty'
	 WHERE id=@idTable
END
GO

--UPDATE BILL
ALTER TABLE dbo.bill
ADD discount INT 
GO
UPDATE dbo.Bill set discount=0

--UPDATE BILLINFO
ALTER TABLE dbo.BillInfo
ADD description NVARCHAR(100)

ALTER TABLE dbo.BillInfo
ADD status INT 
GO 
UPDATE dbo.BillInfo set status=0

--UPDATE STAFF
ALTER TABLE STAFF
ALTER COLUMN sex INT


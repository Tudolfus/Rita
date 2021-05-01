CREATE PROCEDURE dbo.SaveProductDateInfo
@productName NVARCHAR(250),
@storeId int,
@date datetime,
@price decimal(10, 2)
AS
BEGIN TRAN

IF EXISTS (SELECT Name FROM dbo.Products AS prod WHERE prod.Name = @productName)
BEGIN
INSERT INTO dbo.Products (Name, StoreId) VALUES (@productName, @storeId)
END

INSERT INTO dbo.ProductsDateInfo (ProductId, Date, Price) VALUES ((SELECT TOP 1 Id FROM dbo.Products WHERE StoreId = @storeId AND Name = @productName), @date, @price)

COMMIT TRAN
CREATE PROCEDURE dbo.GetProducts
@search NVARCHAR(MAX),
@count SMALLINT
AS
BEGIN TRAN
SELECT TOP (@count) Id, Name FROM dbo.Products WHERE Name LIKE '%' + @search + '%'
COMMIT TRAN
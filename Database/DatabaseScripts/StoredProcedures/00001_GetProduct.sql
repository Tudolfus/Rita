SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetProduct]
@productName nvarchar(250)
AS
SELECT Price, Name Amount, Date
FROM dbo.Products
WHERE Name = @productName
GO

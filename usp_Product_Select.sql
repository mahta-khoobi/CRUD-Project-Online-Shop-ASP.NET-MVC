alter procedure dbo.usp_Product_Select
AS
begin
    SELECT p.Id,p.ProductCode,p.ProductName,p.ProductDescription,p.UnitPrice,pc.Category_Ref,pc.CategoryName
	from Product p inner join ProductCategory pc on p.Category_Ref=pc.Id
end
Go
exec usp_Product_Select
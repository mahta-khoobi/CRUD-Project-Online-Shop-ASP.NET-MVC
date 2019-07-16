create TYPE udt_ProductInfo_Insert as table
   (
	productCode int,
    productName nvarchar(60) ,
    productDescription nvarchar(260),
    unitPrice money ,
    category_Ref int
)
GO

alter PROCEDURE dbo.usp_Product_Insert
	(@productInfo_Insert as dbo.udt_ProductInfo_Insert Readonly
)
 
AS
begin tran
begin try
	declare @category_ref int
	select @category_ref=category_Ref from @productInfo_Insert
	if @category_ref in (select Id from ProductCategory)
	begin
	insert into Product(ProductCode,ProductName,ProductDescription,UnitPrice,Category_Ref)
		select productCode,productName,productDescription ,unitPrice ,category_Ref from @productInfo_Insert
		end
		else
		begin
			raiserror('there is no CategoryCode for this product',16,1)
		end
			 
commit tran
end try
begin catch
rollback
end catch
go


Declare @List as dbo.udt_ProductInfo_Insert
INSERT INTO @List VALUES (709, 'Nike','White',2000000,59)

exec dbo.usp_Product_Insert @productInfo_Insert = @List

select * from Product
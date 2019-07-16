create TYPE udt_ProductInfo_Update as table
   (
    id int, 
	productCode int,
    productName nvarchar(60) ,
    productDescription nvarchar(260),
    unitPrice money ,
    category_Ref int
)
GO

create PROCEDURE dbo.usp_Product_Update
	(
	@productInfo_Update as dbo.udt_ProductInfo_Update Readonly
	)
 
AS
begin tran
begin try

	declare @id int
    select @id=id from @productInfo_Update
	if @id in (select Id from Product)
	begin

    update Product

	set
	ProductCode=udt.productCode ,
	ProductName=udt.productName,
	ProductDescription=udt.productDescription,
	UnitPrice=udt.unitPrice,
	Category_Ref=udt.category_Ref
	from @productInfo_Update udt
	where Product.Id=udt.id
	end

	else
	begin 
	 raiserror('کد کالا وجود ندارد',16,1)
	end		 
commit tran
end try
begin catch
rollback
end catch
go

Declare @list as dbo.udt_ProductInfo_Update
INSERT INTO @list VALUES (34,34,'book','story',230,77)

exec dbo.usp_Product_Update @productInfo_Update = @list

select * from Product
create TYPE udt_CategoryInfoUpdate as table
   (
    id int, 
	categoryCode int,
	categoryName nvarchar(50)
)
GO

create PROCEDURE dbo.usp_Category_Update
	(
	@categoryInfoUpdate as dbo.udt_CategoryInfoUpdate Readonly
	)
 
AS
begin tran
begin try

	declare @id int
    select @id=id from @categoryInfoUpdate
	if @id in (select Id from ProductCategory)
	begin

    update ProductCategory

	set
	CategoryCode=udt.categoryCode ,
	CategoryName=udt.categoryName
	from @categoryInfoUpdate udt
	where ProductCategory.Id=udt.id
	end

	else
	begin 
	 raiserror('کد سفارش وجود ندارد',16,1)
	end		 
commit tran
end try
begin catch
rollback
end catch
go

Declare @list as dbo.udt_CategoryInfoUpdate
INSERT INTO @list VALUES (86,100,'sport')

exec dbo.usp_Category_Update @categoryInfoUpdate = @list

select * from ProductCategory
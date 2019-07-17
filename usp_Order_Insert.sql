
create TYPE udt_OrderDetailsList as table
   (
	unitPrice money ,
	discount decimal(18, 2) ,
	taxRate decimal(18, 2) ,
	quantity int ,
	product_Ref int
)
GO

create TYPE udt_OrderMasterList as table
   (
	orderCode int,
	orderDate datetime ,
    customer_Ref int 
)
GO

create PROCEDURE dbo.usp_Order_Insert
	(@orderMasterList as dbo.udt_OrderMasterList Readonly,
	@orderDetailsList as dbo.udt_OrderDetailsList Readonly
     )
 
AS
begin tran
begin try

    insert into OrderMaster(OrderCode,OrderDate,Customer_Ref)
	select orderCode,orderDate,customer_Ref from @orderMasterList

	Declare @orderMasterID int
	set @orderMasterID=(select max(OrderMaster.Id) from OrderMaster )

	insert into OrderDetails(UnitPrice,Discount,TaxRate,Quantity,Product_Ref,OrderMaster_Ref)
	select unitPrice,discount,taxRate,quantity,product_Ref,@orderMasterID from @orderDetailsList 
			 
commit tran
end try
begin catch
  SELECT ERROR_MESSAGE()

        IF @@TRANCOUNT>0
            ROLLBACK

end catch
go

Declare @OrderDetailsList as dbo.udt_OrderDetailsList
INSERT INTO @OrderDetailsList VALUES (1, 1,1,1,18)
Declare @OrderMasterList as dbo.udt_OrderMasterList
INSERT INTO @OrderMasterList VALUES (320,@@DATEFIRST,9)
exec dbo.usp_Order_Insert @orderMasterList=@OrderMasterList,@orderDetailsList=@OrderDetailsList

exec dbo.usp_Order_Select

select * from Orderdetails

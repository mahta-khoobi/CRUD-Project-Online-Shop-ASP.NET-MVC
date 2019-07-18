create PROCEDURE usp_Order_Delete(@id int)
AS 
begin
 if exists (select Id from OrderMaster where Id=@id)
 begin 
 if exists (select OrderMaster_Ref from OrderDetails where OrderMaster_Ref=@id)
 begin
 delete 
 from OrderDetails
 where OrderMaster_Ref=@id
 end

 delete 
 from OrderMaster 
 where Id=@id
 end
 else
 begin
raiserror('کد سفارش وجود ندارد',16,1)
 end
end
Go

exec usp_Order_Delete 19
GO
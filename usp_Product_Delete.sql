alter PROCEDURE usp_Product_Delete(@id int)
AS 
begin
 if exists (select Id from Product where Id=@id)
 begin 
 if exists (select Product_Ref from OrderDetails where Product_Ref=@id)
 begin
 raiserror('You cant delete this record because there is a record assiociated with this in Order Details Table',16,1)
 end
 else
 begin
 delete 
 from Product 
 where Id=@id
 end
 end
 else
 begin
raiserror('کد کالا وجود ندارد',16,1)
 end
end
Go

exec usp_Product_Delete 18

select * from Product
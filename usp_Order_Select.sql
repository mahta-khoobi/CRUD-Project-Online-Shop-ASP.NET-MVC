create procedure dbo.usp_Order_Select
as 
begin
select om.Id,om.OrderCode,om.OrderDate,om.Customer_Ref,c.CustomerCode,c.FirstName,c.LastName
from OrderMaster om join Customer c on om.Customer_Ref=c.Id
end

exec dbo.usp_Order_Select
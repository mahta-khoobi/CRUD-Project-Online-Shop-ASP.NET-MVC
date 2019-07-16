create procedure dbo.usp_ProductCategory_Select
as 
begin
select pc.Id,pc.CategoryCode,pc.CategoryName
from ProductCategory pc
end

GO
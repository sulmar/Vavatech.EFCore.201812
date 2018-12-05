
create procedure uspGetActiveCustomers as
begin
	select 
		Id, 
		FirstName,
		LastName,
		Gender,
		IsDeleted
	from dbo.Customers
	where IsDeleted = 0
end

GO

create procedure uspGetCustomersByFirstName
(
	@firstname nvarchar(50)
)
as begin
	select 
		Id, 
		FirstName,
		LastName,
		Gender,
		IsDeleted
	from dbo.Customers
	where FirstName like @firstname + '%'
end

GO
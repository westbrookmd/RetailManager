CREATE PROCEDURE [dbo].[spSale_SaleReport]
AS
begin
	set nocount on;

	select [s].[SaleDate], [s].[SubTotal], [s].[Tax], [s].[Total], u.FirstName, u.LastName, u.EmailAddress
	from dbo.Sale s
	inner join dbo.[User] u on s.CashierId = u.Id; -- instead of retrieving a GUID, We have first name, last name, email address
	-- filter with a where clause once in production
end

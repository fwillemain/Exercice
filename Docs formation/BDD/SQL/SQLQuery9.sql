begin tran

update Customers set ContactName = 'contact1' where CustomerID = 'ALFKI'
update Customers set ContactName = 'contact2' where CustomerID = 'ANATR'
update Customers set ContactName = 'contact3' where CustomerID = 'ANTON'

rollback

--ou commit pour effectuer

select * from Customers
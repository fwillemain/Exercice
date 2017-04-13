select GETDATE()

select CONVERT(varchar, getdate(), 101)

select YEAR('2017-02-01')
select MONTH('2017-02-01')
select DAY('2017-02-01')

select DATEPART(WEEKDAY, GETDATE())

select EmployeeId, LastName, FirstName, DATEDIFF(YEAR, BirthDate, HireDate)
from Employees


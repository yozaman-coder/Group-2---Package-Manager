USE THIS SQL TO UPDATE DATABASE
///////
ALTER TABLE Customers
ADD Password nvarchar(50);

UPDATE Customers SET CustPassword = 'password'
WHERE CustPassword IS NULL;

ALTER TABLE Customers
ALTER COLUMN CustPassword nvarchar(50) NOT NULL;
///////

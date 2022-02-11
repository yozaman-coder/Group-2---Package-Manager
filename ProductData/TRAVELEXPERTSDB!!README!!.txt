USE THIS SQL TO UPDATE DATABASE. We should probably make one sql file that does the entire database and drops the old database
so that Jolanta does not have to copy and past our stuff and drop and remake the database.
///////
ALTER TABLE Customers
ADD Password nvarchar(50);

UPDATE Customers SET CustPassword = 'password'
WHERE CustPassword IS NULL;

ALTER TABLE Customers
ALTER COLUMN CustPassword nvarchar(50) NOT NULL;
///////
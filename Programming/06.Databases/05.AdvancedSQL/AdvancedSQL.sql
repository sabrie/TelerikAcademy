-- Task 01. 
-- Write a SQL query to find the names and salaries of the employees 
-- that take the minimal salary in the company. Use a nested SELECT statement

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees)



-- Task 02.
-- Write a SQL query to find the names and salaries of the 
-- employees that have a salary that is up to 10% higher than the minimal salary for the company.
 
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary <= 
  (SELECT MIN(Salary) * 1.1 FROM Employees)



-- Task 03.
-- Write a SQL query to find the full name, salary and department of the employees 
-- that take the minimal salary in their department. Use a nested SELECT statement.

SELECT FirstName + ' ' + LastName as FullName, DepartmentID, Salary as MinSalary
FROM Employees e
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees 
   WHERE DepartmentID = e.DepartmentID)
ORDER BY DepartmentID



-- Task 04.
-- Write a SQL query to find the average salary in the department #1.

SELECT FirstName + ' ' + LastName as FullName, DepartmentID, Salary as MinSalary
FROM Employees e
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees 
   WHERE DepartmentID = 1)
ORDER BY DepartmentID



-- Task 05.
-- Write a SQL query to find the average salary in the "Sales" department.

SELECT
  AVG(Salary) [Average Salary]
FROM Employees e
WHERE DepartmentID = 3



-- Task 06.
-- Write a SQL query to find the number of employees in the "Sales" department.

SELECT COUNT(*) EmployeesCount FROM Employees
WHERE DepartmentID = 3



-- Task 07.
-- Write a SQL query to find the number of all employees that have manager.

SELECT COUNT(ManagerID) ManagerCount,
  COUNT(*) AllEmployeesCount
FROM Employees



-- Task 08.
-- Write a SQL query to find the number of all employees that have no manager.

SELECT COUNT(EmployeeID) EmployeeWithoutManagers
FROM Employees
WHERE ManagerID IS NULL



-- Task 09.
-- Write a SQL query to find all departments and the average salary for each of them.

SELECT DepartmentID, AVG(Salary) as AverageSalary
FROM Employees
GROUP BY DepartmentID



-- Task 10.
-- Write a SQL query to find the count of all employees in each department and for each town.

SELECT d.Name as DepartmentName, t.Name as TownName, COUNT(EmployeeID) as EmployeeCount
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
		ON a.AddressID = e.AddressID
		JOIN Towns t
			ON t.TownID = a.TownID
GROUP BY d.Name, t.Name



-- Task 11.
-- Write a SQL query to find all managers that have exactly 5 employees. 
-- Display their first name and last name.

SELECT m.FirstName + ' ' + m.LastName as ManagerName, 
	COUNT(*) as EmployeesCount
FROM Employees e JOIN Employees m
ON m.EmployeeID = e.ManagerID
GROUP BY m.FirstName + ' ' + m.LastName
HAVING COUNT(*) = 5



-- Task 12.
-- Write a SQL query to find all employees along with their managers.
-- For employees that do not have manager display the value "(no manager)".

SELECT e.FirstName + ' ' + e.LastName AS EmployeeName, 
  COALESCE(m.FirstName + ' ' + m.LastName, 
  'no manager') AS ManagerName
FROM Employees e LEFT OUTER JOIN Employees m
ON m.EmployeeID = e.ManagerID


-- Task 13.
-- Write a SQL query to find the names of all employees whose last name 
-- is exactly 5 characters long. Use the built-in LEN(str) function.

SELECT LastName, LEN(LastName) AS LastNameLength
FROM Employees
WHERE LEN(LastName) = 5



-- Task 14.
-- Write a SQL query to display the current date and time in the following format 
-- "day.month.year hour:minutes:seconds:milliseconds". Search in Google to find how to format dates in SQL Server.

SELECT convert(nvarchar, getdate(), 104) + ' ' +
(SELECT convert(nvarchar, getdate(), 114)) as [Date]

SELECT FORMAT(GETDATE(),'dd.MM.yyyy hh:mm:ss:fff')

-- Task 15.
-- Write a SQL statement to create a table Users. Users should have username, password, full 
-- name and last login time. Choose appropriate data types for the table fields. 
-- Define a primary key column with a primary key constraint. Define the primary key column 
-- as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. 
-- Define a check constraint to ensure the password is at least 5 characters long.

CREATE TABLE Users (
  UserID int IDENTITY,
  FullName nvarchar(100) NOT NULL,
  Username nvarchar(100) NOT NULL 
	CONSTRAINT UNIQUE_USERNAME UNIQUE, -- Define unique constraint to avoid repeating usernames
  UserPassword nvarchar(100) NOT NULL,
  LastLoginTime DATE,
  CONSTRAINT PK_Users PRIMARY KEY(UserID),
  CHECK (LEN(UserPassword) > 5)  -- Define a check constraint to ensure the password is at least 5 characters long.
)
GO



--Task 16.
-- Write a SQL statement to create a view that displays the users from the Users table 
-- that have been in the system today. Test if the view works correctly.

CREATE VIEW [Users today] AS
SELECT * FROM Users
WHERE DATEPART(YEAR, LastLoginTime) = DATEPART(YEAR, GETDATE()) AND
	  DATEPART(MONTH, LastLoginTime) = DATEPART(MONTH, GETDATE()) AND
	  DATEPART(DAY, LastLoginTime) = DATEPART(DAY, GETDATE())



-- Task 17.
-- Write a SQL statement to create a table Groups. Groups should have unique name 
-- (use unique constraint). Define primary key and identity column.

CREATE TABLE Groups (
  GroupID int IDENTITY, -- Define identity column
  Name nvarchar(100) NOT NULL 
	CONSTRAINT UNIQUE_GROUPNAME UNIQUE, -- Define unique constraint to avoid repeating group names
  CONSTRAINT PK_Groups PRIMARY KEY(GroupID) -- Define primary key
)
GO



-- Task 18.
-- Write a SQL statement to add a column GroupID to the table Users. Fill some 
-- data in this new column and as well in the Groups table. Write a SQL statement to add 
-- a foreign key constraint between tables Users and Groups tables.

ALTER TABLE Users ADD GroupID int

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY (GroupID)
  REFERENCES Groups(GroupID)



-- Task 19.
-- Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO Users (FullName, Username, UserPassword)
VALUES ('Pesho Petrov', 'pesho', '123456');

INSERT INTO Users (FullName, Username, UserPassword)
VALUES ('Gosho Goshev', 'gosho', '789789');

INSERT INTO Groups (Name)
VALUES ('CShapr');

INSERT INTO Groups (Name)
VALUES ('Databases');



-- Task 20.
-- Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE Users
SET FullName='Pesho Peshev'
WHERE FullName='Pesho Petrov'

UPDATE Users
SET Username='gosho.goshev'
WHERE FullName='Gosho Goshev'

UPDATE Groups
SET Name='C#'
WHERE GroupID='1'



-- Task 21.
-- Write SQL statements to delete some of the records from the Users and Groups tables.

DELETE FROM Users
WHERE Username='pesho' AND FullName='Pesho Peshev';

DELETE FROM Groups
WHERE Name='Databases';



-- Task 22.
-- Write SQL statements to insert in the Users table the names of all employees from the 
-- Employees table. Combine the first and last names as a full name. For username use the 
-- first letter of the first name + the last name (in lowercase). Use the same for the password, and NULL for last login time.

INSERT INTO Users
SELECT FirstName + ' ' + LastName as FullName, 
SUBSTRING(FirstName, 0, 1) + '' + LOWER(LastName) + CAST(EmployeeId  as varchar) as Username,
SUBSTRING(FirstName, 0, 1) + '' + LOWER(LastName) + '12345' as UserPassword,
NULL as LastLoginTime,
1
FROM Employees



-- Task 23.
-- Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

UPDATE Users
SET UserPassword=NULL
WHERE LastLoginTime IS NULL OR DATEDIFF(day, '2010-03-10 23:59:59.9999999', LastLoginTime) < 0; 



-- Task 24
-- Write a SQL statement that deletes all users without passwords (NULL password).

DELETE FROM Users
WHERE UserPassword IS NULL;



-- Task 25.
-- Write a SQL query to display the average employee salary by department and job title.

SELECT d.Name, JobTitle,
  AVG(Salary) [Average Salary]
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, JobTitle
ORDER BY d.Name



-- Task 26.
-- Write a SQL query to display the minimal employee salary by department and job title along with the 
-- name of some of the employees that take it.

SELECT d.Name, JobTitle,
  MIN(Salary) [Minimal Salary],
 MIN(LastName) as EmployeeName
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, JobTitle
ORDER BY d.Name



-- Task 27.
-- Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1 t.Name as TownName, COUNT(*) as EmployeeCount
FROM Employees e JOIN Addresses a
		ON a.AddressID = e.AddressID
		JOIN Towns t
			ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY EmployeeCount DESC



-- Task 28.
-- Write a SQL query to display the number of managers from each town.

SELECT t.Name as TownName, COUNT(*) as ManagerCount
FROM Employees e 
	JOIN Addresses a 
	ON e.AddressId = a.AddressId
		JOIN Towns t 
		ON t.TownId = a.TownId
WHERE e.ManagerId IS NOT NULL
GROUP BY t.TownId, t.Name;



-- Task 29.
-- Write a SQL to create table WorkHours to store work reports for each employee 
-- (employee id, date, task, hours, comments). Don't forget to define  identity, primary key and appropriate foreign key. 
	-- Issue few SQL statements to insert, update and delete of some data in the table.
	-- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
	-- For each change keep the old record data, the new record data and the command (insert / update / delete).

CREATE TABLE WorkHours(
	EmployeeID int IDENTITY,
	[Date] datetime,
	Task nvarchar(50),
	[Hours] int,
	Comment nvarchar(50),
	CONSTRAINT PK_WorkHours PRIMARY KEY(EmployeeID),
	CONSTRAINT FK_WorkHours_Employees 
	FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
)

INSERT INTO WorkHours([Date], Task, [Hours])
VALUES
	(getdate(), 'Task1', 18),
	(getdate(), 'Task2', 17)

DELETE FROM WorkHours
WHERE Task = 'Task1'

UPDATE WorkHours
SET HOURS = 10
WHERE Task = 'Task2'

CREATE TABLE WorkHoursLog(
	Id int IDENTITY,
	OldRecord nvarchar(100) NOT NULL,
	NewRecord nvarchar(100) NOT NULL,
	Command nvarchar(10) NOT NULL,
	EmployeeId int NOT NULL,
	CONSTRAINT PK_WorkHoursLog 
		PRIMARY KEY(Id),
	CONSTRAINT FK_WorkHoursLogs_WorkHours 
		FOREIGN KEY(EmployeeId) REFERENCES WorkHours(EmployeeID)
)

INSERT INTO WorkHours([Date], Task, [Hours], Comment)
VALUES(GETDATE(), 'Task3', 12, 'Comment3')

DELETE FROM WorkHours
WHERE Task = 'Task3'

UPDATE WorkHours
SET Task = 'Task2'
WHERE EmployeeID = 8



-- Task 30.
-- Start a database transaction, delete all employees from the 'Sales' department along with all dependent records 
-- from the pother tables. At the end rollback the transaction.

BEGIN TRAN
	ALTER TABLE EmployeesProjects
	ADD CONSTRAINT FK_CASCADE_1 FOREIGN KEY (EmployeeID)
	REFERENCES Employees (EmployeeID)
	ON DELETE CASCADE;

    -- ManagerId should accept NULL
	ALTER TABLE Departments
	ADD CONSTRAINT FK_CASCADE_2 FOREIGN KEY (ManagerId)
	REFERENCES Employees (EmployeeID)
	ON DELETE SET NULL;

	DELETE FROM Employees 
	WHERE DepartmentId IN (SELECT DepartmentId FROM Departments WHERE Name = 'Sales')

	ROLLBACK TRAN
GO



-- Task 31.
-- Start a database transaction and drop the table EmployeesProjects. 
-- Now how you could restore back the lost table data?

BEGIN TRAN
	CREATE DATABASE TelerikAcademy_Snapshot 
	ON (NAME = TelerikAcademy_Data, FILENAME = 'TelerikAcademy_Snapshot.ss')
	AS SNAPSHOT OF TelerikAcademy;

	DROP TABLE EmployeesProjects
	-- ROLLBACK TRAN
GO

BEGIN TRAN
	-- kick users
	ALTER DATABASE TelerikAcademy
	SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

	-- restore database
	USE master;
	RESTORE DATABASE TelerikAcademy FROM DATABASE_SNAPSHOT = 'TelerikAcademy_Snapshot';
GO



-- Task 32.
-- Find how to use temporary tables in SQL Server. Using temporary tables backup all records from EmployeesProjects 
-- and restore them back after dropping and re-creating the table.

CREATE TABLE #TempEmployeesProjects(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL
)

INSERT INTO #TempEmployeesProjects
	SELECT EmployeeID, ProjectID
	FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL,
	CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
	CONSTRAINT FK_EP_Employee FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
	CONSTRAINT FK_EP_Project FOREIGN KEY(ProjectID) REFERENCES Projects(ProjectID)
)

INSERT INTO EmployeesProjects
SELECT EmployeeID, ProjectID
FROM #TempEmployeesProjects
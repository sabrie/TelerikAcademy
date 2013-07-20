---------------------------------------------------------------------
-- Task 01.
-- Create a table in SQL Server with 10 000 000 log entries (date + text). 
-- Search in the table by date range. Check the speed (without caching).
---------------------------------------------------------------------

-- create a Database PerformanceDB
USE master
GO

CREATE DATABASE PerformanceDB
GO

USE PerformanceDB
GO

-- create a Logs table in PerformanceDB
CREATE TABLE Logs(
  LogId int NOT NULL IDENTITY,
  LogDate datetime,
  LogText nvarchar(300),
  CONSTRAINT PK_Messages_MsgId PRIMARY KEY (LogId)
)

-- Fill the table with 10 000 000 logs
-- !!! The procedure takes about 2 hours
SET NOCOUNT ON
DECLARE @LogsCount int = (SELECT COUNT(*) FROM Logs)
DECLARE @RowCount int = 10000000
WHILE @RowCount > 0
BEGIN
  DECLARE @Text nvarchar(100) = 
    'Text ' + CONVERT(nvarchar(100), @RowCount) + ': ' +
    CONVERT(nvarchar(100), newid())
  DECLARE @Date datetime = 
	DATEADD(month, -600, DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate()))
  INSERT INTO Logs(LogText, LogDate)
  VALUES(@Text, @Date)
  SET @RowCount = @RowCount - 1
END
SET NOCOUNT OFF



---------------------------------------------------------------------
-- Task 02.
-- Add an index to speed-up the search by date. Test the search 
-- speed (after cleaning the cache).
---------------------------------------------------------------------

-- Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;

-- search by date before adding indexes to LogDate
-- executed for 26 seconds without cache
-- executed for 1 second with cache
SELECT LogDate  FROM Logs
WHERE LogDate BETWEEN '1952-01-01' AND '1954-01-01'

-- Add index to LogDate
CREATE INDEX IDX_Logs_LogDate ON Logs(LogDate)

-- Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;

-- Optimized search after adding indexes to LogDate
-- executed for 1 second without cache
-- executed for 0 seconds with cache
SELECT LogDate  FROM Logs
WHERE LogDate BETWEEN '1952-01-01' AND '1954-01-01'



---------------------------------------------------------------------
-- Task 03.
-- Add a full text index for the text column. Try to search with 
-- and without the full-text index and compare the speed.
---------------------------------------------------------------------

-- Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;

-- search by date before adding indexes to LogText
-- executed for 34 seconds without cache
-- executed for 1 second with cache
SELECT LogText  FROM Logs
WHERE LogText = 'Text 9999001: D65FC00B-3AF3-44ED-AA20-411191356D9B'

-- Add index to LogText
CREATE INDEX IDX_Logs_LogText ON Logs(LogText)

-- Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;

-- Optimized search after adding indexes to LogText
-- executed for 0 seconds without cache
-- executed for 0 seconds with cache
SELECT LogText  FROM Logs
WHERE LogText = 'Text 9999001: D65FC00B-3AF3-44ED-AA20-411191356D9B'
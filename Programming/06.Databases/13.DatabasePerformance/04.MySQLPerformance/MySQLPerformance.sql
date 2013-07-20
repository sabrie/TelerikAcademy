CREATE DATABASE PartitioningDB;

USE PartitioningDB;

-- Create table Logs with partitions by years
CREATE TABLE Logs(
  LogId int NOT NULL AUTO_INCREMENT,
  LogText nvarchar(300),
  LogDate datetime,
  PRIMARY KEY (LogId, LogDate)
) PARTITION BY RANGE(YEAR(LogDate)) (
    PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p2 VALUES LESS THAN (2000),
    PARTITION p3 VALUES LESS THAN (2010),
    PARTITION p4 VALUES LESS THAN MAXVALUE
);

-- Fill the table with 1 000 000 logs with random dates
-- !!! Takes about 40 minutes
DELIMITER $$
CREATE PROCEDURE usp_AddOneMilionLogs()
BEGIN
DECLARE counter int;
DECLARE datata datetime;
SET counter = 1;
SET @MIN = '1954-04-30 14:53:27';
SET @MAX = '2013-04-30 14:53:27';
WHILE counter < 2 DO
SET datata = TIMESTAMPADD(SECOND, FLOOR(RAND() * TIMESTAMPDIFF(SECOND, @MIN, @MAX)), @MIN);
INSERT INTO Logs(LogDate, LogText)
VALUES(datata, 'Text');
SET counter = counter + 1;
END WHILE;
END$$
DELIMITER ;
CALL usp_AddOneMilionLogs;

-- Selects data from partitions
SELECT * FROM Logs PARTITION (p0);
SELECT * FROM Logs PARTITION (p2);
SELECT * FROM Logs PARTITION (p3);
SELECT * FROM Logs PARTITION (p4);

-- Select from all partittions
SELECT * FROM Logs;

-- Select from a single partition
SELECT * FROM Logs WHERE YEAR(LogDate) > 2009;
SELECT * FROM Logs WHERE YEAR(LogDate) > 1999;
SELECT * FROM Logs WHERE YEAR(LogDate) > 1989;
DROP DATABASE IF EXISTS MovieDatabase

CREATE DATABASE MovieDatabase

GO

USE MovieDatabase

ALTER DATABASE MovieDatabase
SET MULTI_USER

GO

CREATE TABLE Movies(  
	Id int IDENTITY(1,1) NOT NULL,
	Title varchar(200) NOT NULL,
	DescriptionBody varchar(2000),
	PRIMARY KEY(Id));

CREATE TABLE Reviews(  
	Id int IDENTITY(1,1) NOT NULL,
	MovieId int NOT NULL,
	Rating float NOT NULL,
	Title varchar(200) NOT NULL,
	Body varchar(2000),
	PRIMARY KEY(Id),
	FOREIGN KEY(MovieId) REFERENCES Movies(Id));

INSERT INTO Movies(Title, 
	DescriptionBody) 
VALUES('Star Wars: Episode III – Revenge of the Sith', 
	'Anakin joins forces with Obi-Wan and sets Palpatine free from the evil clutches of Count Doku. However, he falls prey to Palpatine and the Jedis'' mind games and gives into temptation.')

INSERT INTO Reviews(MovieId, 
	Rating,
	Title, 
	Body)
VALUES(1,
	10,
	'Great Movie',
	'Best star wars movie of all time')

INSERT INTO Reviews(MovieId, 
	Rating,
	Title, 
	Body)
VALUES(1,
	1,
	'bad Movie',
	'Worst star wars movie of all time')


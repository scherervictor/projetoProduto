CREATE TABLE Product (
	Id BIGINT IDENTITY(1,1) PRIMARY KEY,
	Name varchar(200),
	Value numeric (16,2),
	ImageURL varchar(1000)
);
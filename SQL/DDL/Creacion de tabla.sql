USE ISAACGARRO_PROYECTO2
GO
CREATE TABLE Cliente(
	ID varchar(12) primary key,
	FULL_NAME varchar(60) NOT NULL,
	PHONE_NUMBER varchar(9) NOT NULL,
	DISCOUNT int default 0 NOT NULL,
	RECENT_PURCHASES_AMOUNT decimal(18,2) default 0 NOT NULL,
	LAST_YEAR_PURCHASES decimal(18,2) default 0 NOT NULL,
	AC_UNITS_PURCHASED int NOT NULL
)
GO
CREATE TABLE Prospecto(
	ID varchar(12) primary key,
	CLIENT_TYPE varchar(10) NOT NULL,
	FULL_NAME varchar(60) NOT NULL,
	RECENT_PURCHASES_AMOUNT decimal(18,2) CHECK(RECENT_PURCHASES_AMOUNT > 1000000),
	AC_UNITS_PURCHASED int CHECK( AC_UNITS_PURCHASED >= 2),
	CONSTRAINT FK_PROSPECT_ID FOREIGN KEY (ID) REFERENCES Cliente(ID)
)
GO
CREATE TABLE MalProspecto(
   ID varchar(12) primary key foreign key references Cliente(ID),
   CLIENT_TYPE varchar(10) NOT NULL,
   FULL_NAME varchar(60) NOT NULL,
   PHONE_NUMBER varchar(9) NOT NULL,
   RECENT_PURCHASES_AMOUNT decimal(18,2),
   LAST_YEAR_PURCHASES decimal(18,2),
   CONSTRAINT FK_BAD_PROSPECT_ID FOREIGN KEY (ID) REFERENCES Cliente(ID)
)
GO
CREATE TRIGGER UpdateProspects
ON Cliente
AFTER UPDATE AS 
BEGIN
	UPDATE Prospecto
	SET Prospecto.FULL_NAME = Cliente.FULL_NAME
	FROM Prospecto INNER JOIN Cliente ON Prospecto.ID = Cliente.ID
	WHERE Cliente.FULL_NAME <> Prospecto.FULL_NAME;
	UPDATE MalProspecto
	SET MalProspecto.FULL_NAME = Cliente.FULL_NAME, MalProspecto.PHONE_NUMBER = Cliente.PHONE_NUMBER
	FROM MalProspecto INNER JOIN Cliente ON MalProspecto.ID = Cliente.ID
	WHERE MalProspecto.FULL_NAME <> Cliente.FULL_NAME OR MalProspecto.PHONE_NUMBER <> Cliente.PHONE_NUMBER
END;


select * from Cliente

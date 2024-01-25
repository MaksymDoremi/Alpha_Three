use master


drop database if exists Alpha_Three;
drop login admin_user;

go

create database Alpha_Three;

IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = 'admin_user')
BEGIN
    CREATE LOGIN admin_user WITH PASSWORD = '123';
END

--create login admin_user with password='123';
go

use Alpha_Three;

begin transaction;
go
CREATE USER [admin_user] FOR LOGIN [admin_user] WITH DEFAULT_SCHEMA=[dbo];
GO
ALTER ROLE [db_owner] ADD MEMBER [admin_user];
commit;

begin transaction;

create table Passenger
(
	ID int primary key identity(1,1),
	[Name] varchar(64) not null,
	[Surname] varchar(64) not null,
	[Email] varchar(100) not null check(Email like '%@%.%')
);

create table Train
(
	ID int primary key identity(1,1),
	Brand varchar(64) not null,
	Model varchar(64) not null,
	Capacity int not null check(Capacity > 0)
);

create table Train_driver
(
	ID int primary key identity(1,1),
	[Name] varchar(64) not null,
	[Surname] varchar(64) not null,
	[Email] varchar(100) not null check(Email like '%@%.%')

);

create table Station
(
	ID int primary key identity(1,1),
	[Name] varchar(64) not null,
	[Address] varchar(100) not null
);

create table Track
(
	ID int primary key identity(1,1),
	Station_Origin_ID int foreign key references Station(ID) not null,
	Station_Destination_ID int foreign key references Station(ID) not null,
	Track_length_km int not null check(Track_length_km > 0)
);

create table Drive
(
	ID int primary key identity(1,1),
	Train_drive_ID int foreign key references Train_driver(ID) not null,
	Track_ID int foreign key references Track(ID) not null,
	Train_ID int foreign key references Train(ID) not null,
	Departure datetime not null,
	Arrival datetime not null
);

create table Travel_class
(
	ID int primary key identity(1,1),
	[Name] varchar(64) not null check([Name] in ('Economy class', 'Business class', 'First class'))
);

insert into Travel_class(Name)
values('Economy class'), ('Business class'), ('First class');

create table Ticket
(
	ID int primary key identity(1,1),
	Passenger_ID int foreign key references Passenger(ID) not null,
	Drive_ID int foreign key references Drive(ID),
	Travel_class_ID int foreign key references Travel_class(ID),
	Seat_number int not null check(Seat_number >= 0),
	Date_of_purchase date not null,
	Price int not null check(Price > 0),
);




commit;


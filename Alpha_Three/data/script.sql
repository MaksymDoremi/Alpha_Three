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
	Train_driver_ID int foreign key references Train_driver(ID) not null,
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

go
create view Drive_information
as
select train_driver.Name as 'Train driver name', train_driver.Surname as 'Train driver surname', 
train_driver.Email as 'Train driver email', 
concat(origin.Name,' | ', origin.Address) as 'From', concat(destination.Name,' | ', destination.Address) as 'To', 
train.Brand as 'Train brand', train.Model as 'Train model', 
drive.Departure, drive.Arrival
from Train_driver train_driver join Drive drive on train_driver.ID = drive.Train_driver_ID
join Train train on train.ID = drive.Train_ID
join Track track on track.ID = drive.Track_ID
join Station origin on origin.ID = track.Station_Origin_ID
join Station destination on destination.ID = track.Station_Destination_ID;
go

create view Ticket_information
as
select passenger.Name as 'Passenger name', passenger.Surname as 'Passenger surname', passenger.Email as 'Passenger email', 
travel_class.Name as 'Travel class', ticket.ID as 'Ticket ID', 
concat(origin.Name,' | ', origin.Address) as 'From', concat(destination.Name,' | ', destination.Address) as 'To', 
drive.Departure, drive.Arrival, ticket.Seat_number as 'Seat number', 
ticket.Date_of_purchase as 'Date of purchase', ticket.Price
from Passenger passenger join Ticket ticket on passenger.ID = ticket.Passenger_ID
join Travel_class travel_class on travel_class.ID = ticket.Travel_class_ID
join Drive drive on drive.ID = ticket.Drive_ID
join Track track on track.ID = drive.Track_ID
join Station origin on origin.ID = track.Station_Origin_ID
join Station destination on destination.ID = track.Station_Destination_ID;
go

commit;

insert into Train_driver(Name, Surname, Email) 
values('Karel','Cerny', 'karel@cerny.cz'),
('Honza','Modry', 'honza@modry.cz');

insert into Station(Name, Address)
values('Branik','Praha-Branik'), ('Usti', 'Usti-centrum');

insert into Track(Station_Origin_ID, Station_Destination_ID, Track_length_km)
values(1,2,100);

insert into Train(Brand, Model, Capacity)
values('Skoda', 'T42', 100), ('Mercedes', 'Benz12', 300);

select * from Drive;
use master

/*
Project: Alpha 3
Author: Maksym Kintor
Email: kintormaksim@gmail.com
*/


go
DROP DATABASE IF EXISTS Alpha_Three;
go
CREATE DATABASE Alpha_Three;
go


IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = 'admin_user')
BEGIN
	-- HERE YOU CAN CHANGE LOGIN AND PASSWORD IF YOU WANT
    CREATE LOGIN admin_user WITH PASSWORD = '123';
END

BEGIN TRANSACTION;
USE Alpha_Three; 

GO
/****** Object:  User [admin_user]    Script Date: 04.02.2024 15:12:20 ******/
CREATE USER [admin_user] FOR LOGIN [admin_user] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin_user]
GO
/****** Object:  Table [dbo].[Train]    Script Date: 04.02.2024 15:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Train](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Brand] [varchar](64) NOT NULL,
	[Model] [varchar](64) NOT NULL,
	[Capacity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Train_driver]    Script Date: 04.02.2024 15:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Train_driver](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](64) NOT NULL,
	[Surname] [varchar](64) NOT NULL,
	[Email] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Station]    Script Date: 04.02.2024 15:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Station](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](64) NOT NULL,
	[Address] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Track]    Script Date: 04.02.2024 15:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Station_Origin_ID] [int] NOT NULL,
	[Station_Destination_ID] [int] NOT NULL,
	[Track_length_km] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drive]    Script Date: 04.02.2024 15:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drive](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Train_driver_ID] [int] NOT NULL,
	[Track_ID] [int] NOT NULL,
	[Train_ID] [int] NOT NULL,
	[Departure] [datetime] NOT NULL,
	[Arrival] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Drive_information]    Script Date: 04.02.2024 15:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Drive_information]
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
GO
/****** Object:  Table [dbo].[Passenger]    Script Date: 04.02.2024 15:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passenger](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](64) NOT NULL,
	[Surname] [varchar](64) NOT NULL,
	[Email] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Travel_class]    Script Date: 04.02.2024 15:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Travel_class](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 04.02.2024 15:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Passenger_ID] [int] NOT NULL,
	[Drive_ID] [int] NULL,
	[Travel_class_ID] [int] NULL,
	[Seat_number] [int] NOT NULL,
	[Date_of_purchase] [date] NOT NULL,
	[Price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Ticket_information]    Script Date: 04.02.2024 15:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[Ticket_information]
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
GO
SET IDENTITY_INSERT [dbo].[Drive] ON 
GO
INSERT [dbo].[Drive] ([ID], [Train_driver_ID], [Track_ID], [Train_ID], [Departure], [Arrival]) VALUES (1, 1, 1, 1, CAST(N'2000-12-12T12:12:12.000' AS DateTime), CAST(N'2000-12-12T12:12:12.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Drive] OFF
GO
SET IDENTITY_INSERT [dbo].[Passenger] ON 
GO
INSERT [dbo].[Passenger] ([ID], [Name], [Surname], [Email]) VALUES (1, N'Karel', N'Passenger', N'email@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Passenger] OFF
GO
SET IDENTITY_INSERT [dbo].[Station] ON 
GO
INSERT [dbo].[Station] ([ID], [Name], [Address]) VALUES (1, N'Branik', N'Praha-Branik')
GO
INSERT [dbo].[Station] ([ID], [Name], [Address]) VALUES (2, N'Usti', N'Usti-centrum')
GO
SET IDENTITY_INSERT [dbo].[Station] OFF
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON 
GO
INSERT [dbo].[Ticket] ([ID], [Passenger_ID], [Drive_ID], [Travel_class_ID], [Seat_number], [Date_of_purchase], [Price]) VALUES (1, 1, 1, 1, 123, CAST(N'2000-12-12' AS Date), 123)
GO
SET IDENTITY_INSERT [dbo].[Ticket] OFF
GO
SET IDENTITY_INSERT [dbo].[Track] ON 
GO
INSERT [dbo].[Track] ([ID], [Station_Origin_ID], [Station_Destination_ID], [Track_length_km]) VALUES (1, 1, 2, 100)
GO
SET IDENTITY_INSERT [dbo].[Track] OFF
GO
SET IDENTITY_INSERT [dbo].[Train] ON 
GO
INSERT [dbo].[Train] ([ID], [Brand], [Model], [Capacity]) VALUES (1, N'Skoda', N'T42', 100)
GO
INSERT [dbo].[Train] ([ID], [Brand], [Model], [Capacity]) VALUES (2, N'Mercedes', N'Benz12', 300)
GO
SET IDENTITY_INSERT [dbo].[Train] OFF
GO
SET IDENTITY_INSERT [dbo].[Train_driver] ON 
GO
INSERT [dbo].[Train_driver] ([ID], [Name], [Surname], [Email]) VALUES (1, N'Karel', N'Cerny', N'karel@cerny.cz')
GO
INSERT [dbo].[Train_driver] ([ID], [Name], [Surname], [Email]) VALUES (2, N'Honza', N'Modry', N'honza@modry.cz')
GO
SET IDENTITY_INSERT [dbo].[Train_driver] OFF
GO
SET IDENTITY_INSERT [dbo].[Travel_class] ON 
GO
INSERT [dbo].[Travel_class] ([ID], [Name]) VALUES (1, N'Economy class')
GO
INSERT [dbo].[Travel_class] ([ID], [Name]) VALUES (2, N'Business class')
GO
INSERT [dbo].[Travel_class] ([ID], [Name]) VALUES (3, N'First class')
GO
SET IDENTITY_INSERT [dbo].[Travel_class] OFF
GO
ALTER TABLE [dbo].[Drive]  WITH CHECK ADD FOREIGN KEY([Track_ID])
REFERENCES [dbo].[Track] ([ID])
GO
ALTER TABLE [dbo].[Drive]  WITH CHECK ADD FOREIGN KEY([Train_driver_ID])
REFERENCES [dbo].[Train_driver] ([ID])
GO
ALTER TABLE [dbo].[Drive]  WITH CHECK ADD FOREIGN KEY([Train_ID])
REFERENCES [dbo].[Train] ([ID])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([Drive_ID])
REFERENCES [dbo].[Drive] ([ID])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([Passenger_ID])
REFERENCES [dbo].[Passenger] ([ID])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([Travel_class_ID])
REFERENCES [dbo].[Travel_class] ([ID])
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD FOREIGN KEY([Station_Destination_ID])
REFERENCES [dbo].[Station] ([ID])
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD FOREIGN KEY([Station_Origin_ID])
REFERENCES [dbo].[Station] ([ID])
GO
ALTER TABLE [dbo].[Passenger]  WITH CHECK ADD CHECK  (([Email] like '%@%.%'))
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD CHECK  (([Price]>(0)))
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD CHECK  (([Seat_number]>=(0)))
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD CHECK  (([Track_length_km]>(0)))
GO
ALTER TABLE [dbo].[Train]  WITH CHECK ADD CHECK  (([Capacity]>(0)))
GO
ALTER TABLE [dbo].[Train_driver]  WITH CHECK ADD CHECK  (([Email] like '%@%.%'))
GO
ALTER TABLE [dbo].[Travel_class]  WITH CHECK ADD CHECK  (([Name]='First class' OR [Name]='Business class' OR [Name]='Economy class'))
COMMIT;

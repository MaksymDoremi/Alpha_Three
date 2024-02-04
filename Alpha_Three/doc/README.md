# Alpha_Three
Project that is used for managing data for imaginatory "České dráhy".  
It was developed as school project to show our ability to design and implement complex solutions.  

## Author
- Name: Maksym Kintor
- Email: kintormaksim@gmail.com
- School: Secondary Technical School of Electrical Engineering
- Grade: C4b

## Technology used
- C# .NET
- MSSQL

## Table of Contents
- [Installation](#installation)
- [Run](#run)
- [Configuration](#configuration)
- [Use Case](#use-case)
- [Architecture](#architecture)
  - [User tier](#user-tier)
  - [Business tier](#business-tier)
  - [Data tier](#data-tier)
- [Activity](#activity)
  - [Scenario #1 => example of CRUD commands](#scenario-1--example-of-crud-commands)
  - [Scenario #2 => example of report commands](#scenario-2--example-of-report-commands)
- [E-R diagram](#e-r-diagram)
- [File structure](#file-structure)
- [Errors](#errors)
- [Resume](#resume)


## Installation
```bash
git clone https://github.com/MaksymDoremi/Alpha_Three.git
```

## Run 
Before execution, do the following steps according to [Configuration](#configuration).  
Run by the exact instructions!  
Windows CMD
```bash
cd Alpha_Three/Alpha_Three/bin/Debug/net6.0/

Alpha_Three.exe # execute exe file, or you can just click on it.
```
Git Bash
```bash
cd Alpha_Three/Alpha_Three/bin/Debug/net6.0/

./Alpha_Three.exe # execute exe file, or you can just click on it.
```



## Configuration
1) Before running the program, firstly import database, script you can find at `Alpha_Three/data/export.sql`. Use MSSQL Server Management Studio to do so.
    - You can change the login and password -> if you do so, then you must change it in connectionString. Default is "admin_user" with password "123"

User has access to configure following variables at `Alpha_Three/App.config`
- **skolniConnection** connectionString="Data Source=**PCXXX**;Initial Catalog=Alpha_Three;Persist Security Info=True;User ID=**admin_user**;Password=**123**"  
Connection string to the database. Uses custom user, which is created with database export, **You have to change PCXXX to your PC**.
- **logFilePath** value="../../../errorLogs/log.txt"  
Path where erros are logged, you can change it if you want.
Default is `Alpha_Three/errorLogs/log.txt`.  
You can use relative path or absolute `C:/somewhere`
- **ticketViewReportPath** value="../../../data/ticketReport.txt"  
Path where you get ticket report, default is `Alpha_Three/data/ticketReport.txt`.  
You can use relative path or absolute `C:/somewhere`
- **driveViewReportPath** value="../../../data/driveReport.txt"  
Path where you get drive report, default is `Alpha_Three/data/driveReport.txt`.  
You can use relative path or absolute `C:/somewhere`


## Use Case
User can choose what he wants to do just by typing 1-n numbers => to choose from list of available commands.  
Tables and report sections are accessed through strings "tables" and "report" from Application layer.  
Each CRUD command has its own environment that requires user to provide data needed for operation.

Application
- tables
    - Drive {create, retrieve, update, delete}
    - Passenger {create, retrieve, update, delete, import_json}
    - Station {create, retrieve, update, delete, import_json}
    - Ticket {create, retrieve, update, delete}
    - Track {create, retrieve, update, delete}
    - Train_driver {create, retrieve, update, delete, import_json}
    - Train {create, retrieve, update, delete, import_json}
    - Travel_class {retrieve}
- report
    - DriveReportCommand
    - TicketReportCommand


## Architecture
Project is developed as three-tier application.
Main functionality is provided by ICommand, BLL(Business Logic Layer) and DAL(Data Access Layer).

### User tier
- Application - first entry point, displays message on the screen, gives access to tables and report sections.  
It's while(True) loop that requires user to type in command he wants to execute, in case of bad command returns "Unknown command". 

### Business tier
- ICommand - interface for other commands, has string Execute(){} method, that each command executes differently.
- TablenameCommand - commands that are entry points to the CRUD commands available for each command. It's while(True) loop, that works on the same principe as Application loop.  
Requires user to type 1-n to execute CRUD command, in case of bad command returns "Unknown command" and execution goes on.
- CRUDTablenameCommand - commands that execute the exact CRUD operation. Requires user to interact, require user to provide data for execution, in case of bad input exception occurs -> user is notified, error logged, and execution terminates, user returns back on TablenameCommand while(True) loop.
- TablenameBLL - business logic layer for each table in the database, it's middleware between application tier and data tier, executes TablenameDAL functions, throws exception to the CRUDTablenamCommand, which catches that exception.

### Data tier
- TablenameDAL - data access layer for each table in the database, directly communicates with database, manipulates with data. Throws exception to the TablenameBLL, which throws that exception to CRUDTablenameCommand.

## Activity
### Scenario #1 => example of CRUD commands
- Application.Run() -> while(True) loop, give access to tables and report sections  
- type in "tables"  
- TablesCommand.Execute() -> user can choose number 1-8 to choose tables he wants to work with
- type in "1"
- DriveCommand.Execute() -> while(True) loop, gives acces to 1-4 CRUD commands to work with drive table
- type in "2"
- RetrieveDriveCommand().Execture() -> return all drives from database

### Scenario #2 => example of report commands
- Application.Run() -> while(True) loop, give access to tables and report sections  
- type in "report"  
- ReportCommand.Execute() -> user can choose number 1-2 to choose what he want to report, tickets or drives
- type in "1"
- DriveReportCommand.Execute() -> gathers data from db and try to write it to txt file


## E-R diagram
![ER diagram](../Alpha_Three/data/ERdiagram.png "Diagram")

## File structure
<pre>
│   .gitignore
│   Alpha_Three.sln
│
├───.github
│       README.md
│
└───Alpha_Three
    │   Alpha_Three.csproj
    │   App.config
    │   Program.cs
    │
    ├───bin
    │   └───Debug
    │       └───net6.0
    │                 Alpha_Three.exe
    │
    ├───data
    │       check-list.md
    │       D.13 Checklist.pdf
    │       driveReport.txt
    │       ERdiagram.png
    │       passengers.json
    │       requirements.txt
    │       script.sql
    │       stations.json
    │       ticketReport.txt
    │
    ├───doc
    │       README.md(<b>this file</b>)
    │
    ├───logs
    │       log.txt
    |
    └───src
        ├───application
        │       Application.cs
        │
        ├───BLL
        │       DriveBLL.cs
        │       DriveViewBLL.cs
        │       PassengerBLL.cs
        │       StationBLL.cs
        │       TicketBLL.cs
        │       TicketViewBLL.cs
        │       TrackBLL.cs
        │       TrainBLL.cs
        │       Train_driverBLL.cs
        │       Travel_classBLL.cs
        │
        ├───commands
        │   │   ClearCommand.cs
        │   │   HelpCommand.cs
        │   │   TablesCommand.cs
        │   │
        │   ├───DriveCommands
        │   │       CreateDriveCommand.cs
        │   │       DeleteDriveCommand.cs
        │   │       DriveCommand.cs
        │   │       RetrieveDriveCommand.cs
        │   │       UpdateDriveCommand.cs
        │   │
        │   ├───PassengerCommands
        │   │       CreatePassengerCommand.cs
        │   │       DeletePassengerCommand.cs
        │   │       ImportJsonPassengerCommand.cs
        │   │       PassengerCommand.cs
        │   │       RetrievePassengerCommand.cs
        │   │       UpdatePassengerCommand.cs
        │   │
        │   ├───ReportCommands
        │   │       DriveReportCommand.cs
        │   │       ReportCommand.cs
        │   │       TicketReportCommand.cs
        │   │
        │   ├───StationCommands
        │   │       CreateStationCommand.cs
        │   │       DeleteStationCommand.cs
        │   │       ImportJsonStationCommand.cs
        │   │       RetrieveStationCommand.cs
        │   │       StationCommand.cs
        │   │       UpdateStationCommand.cs
        │   │
        │   ├───TicketCommands
        │   │       CreateTicketCommand.cs
        │   │       DeleteTicketCommand.cs
        │   │       RetrieveTicketCommand.cs
        │   │       TicketCommand.cs
        │   │       UpdateTicketCommand.cs
        │   │
        │   ├───TrackCommands
        │   │       CreateTrackCommand.cs
        │   │       DeleteTrackCommand.cs
        │   │       RetrieveTrackCommand.cs
        │   │       TrackCommand.cs
        │   │       UpdateTrackCommand.cs
        │   │
        │   ├───TrainCommands
        │   │       CreateTrainCommand.cs
        │   │       DeleteTrainCommand.cs
        │   │       ImportJsonTrainCommand.cs
        │   │       RetrieveTrainCommand.cs
        │   │       TrainCommand.cs
        │   │       UpdateTrainCommand.cs
        │   │
        │   ├───Train_driverCommands
        │   │       CreateTrain_driverCommand.cs
        │   │       DeleteTrain_driverCommand.cs
        │   │       ImportJsonTrain_driverCommand.cs
        │   │       RetrieveTrain_driverCommand.cs
        │   │       Train_driverCommand.cs
        │   │       UpdateTrain_driverCommand.cs
        │   │
        │   └───Travel_classCommands
        │           RetrieveTravel_classCommand.cs
        │           Travel_classCommand.cs
        │
        ├───DAL
        │       DriveDAL.cs
        │       DriveViewDAL.cs
        │       PassengerDAL.cs
        │       StationDAL.cs
        │       TicketDAL.cs
        │       TicketViewDAL.cs
        │       TrackDAL.cs
        │       TrainDAL.cs
        │       Train_driverDAL.cs
        │       Travel_classDAL.cs
        │
        ├───db
        │       DatabaseConnection.cs
        │
        ├───interfaces
        │       IBaseClass.cs
        │       ICommand.cs
        │       IFunctions.cs
        │
        ├───logger
        │       Logger.cs
        │
        └───Objects
                Drive.cs
                DriveView.cs
                Passenger.cs
                Station.cs
                Ticket.cs
                TicketView.cs
                Track.cs
                Train.cs
                Train_driver.cs
                Travel_class.cs
</pre>

## Errors
There might be wrong connection string or some issues, in that case application will try to connect 3 more times with interval 2 seconds, if still can't then it's shutdown.  
You can find errors at `Alpha_Three/errorLogs/log.txt`

Application handles DML errors, in case of error -> notify uses and log error, with those errors application may continue to run without issues.

## Resume
This project was developed as school task in order to teach students how to work on bigger solutions.  
That definitely gonna teach students to think in advance and try to design better and inteligent projects.  
This project can be used as educational content in schools.  

USE [Twitter]
CREATE TABLE Users
(
Id int Identity(1,1) primary key,
FullName varchar(60) not null,
Username varchar(60) not null UNIQUE,
Email varchar(100) not null UNIQUE,
Passwrd varchar(60) not null
)

CREATE TABLE Tweets
(
Id int Identity(1,1) primary key,
User_Id int not null,
Title varchar(50) not null,
Body varchar(250) not null,
FOREIGN KEY (User_Id) REFERENCES Users(Id)
)

CREATE TABLE Follows
(
Id int Identity(1,1) primary key,
Publisher_Id int not null,
Subscriber_Id int not null,
FOREIGN KEY (Publisher_Id) REFERENCES Users(Id),
FOREIGN KEY (Subscriber_Id) REFERENCES Users(Id)
)
create database NightLifeHotelDB;

use NightLifeHotelDB;

Create table Rooms(
	Id uniqueidentifier primary key default NEWID(),
	Number int not null,
	Floor tinyint not null,
	IsVIP bit
)
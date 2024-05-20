-- create.sql

create database jarmu;

use jarmu;

create table Jarmuvek(
    Id int not null primary key auto_increment,
    Rendszam varchar(50),
    Marka varchar(50),
    Ar double
);
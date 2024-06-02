create database ManoExperta

GO
use ManoExperta

GO
create Table Provincia (
	ID smallint primary key,
	Nombre varchar(50) not null,
)
GO
create table Localidad(
	ID smallint primary key,
	Nombre varchar(50) not null,
	IDProvincia smallint not null references Provincia(ID)
)
GO
create table Personas(
	ID bigint primary key,
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Sexo char,
	FechaNacimiento DATE not null,
	Domicilio varchar(100) not null,
	IDLocalidad smallint not null references Localidad(ID)
)
GO
create table Roles (
	ID smallint primary key,
	NombreRol varchar(20) not null
)
GO
create table Usuarios(
	ID int identity(1,1) primary key,
	Usuario varchar(50) not null,
	Contrasenia varchar(50) not null,
	iDRol smallint not null references Roles(ID)
)
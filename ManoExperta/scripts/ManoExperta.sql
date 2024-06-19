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

GO
create table Roles (
	ID smallint primary key,
	NombreRol varchar(20) not null
)
GO
drop table Usuarios
create table Usuarios(
	ID int identity(1,1),
	Usuario varchar(50) not null,
	Contrasenia varchar(50) not null,
	iDRol smallint not null references Roles(ID),
	FechaAlta date not null, -- crear con SP
	Email varchar(255) not null,
	PRIMARY KEY (ID)
)


create table Personas(
	ID bigint primary key, --DNI o CUIL segun corresponda * se contempla solo hasta monotributistas en el caso de PRESTADORES
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Sexo char,
	FechaNacimiento DATE not null check(YEAR(FechaNacimiento) <= (YEAR(GETDATE()) - 18)),
	Domicilio varchar(100) not null,
	IDLocalidad smallint not null references Localidad(ID),
	IDUsuario int not null references Usuarios(ID)
)

create table Especialidades(
	ID int identity(1,1),
	Nombre varchar(50) not null,
	primary key(ID)
)

create table Especialidad_x_Prestador(
	ID_Persona bigint foreign key references Personas (ID),
	ID_Especialidad int foreign key references Especialidades (ID),
	primary key(ID_Persona, ID_Especialidad)
)
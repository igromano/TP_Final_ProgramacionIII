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
GO
--Nueva tabla con usuario y persona unificadas
create table Personas(
	ID int identity(1,1),
	Usuario varchar(50) not null unique,
	Contrasenia varchar(50) not null,
	iDRol smallint not null references Roles(ID),
	FechaAlta date not null, -- crear con SP
	Email varchar(255)  unique,
	IDPersona varchar(50) primary key, --DNI o CUIL segun corresponda
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Sexo char not null,
	FechaNacimiento DATE not null check(YEAR(FechaNacimiento) <= (YEAR(GETDATE()) - 18)),
	Domicilio varchar(100) not null,
	IDLocalidad smallint references Localidad(ID),
	Telefono varchar(100),
	Activo bit not null --Por default se crea con 1
)
GO
create table Especialidades(
	ID int identity(1,1),
	Nombre varchar(50) not null,
	primary key(ID)
)
GO
create table Especialidad_x_Prestador(
	ID_Persona varchar(50) foreign key references Personas (IDPersona),
	ID_Especialidad int foreign key references Especialidades (ID),
	primary key(ID_Persona, ID_Especialidad)
)
GO
create table Estados(
	ID smallint identity(1,1) primary key,
	Nombre varchar(50) not null
)
GO
create table Ticket(
	ID bigint identity(1000, 1) primary key,
	FechaSolicitado date not null,
	FechaRealizado date,
	IDUsuario varchar(50) foreign key references Personas (IDPersona),
	IDPrestador varchar(50) foreign key references Personas (IDPersona),
	IDEspecialidad int foreign key references Especialidades (ID),
	Monto money check(Monto >= 0),
	IDEstado smallint foreign key references Estados (ID),
	ComentarioUsuario varchar(1000),
	ComentarioPrestador varchar(1000),
	CONSTRAINT CK_ValidarFechas CHECK(FechaRealizado >= FechaSolicitado)
)

GO
--Rese�a (ID ticket, comentario del usuario)
create table Resenias(
	IDTicket bigint foreign key references Ticket (ID),
	Fecha date not null,
	Comentario varchar(1024),
	Calificacion smallint not null,
	primary key(IDTicket),
)

/*
drop table Resenias
drop table Ticket
drop table Especialidad_x_Prestador
drop table Personas
*/

--Creacion de SPs

--Creacion de un nuevo usuario
/*CREATE OR ALTER PROCEDURE SP_NuevoUsuario (
@Usuario varchar(50),
@Contrasenia varchar(50),
@IdRol smallint,
@Email varchar(255)
)
as
begin
declare @UsuarioExistente varchar(50)
	BEGIN TRY
	if @Usuario IN (SELECT u.Usuario from Personas u)
	begin 
		RAISERROR ('Este usuario ya existe', 16, 0)
	end
		INSERT Personas values(@Usuario, @Contrasenia, @IdRol, GETDATE(), @Email)
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
	END CATCH
end;*/

--Login en la aplicacion
ALTER PROCEDURE SP_Login(
@Usuario varchar(50),
@Contrasenia varchar(50)
)
as
begin
	begin try
		IF @Usuario NOT IN (SELECT U.Usuario from Personas U)
		BEGIN
			RAISERROR ('Usuario inexistente', 16, 0)
		END
		IF @Contrasenia != (SELECT U.Contrasenia from Personas U Where U.Usuario = @Usuario)
		BEGIN
			RAISERROR ('Contraseña incorrecta', 16, 0)
		END
		SELECT U.ID, U.iDRol FROM Personas U WHERE U.Usuario = @Usuario
	 end try
	 begin catch
		PRINT ERROR_MESSAGE()
	 end catch
end
exec SP_Login 'mamador', '123456'
---------------
SELECT * FROM Personas
exec SP_UpdateUser 2, 'Mamador', 'Mamador@Prestador.com', '123456', 'Marcelo', 'Amador', 'M', '1985-02-10', 'Larreta 456', 2, '54117889-5564'
exec SP_UpdateUser 1,'DMeltrozo', 'DMeltrozo@user.com', '777777', 'Deborah', 'Meltrozo', 'F', '1990-10-10', 'Los Troncos 123', 2, '54115566-4455'
---------------
--Update de Usuarios y/o Pesonas
CREATE OR ALTER PROCEDURE SP_UpdateUser (
@Id int = null, 
@Usuario varchar(50),
--@Contrasenia varchar(50),
@Email varchar(255),
--@Persona bit,
@IdPersona varchar(50),
@Nombre varchar(50),
@Apellido varchar(50),
@Sexo char(1),
@FechaNacimiento date,
@Domicilio varchar(100),
@IDLocalidad smallint,
@Telefono varchar(100)
) as
begin
	begin try
			begin
				update Personas set IDPersona = @IdPersona, Nombre = @Nombre, Apellido = @Apellido, Sexo = @Sexo, 
				FechaNacimiento = @FechaNacimiento, Domicilio = @Domicilio, IDLocalidad = @IDLocalidad,
				Telefono = @Telefono
				where ID = @Id
				PRINT('Se actualizo el usuario')
				RETURN
			end
	end try
	BEGIN CATCH
		PRINT ERROR_MESSAGE();
	END CATCH
end

--Calculo de reputacion de un prestador
CREATE OR ALTER PROCEDURE SP_CalculoReputacion (
@IDPersona varchar(50)
)AS
BEGIN
	BEGIN TRY
		IF @IDPersona = (SELECT p.IDPersona FROM Personas p where p.IDPersona = @IDPersona)
			BEGIN
			SELECT p.idpersona, (SUM(r.calificacion) / 
			(SELECT count(*) FROM resenias r
			inner join ticket t ON r.idticket = t.id
			WHERE t.idprestador = @IDPersona )) AS 'Reputacion' FROM ticket t
			inner join resenias r ON t.ID = r.IDTicket
			inner join Personas p ON t.idprestador = p.idpersona
			WHERE t.IDPrestador = @IDPersona
			GROUP BY p.idpersona
		END
		BEGIN
			RAISERROR('El prestador no existe!', 16, 1)
		END
		END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
	END CATCH
END
---------------
exec SP_CalculoReputacion '1132235'
select * from Ticket
select * from Resenias
select * from Personas
---------------------

exec SP_NuevoUsuario 'Mamador', '123456', 1, 'Mamador@Prestador.com', '123456'

--Creacion de un nuevo usuario
CREATE OR ALTER procedure SP_NuevoUsuario (
@Usuario varchar(50),
@Contrasenia varchar(50),
@IdRol smallint,
@Email varchar(255),
@IDPersona bigint,
@Nombre varchar(50) = '',
@Apellido varchar(50) = '',
@Sexo char = '',
@FechaNacimiento date = '1900-01-01',
@Domicilio varchar(100) = '',
@IDLocalidad smallint = null
)
as
begin
declare @UsuarioExistente varchar(50)
	BEGIN TRY
	if @Usuario IN (SELECT u.Usuario from Personas u)
	begin 
		RAISERROR ('Este usuario ya existe', 16, 0)
	end
		if @Email IN (SELECT u.Email from Personas u)
	begin 
		RAISERROR ('Este usuario ya existe', 16, 0)
	end
		INSERT Personas values(@Usuario, @Contrasenia, @IdRol, GETDATE(), @Email, @IDPersona, @Nombre, @Apellido, @Sexo, @FechaNacimiento, @Domicilio, @IDLocalidad, null ,1)
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
	END CATCH
end;

exec SP_CalculoReputacion '11322355'


CREATE OR ALTER PROCEDURE SP_CrearTicket (
@IdUsuario varchar(50),
@IdPrestador varchar(50),
@IdEspecialidad int,
@Monto money = null,
@IdEstado smallint,
@ComentarioUsuario varchar(1000)
) AS
BEGIN
	IF @IdPrestador = '0'
		SET @IdPrestador = null
	IF @IdEspecialidad = 0
		SET @IdEspecialidad = null
	INSERT INTO Ticket(IDUsuario, IDPrestador, IDEspecialidad, Monto, IDEstado, ComentarioUsuario, FechaSolicitado) 
	VALUES(@IdUsuario, @IdPrestador, @IdEspecialidad, @Monto, @IdEstado, @ComentarioUsuario, getdate())
END

exec SP_CrearTicket '777777', '123456', null, 0, 5,'hay olor a gas'

select * from Ticket

delete Ticket where Monto = 7700
select *  from Especialidades
select * from Personas
select * from Estados
select * from Localidad
select * from Provincia

SELECT l.ID AS 'ID_Localidad', l.Nombre AS 'Nombre', p.ID AS 'ID_Provincia', p.Nombre AS 'Nombre_Provincia' FROM Localidad l
inner join Provincia p ON l.IDProvincia = p.ID

exec SP_CalculoReputacion '1132235'
--Listado de Reputacion de prestadores 
SELECT (select avg(re.Calificacion) from Ticket t 
	inner join Resenias re on t.ID = re.IDTicket
	where t.IDPrestador = p.IDPersona
) AS 'Calificacion', *
FROM Personas p WHERE iDRol = 1 AND p.ID = 2


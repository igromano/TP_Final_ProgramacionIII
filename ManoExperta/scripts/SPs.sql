--Creacion de SPs

--Creacion de un nuevo usuario
CREATE procedure SP_NuevoUsuario (
@Usuario varchar(50),
@Contrasenia varchar(50),
@IdRol smallint,
@Email varchar(255)
)
as
begin
declare @UsuarioExistente varchar(50)
	BEGIN TRY
	if @Usuario IN (SELECT u.Usuario from Usuarios u)
	begin 
		RAISERROR ('Este usuario ya existe', 16, 0)
	end
		INSERT Usuarios values(@Usuario, @Contrasenia, @IdRol, GETDATE(), @Email)
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
	END CATCH
end;

--Login en la aplicacion
CREATE PROCEDURE SP_Login(
@Usuario varchar(50),
@Contrasenia varchar(50)
)
as
begin
	begin try
		IF @Usuario NOT IN (SELECT U.Usuario from Usuarios U)
		BEGIN
			RAISERROR ('Usuario inexistente', 16, 0)
		END
		IF @Contrasenia != (SELECT U.Contrasenia from Usuarios U Where U.Usuario = @Usuario)
		BEGIN
			RAISERROR ('Contraseña incorrecta', 16, 0)
		END
		SELECT u.iDRol FROM Usuarios U WHERE U.Usuario = @Usuario
	 end try
	 begin catch
		PRINT ERROR_MESSAGE()
	 end catch
end

--Update de Usuarios y/o Pesonas
alter procedure SP_UpdateUser (
@Id int = null, 
@Usuario varchar(50),
@Contrasenia varchar(50),
@Email varchar(255),
@Persona bit,
@IdPersona bigint = null,
@Nombre varchar(50) = null,
@Apellido varchar(50) = null,
@Sexo char(1) = null,
@FechaNacimiento date = null,
@Domicilio varchar(100) = null,
@IDLocalidad smallint = null
) as
begin
	begin try
		if @Id is not null and @Persona = 0
			begin 
				update Usuarios set Usuario = @Usuario, Contrasenia = @Contrasenia, Email = @Email where ID = @Id
				PRINT('Se edito solo el usuario')
				RETURN
			end
		if @Id is not null and @Persona = 1 and @IdPersona is not null
			begin
				update Usuarios set Usuario = @Usuario, Contrasenia = @Contrasenia, Email = @Email where ID = @Id
				update Personas set ID = @IdPersona, Nombre = @Nombre, Apellido = @Apellido, Sexo = @Sexo, 
				FechaNacimiento = @FechaNacimiento, Domicilio = @Domicilio, IDLocalidad = @IDLocalidad
				where IDUsuario = @Id
				PRINT('Se edito usuario y persona')
				RETURN
			end
		else
			begin
				RAISERROR('Datos insuficientes para realizar la actualización', 16, 0);
			end
	end try
	BEGIN CATCH
		PRINT ERROR_MESSAGE();
	END CATCH
end

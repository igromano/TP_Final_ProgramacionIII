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
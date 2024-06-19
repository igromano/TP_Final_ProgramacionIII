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


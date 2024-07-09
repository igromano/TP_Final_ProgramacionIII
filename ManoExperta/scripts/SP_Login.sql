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
		SELECT U.ID, U.iDRol, u.Contrasenia FROM Personas U WHERE U.Usuario = @Usuario
	 end try
	 begin catch
		PRINT ERROR_MESSAGE()
	 end catch
end
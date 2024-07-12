ALTER PROCEDURE SP_Login(
@Usuario varchar(50),
@Contrasenia varchar(50)
)
as
begin
DECLARE @error varchar(50)
	begin try
		IF @Usuario NOT IN (SELECT U.Usuario from Personas U)
		BEGIN
			RAISERROR ('Usuario inexistente', 16, 0)
		END
		IF @Contrasenia != (SELECT U.Contrasenia from Personas U Where U.Usuario = @Usuario)
		BEGIN
			RAISERROR ('Contraseņa incorrecta', 16, 0)
		END
		SELECT U.ID, U.iDRol, u.Contrasenia FROM Personas U WHERE U.Usuario = @Usuario
	 end try
	 begin catch
		SET @error = ERROR_MESSAGE()
		PRINT ERROR_MESSAGE()
		RAISERROR(@error, 16, 0);
	 end catch
end



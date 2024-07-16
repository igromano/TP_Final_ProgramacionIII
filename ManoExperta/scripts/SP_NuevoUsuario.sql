CREATE OR ALTER procedure SP_NuevoUsuario (
@Usuario varchar(50),
@Contrasenia varchar(50),
@IdRol smallint,
@Email varchar(255),
@IDPersona varchar(50),
@Nombre varchar(50) = '',
@Apellido varchar(50) = '',
@Sexo char = 'X',
@FechaNacimiento date = '1900-01-01',
@Domicilio varchar(100) = '',
@IDLocalidad smallint = null,
@Activo bit = 1
)
as
begin
declare @error varchar(70)
declare @UsuarioExistente varchar(50)
	BEGIN TRY
	if @Usuario IN (SELECT u.Usuario from Personas u)
	begin 
		RAISERROR ('Este usuario ya existe', 16, 0)
	end
		if @Email IN (SELECT u.Email from Personas u)
	begin 
		RAISERROR ('Este correo ya se encuentra registrado', 16, 0)
	end
		INSERT Personas values(@Usuario, @Contrasenia, @IdRol, GETDATE(), @Email, @IDPersona, @Nombre, @Apellido, @Sexo, @FechaNacimiento, @Domicilio, @IDLocalidad, null ,@Activo)
	END TRY
	BEGIN CATCH
		SET @error = ERROR_MESSAGE()
		RAISERROR (@error, 16, 0)
	END CATCH
end;
select * from Personas
exec SP_NuevoUsuario 'mel', 'mel123',2,'melPatino@mail.com','456789','Mel', 'Patiño', '','','',1
CREATE OR ALTER PROCEDURE SP_UpdateUser (
@Id int = null, 
@Usuario varchar(50),
@Email varchar(255),
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
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
@Telefono varchar(100),
@IDEspecialidad int = 0,
@Contrasenia varchar(50)
) as
begin
	begin try
			begin
				update Personas set IDPersona = @IdPersona, Nombre = @Nombre, Apellido = @Apellido, Sexo = @Sexo, 
				FechaNacimiento = @FechaNacimiento, Domicilio = @Domicilio, IDLocalidad = @IDLocalidad,
				Telefono = @Telefono, Contrasenia = @Contrasenia
				where ID = @Id
				IF @IDEspecialidad != 0 AND @IdPersona NOT IN(SELECT ep.ID_Persona FROM Especialidad_x_Prestador ep)
					BEGIN
						INSERT INTO Especialidad_x_Prestador VALUES(@IdPersona, @IDEspecialidad)
					END
				PRINT('Se actualizo el usuario')
				RETURN
			end
	end try
	BEGIN CATCH
		PRINT ERROR_MESSAGE();
	END CATCH
end

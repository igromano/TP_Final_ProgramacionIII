--Actalizacion de tickets
CREATE OR ALTER PROCEDURE SP_UpdateTicket(
@ID bigint,
@FechaRealizado date = null,
@IDPrestador varchar (50) = null,
@IDEspecialidad int,
@Monto money,
@IDEstado smallint,
@ComentarioUsuario varchar(1000),
@ComentarioPrestador varchar(1000),
@IDUsrAprobacion varchar(50) = null
) AS
BEGIN
	BEGIN TRY
		UPDATE Ticket SET FechaRealizado = @FechaRealizado, IDPrestador = @IDPrestador, IDEspecialidad = @IDEspecialidad,	
			Monto = @Monto, IDEstado = @IDEstado, ComentarioUsuario = @ComentarioUsuario, ComentarioPrestador = @ComentarioPrestador, IDUsrAprobacion = @IDUsrAprobacion
			where ID = @ID
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
		RAISERROR('Error al actualizar ticket', 16, 0);
	END CATCH
END


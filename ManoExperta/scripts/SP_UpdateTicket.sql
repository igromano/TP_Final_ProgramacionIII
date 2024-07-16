--Actalizacion de tickets
CREATE OR ALTER PROCEDURE SP_UpdateTicket(
@ID bigint,
--@FechaRealizado date,
@IDPrestador varchar (50) = '',
@IDEspecialidad int,
@Monto money,
--@IDEstado smallint,
@ComentarioUsuario varchar(1000),
@ComentarioPrestador varchar(1000)
--@IDUsrAprobacion varchar(50)
) AS
BEGIN
	BEGIN TRY
		UPDATE Ticket SET IDPrestador = @IDPrestador, IDEspecialidad = @IDEspecialidad,	
			Monto = @Monto, ComentarioUsuario = @ComentarioUsuario, ComentarioPrestador = @ComentarioPrestador
			where ID = @ID
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
		RAISERROR('Error al actualizar ticket', 16, 0);
	END CATCH
END
CREATE OR ALTER PROCEDURE SP_CrearTicket (
@IdUsuario varchar(50),
@IdPrestador varchar(50),
@IdEspecialidad int,
@Monto money = null,
@IdEstado smallint,
@ComentarioUsuario varchar(1000)
) AS
BEGIN
	IF @IdPrestador = '0'
		SET @IdPrestador = null
	IF @IdEspecialidad = 0
		SET @IdEspecialidad = null
	INSERT INTO Ticket(IDUsuario, IDPrestador, IDEspecialidad, Monto, IDEstado, ComentarioUsuario, FechaSolicitado) 
	VALUES(@IdUsuario, @IdPrestador, @IdEspecialidad, @Monto, @IdEstado, @ComentarioUsuario, getdate())

END
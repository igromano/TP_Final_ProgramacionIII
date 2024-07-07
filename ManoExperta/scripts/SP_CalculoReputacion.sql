CREATE OR ALTER PROCEDURE SP_CalculoReputacion (
@IDPersona varchar(50)
)AS
BEGIN
	BEGIN TRY
		IF @IDPersona = (SELECT p.IDPersona FROM Personas p where p.IDPersona = @IDPersona)
			BEGIN
			SELECT p.idpersona, (SUM(r.calificacion) / 
			(SELECT count(*) FROM resenias r
			inner join ticket t ON r.idticket = t.id
			WHERE t.idprestador = @IDPersona )) AS 'Reputacion' FROM ticket t
			inner join resenias r ON t.ID = r.IDTicket
			inner join Personas p ON t.idprestador = p.idpersona
			WHERE t.IDPrestador = @IDPersona
			GROUP BY p.idpersona
		END
		BEGIN
			RAISERROR('El prestador no existe!', 16, 1)
		END
		END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
	END CATCH
END
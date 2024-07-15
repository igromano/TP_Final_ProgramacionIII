CREATE OR ALTER VIEW VW_VerTickets
AS
SELECT        t.ID AS ID_Ticket, t.IDUsuario AS ID_Usuario, pe.ID AS ID_Usr_Cliente, t.IDUsrAprobacion AS ID_Usr_Aprobacion, pe.Apellido AS Usr_Apellido, pe.Nombre AS Usr_Nombre, pe.Domicilio AS Usr_Domicilio, 
                         pe.IDLocalidad AS ID_Localidad_Trabajo, lo.IDProvincia AS ID_Provincia_Trabajo, pr.ID AS ID_Usr_Prestador, pr.IDPersona AS ID_Prestador, pr.Apellido AS Pres_Apellido, pr.Nombre AS Pres_Nombre, es.ID AS ID_Especialidad, 
                         es.Nombre AS Especialidad, t.Monto, e.ID AS ID_Estado, e.Nombre AS Estado, t.ComentarioUsuario AS Usr_Comentarios, t.ComentarioPrestador AS Pres_Comentarios, t.FechaSolicitado AS Fecha_Solicitado, 
                         t.FechaRealizado AS Fecha_Realizado, re.Comentario AS Res_Comentario, CASE WHEN re.Calificacion IS NULL THEN 0 ELSE re.Calificacion END AS Calificacion, re.Fecha AS Fecha_Res
FROM            dbo.Ticket AS t INNER JOIN
                         dbo.Personas AS pe ON t.IDUsuario = pe.IDPersona LEFT OUTER JOIN
                         dbo.Personas AS pr ON t.IDPrestador = pr.IDPersona LEFT OUTER JOIN
                         dbo.Especialidades AS es ON t.IDEspecialidad = es.ID INNER JOIN
                         dbo.Estados AS e ON t.IDEstado = e.ID LEFT OUTER JOIN
                         dbo.Resenias AS re ON t.ID = re.IDTicket INNER JOIN
                         dbo.Localidad AS lo ON pe.IDLocalidad = lo.ID


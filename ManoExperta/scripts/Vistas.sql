CREATE OR ALTER VIEW VW_VerTickets
AS
SELECT t.ID AS 'ID_Ticket', 
t.IDUsuario AS 'ID_Usuario', pe.ID AS 'ID_Usr_Cliente',pe.Apellido AS 'Usr_Apellido', pe.Nombre AS 'Usr_Nombre', pe.Domicilio 'Usr_Domicilio', pe.IDLocalidad AS 'ID_Localidad_Trabajo', lo.IDProvincia AS 'ID_Provincia_Trabajo',
pr.ID AS 'ID_Usr_Prestador', pr.IDPersona AS 'ID_Prestador', pr.Apellido AS 'Pres_Apellido', pr.Nombre AS 'Pres_Nombre',
es.ID AS 'ID_Especialidad', es.Nombre AS 'Especialidad',
t.Monto,
e.ID AS 'ID_Estado', e.Nombre AS 'Estado',
t.ComentarioUsuario AS 'Usr_Comentarios', t.ComentarioPrestador AS 'Pres_Comentarios',
t.fechaSolicitado AS 'Fecha_Solicitado', t.FechaRealizado AS 'Fecha_Realizado',
re.Comentario AS 'Res_Comentario', --re.Calificacion AS 'Calificacion',
CASE  WHEN re.Calificacion IS NULL THEN 0 ELSE re.Calificacion END AS 'Calificacion',
re.fecha AS 'Fecha_Res'
FROM Ticket t
INNER JOIN Personas pe ON t.IDUsuario = pe.IDPersona
LEFT JOIN Personas pr ON t.IDPrestador = pr.IDPersona
LEFT JOIN Especialidades es ON t.IDEspecialidad = es.ID
INNER JOIN Estados e ON t.IDEstado = e.ID
LEFT JOIN Resenias re ON t.ID = re.IDTicket
INNER JOIN Localidad lo ON pe.IDLocalidad = lo.ID


select * from Personas where iDRol = 0
select * from Estados
select * from Personas
select * from Localidad l inner join Provincia p on l.IDProvincia = p.ID
select * from VW_VerTickets


--Script de inserts
INSERT Roles values(0, 'ADMIN')
INSERT Roles values(1, 'PRESTADOR')
INSERT Roles values(2, 'USUARIO')

--Agregar Espcialidades
INSERT INTO Especialidades VALUES('PLOMERIA')
INSERT INTO Especialidades VALUES('ELECTRICIDAD')
INSERT INTO Especialidades VALUES('GASISTA')
INSERT INTO Especialidades VALUES('HERRERIA')


--Agregar Usuarios
INSERT INTO Usuarios values('JPerez', '123456', 1, getdate(), 'JPerez@ManoExperta.com')
INSERT INTO Usuarios values('PGomez', '123456', 1, getdate(), 'PGomez@ManoExperta.com')
INSERT INTO Usuarios values('SSegura', '123456', 1, getdate(), 'SSegura@ManoExperta.com')
INSERT INTO Usuarios values('ARoca', '123456', 1, getdate(), 'ARoca@ManoExperta.com')
INSERT INTO Usuarios values('EQuito', '123456', 1, getdate(), 'EQuito@ManoExperta.com')
INSERT INTO Usuarios values('EJinon', '123456', 1, getdate(), 'EJinon@ManoExperta.com')

--Agregar provincias
INSERT INTO Provincia VALUES(2, 'Buenos Aires')

--Agregar Localidades
INSERT INTO Localidad VALUES(2, 'San Isidro', 2)
INSERT INTO Localidad VALUES(3, 'Burzaco', 2)
INSERT INTO Localidad VALUES(4, 'Tigre', 2)
INSERT INTO Localidad VALUES(5, 'Pilar', 2)
INSERT INTO Localidad VALUES(6, 'Moreno', 2)
INSERT INTO Localidad VALUES(7, 'Vicente Lopez', 2)
INSERT INTO Localidad VALUES(8, 'San Martin', 2)

--Agregar Personas
INSERT INTO Personas VALUES(2354564, 'Juan', 'Perez', 'M', '1990-02-15', 'Laverta 2231', 2, 10)
INSERT INTO Personas VALUES(3323235, 'Pedro', 'Gomez', 'M', '1992-11-13', 'San Martin 45', 3, 11)
INSERT INTO Personas VALUES(1233549, 'Santiago', 'Segura', 'M', '1987-07-02', 'Elcano 354', 6, 12)
INSERT INTO Personas VALUES(1132235, 'Alberto', 'Roca', 'M', '1970-08-23', 'San Esteban 556', 5, 13)
INSERT INTO Personas VALUES(3544564, 'Esteban', 'Quito', 'M', '2000-02-19', 'Peron 246', 8, 14)
INSERT INTO Personas VALUES(3022132, 'Elba', 'Jinon', 'F', '1994-12-05', 'Campos 454', 7, 10)

--Agregar Especialidades por prestador
INSERT INTO Especialidad_x_Prestador VALUES('2354564', 1)
INSERT INTO Especialidad_x_Prestador VALUES('2354564', 3)
INSERT INTO Especialidad_x_Prestador VALUES('3544564', 2)
INSERT INTO Especialidad_x_Prestador VALUES('3323235', 4)
INSERT INTO Especialidad_x_Prestador VALUES('1132235', 2)
INSERT INTO Especialidad_x_Prestador VALUES('1233549', 2)

--Agregar estados
INSERT INTO Estados VALUES('EN PREOCESO')
INSERT INTO Estados VALUES('SOLICITADO')
INSERT INTO Estados VALUES('CANCELADO')
INSERT INTO Estados VALUES('REALIZADO')

--Agregar Personas
INSERT INTO Personas1 VALUES('JPerez', '123456', 1, getdate(), 'JPerez@ManoExperta.com', '2354564', 'Juan', 'Perez', 'M', '1990-02-15', 'Laverta 2231', 2, 1)
INSERT INTO Personas1 VALUES('PGomez', '123456', 1, getdate(), 'PGomez@ManoExperta.com', '3323235', 'Pedro', 'Gomez', 'M', '1992-11-13', 'San Martin 45', 3, 1)
INSERT INTO Personas1 VALUES('SSegura', '123456', 1, getdate(), 'SSegura@ManoExperta.com', '1233549', 'Santiago', 'Segura', 'M', '1987-07-02', 'Elcano 354', 6, 1)
INSERT INTO Personas1 VALUES('ARoca', '123456', 1, getdate(), 'ARoca@ManoExperta.com', '1132235', 'Alberto', 'Roca', 'M', '1970-08-23', 'San Esteban 556', 5, 1)
INSERT INTO Personas1 VALUES('EQuito', '123456', 1, getdate(), 'EQuito@ManoExperta.com', '3544564', 'Esteban', 'Quito', 'M', '2000-02-19', 'Peron 246', 8, 1)
INSERT INTO Personas1 VALUES('EJinon', '123456', 1, getdate(), 'EJinon@ManoExperta.com', '3022132', 'Elba', 'Jinon', 'F', '1994-12-05', 'Campos 454', 7, 1)

INSERT INTO Personas1 VALUES('admin', 'admin', 0, getdate(), 'admin@ManoExperta.com', '12345678', 'admin', 'admin', 'M', '1990-02-05', 'Formica 77', 2, 1)
INSERT INTO Personas1 VALUES('user', 'user', 1, getdate(), 'user@ManoExperta.com', '11111111', 'user', 'user', 'M', '1990-02-06', 'San Pedro 452', 2, 1)
INSERT INTO Personas1 VALUES('user1', 'user1', 1, getdate(), 'user1@ManoExperta.com', '22222222', 'user1', 'user1', 'M', '1990-02-07', 'Josecito 11', 2, 1)

delete Personas1 where email like '%manoexperta%'

select * from ticket
select * from estados
select * from Roles
select * from Especialidades
select * from Especialidad_x_Prestador
select * from Personas1
select p.idpersona, p.nombre, p.apellido, e.Nombre, e.ID  from Personas1 p
inner join Especialidad_x_Prestador ep on p.IDPersona = ep.ID_Persona
inner join Especialidades e on ep.ID_Especialidad = e.ID
delete ticket
update ticket set Comentario = 'Trabajo finalizado' where IDPrestador = '1132235'

--Se insertan tickets en estado SOLICITADO
INSERT INTO Ticket VALUES('11111111', '1132235', 2, 2600, 2, '', '')
INSERT INTO Ticket VALUES('11111111', '2354564', 1, 400, 2, '', '')
INSERT INTO Ticket VALUES('11111111', '1132235', 2, 7000, 2, '', '')
INSERT INTO Ticket VALUES('11111111', '1132235', 2, 12000, 2, '', '')
INSERT INTO Ticket VALUES('22222222', '3323235', 4, 800, 2, '', '')
INSERT INTO Ticket VALUES('22222222', '1132235', 2, 5500, 2, '', '')
INSERT INTO Ticket VALUES('22222222', NULL, NULL, 0, 2, '', '')

update Ticket set IDPrestador = '1132235', IDEspecialidad = 4 where id = 1006

--Se insertan reseñas
INSERT INTO Resenias VALUES(1000, 'Es un croto, vino con olor a culo a trabajar', 3)
INSERT INTO Resenias VALUES(1001, 'Esta vez se baño, buen trabajo', 5)
INSERT INTO Resenias VALUES(1002, 'Lo dejo peor que antes', 1)
INSERT INTO Resenias VALUES(1003, 'Quedo solucionado!', 4)
INSERT INTO Resenias VALUES(1004, 'Resuelto', 4)
INSERT INTO Resenias VALUES(1005, 'todo OK', 5)

select * from ticket
select * from resenias
--Query para calcular la reputacion del prestador
SELECT p.idpersona, (SUM(r.calificacion) / 
(SELECT count(*) FROM resenias r
inner join ticket t ON r.idticket = t.id
WHERE t.idprestador = '1' )) AS 'Reputacion' FROM ticket t
inner join resenias r ON t.ID = r.IDTicket
inner join Personas1 p ON t.idprestador = p.idpersona
WHERE t.IDPrestador = '1'
GROUP BY p.idpersona


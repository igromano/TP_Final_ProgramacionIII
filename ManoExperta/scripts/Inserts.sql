--Script de inserts
INSERT Roles values(0, 'ADMIN')
INSERT Roles values(1, 'PRESTADOR')
INSERT Roles values(2, 'USUARIO')

--Agregar Espcialidades
INSERT INTO Especialidades VALUES('SIN ESPECIALIDAD')
INSERT INTO Especialidades VALUES('PLOMERIA')
INSERT INTO Especialidades VALUES('ELECTRICIDAD')
INSERT INTO Especialidades VALUES('GASISTA')
INSERT INTO Especialidades VALUES('HERRERIA')
INSERT INTO Especialidades VALUES('JARDINERIA')
INSERT INTO Especialidades VALUES('COMPUTACION')
INSERT INTO Especialidades VALUES('ALBAÑILERIA')
INSERT INTO Especialidades VALUES('REFRIGERACION')
INSERT INTO Especialidades VALUES('ELECTRODOMESTICOS')
INSERT INTO Especialidades VALUES('CERRAJERIA')
INSERT INTO Especialidades VALUES('CARPINTERIA')
INSERT INTO Especialidades VALUES('MECANICA GENERAL')

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
INSERT INTO Localidad VALUES(9, 'La Plata', 2)
INSERT INTO Localidad VALUES(10, 'San Fernando', 2)
INSERT INTO Localidad VALUES(11, 'Monte Grande', 2)
INSERT INTO Localidad VALUES(12, 'Capital Federal', 2)
INSERT INTO Localidad VALUES(13, 'Pacheco', 2)
INSERT INTO Localidad VALUES(14, 'San Miguel', 2)
INSERT INTO Localidad VALUES(15, 'Ituzaingo', 2)

--Agregar Especialidades por prestador
INSERT INTO Especialidad_x_Prestador VALUES('2354564', 1)
INSERT INTO Especialidad_x_Prestador VALUES('2354564', 3)
INSERT INTO Especialidad_x_Prestador VALUES('3544564', 2)
INSERT INTO Especialidad_x_Prestador VALUES('3323235', 4)
INSERT INTO Especialidad_x_Prestador VALUES('1132235', 2)
INSERT INTO Especialidad_x_Prestador VALUES('1233549', 2)

--Agregar estados
INSERT INTO Estados VALUES('EN PROCESO')
INSERT INTO Estados VALUES('SOLICITADO')
INSERT INTO Estados VALUES('CANCELADO')
INSERT INTO Estados VALUES('REALIZADO')
INSERT INTO Estados VALUES('A ASIGNAR')

--Agregar Personas
INSERT INTO Personas VALUES('JPerez', '123456', 1, getdate(), 'JPerez@ManoExperta.com', '2354564', 'Juan', 'Perez', 'M', '1990-02-15', 'Laverta 2231', 2, 1, '12345645')
INSERT INTO Personas VALUES('PGomez', '123456', 1, getdate(), 'PGomez@ManoExperta.com', '3323235', 'Pedro', 'Gomez', 'M', '1992-11-13', 'San Martin 45', 3, 1, '12345645')
INSERT INTO Personas VALUES('SSegura', '123456', 1, getdate(), 'SSegura@ManoExperta.com', '1233549', 'Santiago', 'Segura', 'M', '1987-07-02', 'Elcano 354', 6, 1, '12345645')
INSERT INTO Personas VALUES('ARoca', '123456', 1, getdate(), 'ARoca@ManoExperta.com', '1132235', 'Alberto', 'Roca', 'M', '1970-08-23', 'San Esteban 556', 5, 1, '12345645')
INSERT INTO Personas VALUES('EQuito', '123456', 1, getdate(), 'EQuito@ManoExperta.com', '3544564', 'Esteban', 'Quito', 'M', '2000-02-19', 'Peron 246', 8, 1, '12345645')
INSERT INTO Personas VALUES('admin', 'admin', 0, getdate(), 'admin@ManoExperta.com', '12345678', 'admin', 'admin', 'M', '1990-02-05', 'Formica 77', 2, 1, '12345645')
INSERT INTO Personas VALUES('user', 'user', 1, getdate(), 'user@ManoExperta.com', '11111111', 'user', 'user', 'M', '1990-02-06', 'San Pedro 452', 2, 1, '12345645')
INSERT INTO Personas VALUES('user1', 'user1', 1, getdate(), 'user1@ManoExperta.com', '22222222', 'user1', 'user1', 'M', '1990-02-07', 'Josecito 11', 2, 1, '12345645')


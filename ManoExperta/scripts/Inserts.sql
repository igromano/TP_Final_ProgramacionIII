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
INSERT INTO Especialidad_x_Prestador VALUES(2354564, 1)
INSERT INTO Especialidad_x_Prestador VALUES(2354564, 3)
INSERT INTO Especialidad_x_Prestador VALUES(3544564, 2)
INSERT INTO Especialidad_x_Prestador VALUES(3323235, 4)
INSERT INTO Especialidad_x_Prestador VALUES(1132235, 2)
INSERT INTO Especialidad_x_Prestador VALUES(1233549, 2)

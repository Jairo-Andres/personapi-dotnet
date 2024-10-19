-- Insertar datos de prueba en la tabla persona
INSERT INTO persona_db.dbo.persona (cc, nombre, apellido, genero, edad) VALUES
(123456, 'Juan', 'Perez', 'M', 22),
(234567, 'Julian', 'Lopez', 'M', 23),
(345678, 'Juliana', 'Pinto', 'F', 21);

-- Insertar datos de prueba en la tabla profesion
INSERT INTO persona_db.dbo.profesion (id, nom, des) VALUES
(1, 'Ingeniero de Sistemas', 'Desarrolla soluciones de software'),
(2, 'Reportero', 'Informa sobre hechos de la actualidad'),
(3, 'Médico', 'Trata enfermedades');

-- Insertar datos de prueba en la tabla estudios
INSERT INTO persona_db.dbo.estudios (id_prof, cc_per, fecha, univer) VALUES
(1, 123456, '2019-01-01', 'Universidad Nacional'),
(2, 234567, '2020-01-01', 'Universidad Javeriana'),
(3, 345678, '2021-01-01', 'Universidad de los Andes');

-- Insertar datos de prueba en la tabla telefono
INSERT INTO persona_db.dbo.telefono (num, oper, dueno) VALUES
('3223654789', 'Claro', 123456),
('3145792456', 'Movistar', 234567),
('3159287754', 'Tigo', 345678);
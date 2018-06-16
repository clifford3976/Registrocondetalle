CREATE DATABASE PersonasDb
GO
USE PersonasDb
GO
CREATE TABLE Personas
(
	PersonaId int primary key identity(1,1),
	Fecha datetime,
	Nombre varchar(30),
	Telefono varchar(13),
	Cedula varchar(13),
	Direccion varchar(max)
);
create database prueba

Create table Usuarios
(IdUsuario int primary KEY identity(1, 1),
 Nombre	nvarchar(100) NOT NULL,
 FechaNacimento Datetime,
 Sexo	nvarchar(1) NOT NULL)
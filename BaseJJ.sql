/*creacion BD*/
USE master;  
GO  
CREATE DATABASE BibliotecaJJ 

/*creacion tablas*/
CREATE TABLE Autor (
Id_Autor INT PRIMARY KEY IDENTITY,
Nombre_Autor NVARCHAR(50)NOT NULL
);

CREATE TABLE Materia (
Id_Materia INT PRIMARY KEY IDENTITY NOT NULL,
Nombre_Materia NVARCHAR(50) NOT NULL
);

CREATE TABLE Users_Rol (
Id_Users_Rol INT PRIMARY KEY IDENTITY NOT NULL,
Nombre_Users NVARCHAR(50) NOT NULL
);

CREATE TABLE Genero (
Id_Genero INT PRIMARY KEY IDENTITY,
Nombre_Genero NVARCHAR(50) NOT NULL
);

CREATE TABLE Estado_Civil (
Id_Estado_Civil INT PRIMARY KEY IDENTITY,
Nombre_Estado_Civil NVARCHAR(50) NOT NULL
);

CREATE TABLE Estado (
Id_Estado INT PRIMARY KEY IDENTITY,
Nombre_Estado NVARCHAR(50) NOT NULL
);

CREATE TABLE Tipo_Libro (
Id_Tipo_Libro INT PRIMARY KEY IDENTITY,
Nombre_Tipo_Libro NVARCHAR(50) NOT NULL
);

CREATE TABLE Categoria_Edad (
Id_Categoria_Edad INT PRIMARY KEY IDENTITY,
Nombre_Categoria NVARCHAR(50) NOT NULL
);

CREATE TABLE Libro (
Id_Libro INT PRIMARY KEY IDENTITY,
Id_Autor INT REFERENCES AUTOR(Id_Autor),
Id_Estado INT REFERENCES Estado(Id_Estado),
Id_Tipo_Libro INT REFERENCES Tipo_Libro(Id_Tipo_Libro),
Id_Categoria_Edad INT REFERENCES Categoria_Edad (Id_Categoria_Edad),
Titulo NVARCHAR(50)NOT NULL,
Materia INT REFERENCES Materia(Id_Materia),
);

CREATE TABLE Users (
Id_Usuario INT PRIMARY KEY IDENTITY,
Id_Genero INT REFERENCES Genero(Id_Genero),
Id_Estado_Civil INT REFERENCES Estado_Civil(Id_Estado_Civil),
Id_Users_Rol INT REFERENCES Users_Rol(Id_Users_Rol),
Nombre_Usuario NVARCHAR(50) NOT NULL,
Apellido_Usuario NVARCHAR(50) NOT NULL,
Cedula_Usuario NVARCHAR(50) NOT NULL,
UserName NVARCHAR(50) NOT NULL,
Fecha_Nacimiento DATE NOT NULL,
Direccion NVARCHAR(50) NOT NULL,
UserPassword NVARCHAR(50) NOT NULL
);

CREATE TABLE Prestamo (
Id_Prestamo INT PRIMARY KEY IDENTITY,
Id_Usuario INT REFERENCES Users(Id_Usuario),
Id_Libro INT REFERENCES Libro(Id_Libro),
id_Estudiante INT REFERENCES EstudianteJJ(id_Estudiante) NOT NULL ,
Fecha_Prestamo DATE DEFAULT getDate() NOT NULL,
Tiempo_Prestamo NVARCHAR(50) NOT NULL,
Observaciones NVARCHAR(500) NOT NULL
);


CREATE TABLE EstudianteJJ(
id_Estudiante INT PRIMARY KEY IDENTITY NOT NULL,
cedula NVARCHAR(10) NOT NULL,
nombre NVARCHAR(150) NOT NULL,
direccion NVARCHAR(250) NOT NULL,
email  NVARCHAR(35) NOT NULL,
telefono NVARCHAR(9),
id_Carrera INT REFERENCES CarreraJJ(id_Carrera) NOT NULL,
estado CHAR(1) NOT NULL
);

CREATE TABLE CarreraJJ(
id_Carrera INT PRIMARY KEY IDENTITY NOT NULL,
id_Facultad INT REFERENCES FacultadJJ(id_Facultad) NOT NULL,
nombre NVARCHAR(100) NOT NULL,
estado CHAR(1) NOT NULL
);

CREATE TABLE  FacultadJJ (
id_Facultad INT PRIMARY KEY IDENTITY NOT NULL,
nombre NVARCHAR(150) NOT NULL,
estado NVARCHAR(1) NOT NULL
);
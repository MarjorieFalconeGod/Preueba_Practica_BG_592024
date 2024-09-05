-- Tabla para almacenar los usuarios (instructores y estudiantes)
--CREATE DATABASE BG_592024;
--GO

USE BG_Marjorie_Falcone;
GO

CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100),
    Email NVARCHAR(150) UNIQUE NOT NULL,
    Contrase�a NVARCHAR(255) NOT NULL,
    Rol NVARCHAR(50) CHECK (Rol IN ('Instructor', 'Estudiante')) NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE()
);

-- Tabla para almacenar los cursos
CREATE TABLE Cursos (
    IdCurso INT IDENTITY(1,1) PRIMARY KEY,
    IdInstructor INT,
    Titulo NVARCHAR(255) NOT NULL,
    Descripcion NVARCHAR(MAX),
    Duracion INT NOT NULL, -- en horas
    Cronograma NVARCHAR(MAX),
    FOREIGN KEY (IdInstructor) REFERENCES Usuarios(IdUsuario) ON DELETE CASCADE
);

-- Tabla para almacenar los materiales educativos
CREATE TABLE Materiales (
    IdMaterial INT IDENTITY(1,1) PRIMARY KEY,
    IdCurso INT,
    TipoMaterial NVARCHAR(50) CHECK (TipoMaterial IN ('Video', 'Documento', 'Cuestionario')) NOT NULL,
    UrlMaterial NVARCHAR(500) NOT NULL,
    Descripcion NVARCHAR(MAX),
    FOREIGN KEY (IdCurso) REFERENCES Cursos(IdCurso) 
);

-- Tabla para las inscripciones de estudiantes a los cursos
CREATE TABLE Inscripciones (
    IdInscripcion INT IDENTITY(1,1) PRIMARY KEY,
    IdCurso INT,
    IdEstudiante INT,
    FechaInscripcion DATETIME DEFAULT GETDATE(),
    Progreso FLOAT DEFAULT 0,
    FOREIGN KEY (IdCurso) REFERENCES Cursos(IdCurso) ,
    FOREIGN KEY (IdEstudiante) REFERENCES Usuarios(IdUsuario) 
);

-- Tabla para el progreso de actividades de los estudiantes
CREATE TABLE Actividades (
    IdActividad INT IDENTITY(1,1) PRIMARY KEY,
    IdCurso INT,
    IdEstudiante INT,
    Titulo NVARCHAR(255),
    TipoActividad NVARCHAR(50) CHECK (TipoActividad IN ('Cuestionario', 'Proyecto')) NOT NULL,
    Calificacion DECIMAL(5, 2) DEFAULT NULL,
    Retroalimentacion NVARCHAR(MAX),
    FechaEntrega DATETIME DEFAULT NULL,
    FOREIGN KEY (IdCurso) REFERENCES Cursos(IdCurso) ,
    FOREIGN KEY (IdEstudiante) REFERENCES Usuarios(IdUsuario) 
);

-- Tabla para los certificados de finalizaci�n
CREATE TABLE Certificados (
    IdCertificado INT IDENTITY(1,1) PRIMARY KEY,
    IdCurso INT,
    IdEstudiante INT,
    FechaEmision DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IdCurso) REFERENCES Cursos(IdCurso) ,
    FOREIGN KEY (IdEstudiante) REFERENCES Usuarios(IdUsuario) 
);

-- Tabla para las notificaciones a los estudiantes
CREATE TABLE Notificaciones (
    IdNotificacion INT IDENTITY(1,1) PRIMARY KEY,
    IdEstudiante INT,
    Mensaje NVARCHAR(MAX),
    FechaEnvio DATETIME DEFAULT GETDATE(),
    Leida BIT DEFAULT 0,
    FOREIGN KEY (IdEstudiante) REFERENCES Usuarios(IdUsuario) 
);

INSERT INTO Usuarios (Nombre, Apellido, Email, Contrase�a, Rol) VALUES
('Juan', 'P�rez', 'juan.perez@example.com', 'hashedpassword1', 'Instructor'),
('Mar�a', 'G�mez', 'maria.gomez@example.com', 'hashedpassword2', 'Estudiante'),
('Carlos', 'L�pez', 'carlos.lopez@example.com', 'hashedpassword3', 'Instructor'),
('Ana', 'Torres', 'ana.torres@example.com', 'hashedpassword4', 'Estudiante'),
('Luis', 'Mart�nez', 'luis.martinez@example.com', 'hashedpassword5', 'Estudiante');

INSERT INTO Cursos (IdInstructor, Titulo, Descripcion, Duracion, Cronograma) VALUES
(1, 'Curso de Python', 'Aprende Python desde cero', 40, 'Lunes y Mi�rcoles 18:00-20:00'),
(1, 'Curso de SQL Avanzado', 'Aprende t�cnicas avanzadas en SQL', 30, 'Martes y Jueves 19:00-21:00'),
(3, 'Curso de Dise�o Gr�fico', 'Introducci�n al dise�o gr�fico con herramientas modernas', 50, 'S�bados 10:00-14:00'),
(3, 'Curso de Marketing Digital', 'Estrategias de marketing digital para negocios', 20, 'Viernes 17:00-19:00'),
(1, 'Curso de Desarrollo Web', 'Desarrollo de aplicaciones web con JavaScript', 45, 'Lunes y Viernes 16:00-18:00');

INSERT INTO Materiales (IdCurso, TipoMaterial, UrlMaterial, Descripcion) VALUES
(1, 'Video', 'https://example.com/python_intro.mp4', 'Introducci�n a Python'),
(1, 'Documento', 'https://example.com/python_doc.pdf', 'Gu�a r�pida de Python'),
(2, 'Cuestionario', 'https://example.com/sql_quiz', 'Cuestionario de conceptos b�sicos de SQL'),
(3, 'Video', 'https://example.com/design_intro.mp4', 'Introducci�n al dise�o gr�fico'),
(5, 'Documento', 'https://example.com/web_development_guide.pdf', 'Gu�a de desarrollo web con JavaScript');

INSERT INTO Inscripciones (IdCurso, IdEstudiante) VALUES
(1, 2),
(2, 2),
(3, 4),
(4, 5),
(5, 5);

INSERT INTO Actividades (IdCurso, IdEstudiante, Titulo, TipoActividad, Calificacion, Retroalimentacion, FechaEntrega) VALUES
(1, 2, 'Ejercicio 1 - Variables', 'Cuestionario', 85.5, 'Buen trabajo', '2024-09-03 15:00:00'),
(2, 2, 'Proyecto final SQL', 'Proyecto', 90.0, 'Excelente manejo de consultas avanzadas', '2024-09-04 14:00:00'),
(3, 4, 'Proyecto dise�o gr�fico', 'Proyecto', 88.0, 'Buen uso de herramientas', '2024-09-05 16:00:00'),
(4, 5, 'Cuestionario 1 - Marketing', 'Cuestionario', 80.5, 'Correcto, pero puede mejorar', '2024-09-06 10:00:00'),
(5, 5, 'Proyecto final desarrollo web', 'Proyecto', 92.0, 'Buen dominio del tema', '2024-09-07 18:00:00');

INSERT INTO Certificados (IdCurso, IdEstudiante) VALUES
(1, 2),
(2, 2),
(3, 4),
(4, 5),
(5, 5);

INSERT INTO Notificaciones (IdEstudiante, Mensaje) VALUES
(2, 'Nuevo contenido disponible en el curso de Python'),
(2, 'Tu certificado de SQL est� disponible'),
(4, 'Recuerda entregar el proyecto final de dise�o gr�fico'),
(5, 'Nuevo cuestionario disponible en Marketing Digital'),
(5, 'Tu proyecto de desarrollo web ha sido calificado');

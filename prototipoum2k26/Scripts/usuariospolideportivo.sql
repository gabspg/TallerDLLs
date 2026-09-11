CREATE DATABASE IF NOT EXISTS usuariospolideportivo;
USE usuariospolideportivo;

CREATE TABLE Tbl_Rol (
    IdRol INT AUTO_INCREMENT PRIMARY KEY,
    NombreRol VARCHAR(50) NOT NULL UNIQUE,
    DescripcionRol VARCHAR(255)
);

CREATE TABLE Tbl_Usuario (
    IdUsuario INT AUTO_INCREMENT PRIMARY KEY,
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    ContrasenaUsuario VARCHAR(255) NOT NULL,
    EstadoUsuario BOOLEAN NOT NULL DEFAULT TRUE,
    FechaCreacionUsuario DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    IdRol_Usuario INT NOT NULL,

    CONSTRAINT FK_UsuarioRol
        FOREIGN KEY (IdRol_Usuario)
        REFERENCES Tbl_Rol(IdRol)
);

-- ROLES
INSERT INTO Tbl_Rol (NombreRol, DescripcionRol)
VALUES
('Administrador', 'Acceso completo al sistema'),
('Usuario', 'Acceso general al sistema'),
('Visitante', 'Acceso únicamente de consulta'),
('Recepcionista', 'Gestión de recepción'),
('Entrenador', 'Gestión de actividades deportivas'),
('Contabilidad', 'Gestión de información contable'),
('Gerente', 'Supervisión general del sistema'),
('Mantenimiento', 'Gestión de mantenimiento');

-- USUARIOS DE PRUEBA
INSERT INTO Tbl_Usuario
(NombreUsuario, ContrasenaUsuario, IdRol_Usuario)
VALUES
('admin', '1234', 1),
('usuario1', '1234', 2),
('visitante1', '1234', 3),
('recepcion1', '1234', 4),
('entrenador1', '1234', 5),
('contador1', '1234', 6),
('gerente1', '1234', 7),
('mantenimiento1', '1234', 8);

select * from Tbl_usuario;
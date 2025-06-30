CREATE DATABASE AgroMercado

use AgroMercado

-- Enum Rol (simulado con tabla o campo int)
-- Enum TipoDePublicacion (guardado como int)
-- Enum TipoCombustible, TipoDireccion también como int en Caracteristica

CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Contrasenia NVARCHAR(255) NOT NULL,
    Rol INT NOT NULL -- 0=Admin,1=Cliente (según enum Rol)
);

CREATE TABLE Cliente (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL UNIQUE,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Telefono BIGINT NOT NULL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE Administrador (
    IdAdministrador INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL UNIQUE,
    Apodo NVARCHAR(100) NOT NULL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE Direccion (
    IdDireccion INT IDENTITY(1,1) PRIMARY KEY,
    Pais NVARCHAR(100),
    Ciudad NVARCHAR(100),
    Barrio NVARCHAR(100)
);

CREATE TABLE Caracteristica (
    IdCaracteristica INT IDENTITY(1,1) PRIMARY KEY,
    Categoria NVARCHAR(100),
    Marca NVARCHAR(100),
    Modelo NVARCHAR(100),
    Anio INT,
    EsUsado BIT,
    UnicoDuenio BIT,
    TipoDeCombustible INT, -- 0=GASOIL,1=NAFTA
    TipoDeDireccion INT     -- 1=AUTOMATICO,2=MECANICO
);

CREATE TABLE Maquinaria (
    IdMaquinaria INT IDENTITY(1,1) PRIMARY KEY,
    IdDireccion INT NOT NULL,
    IdCaracteristica INT NOT NULL,
    OtrasCaracteristicas NVARCHAR(255),

    TipoMaquinaria NVARCHAR(50) NOT NULL, -- Ej: 'Tractor', 'Sembradora', etc.

    -- Campos específicos opcionales para herencia, pueden dejarse NULL si no aplican
    TieneCabina BIT NULL,             -- Tractor
    TipoDeSembradora NVARCHAR(100) NULL, -- Sembradora
    MarcaMotor NVARCHAR(100) NULL,   -- Fertilizadora, CargadoraPala
    Potencia INT NULL,                -- Fertilizadora
    DobleTraccion BIT NULL,           -- Fertilizadora
    TipoCosechadora NVARCHAR(100) NULL, -- Cosechadora
    CapacidadDeCarga INT NULL,        -- Cosechadora
    EsRuedaDual BIT NULL,             -- Cosechadora
    Cilindro INT NULL                 -- CargadoraPala
);

ALTER TABLE Maquinaria
ADD CONSTRAINT FK_Maquinaria_Direccion FOREIGN KEY (IdDireccion) REFERENCES Direccion(IdDireccion);

ALTER TABLE Maquinaria
ADD CONSTRAINT FK_Maquinaria_Caracteristica FOREIGN KEY (IdCaracteristica) REFERENCES Caracteristica(IdCaracteristica);

CREATE TABLE Publicacion (
    IdPublicacion INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(255) NOT NULL,
    Foto NVARCHAR(255),
    IdMaquinaria INT NOT NULL,
    IdCliente INT NOT NULL,
    TipoDePublicacion INT NOT NULL, -- Enum: 0=GRATIS, 1=PLATA, 2=ORO, 3=PREMIUM

    FOREIGN KEY (IdMaquinaria) REFERENCES Maquinaria(IdMaquinaria),
    FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
);

CREATE TABLE Venta (
    IdPublicacion INT PRIMARY KEY,
    FechaPublicacionVenta DATETIME NOT NULL,
    PrecioVenta DECIMAL(18,2) NOT NULL,

    FOREIGN KEY (IdPublicacion) REFERENCES Publicacion(IdPublicacion)
);

CREATE TABLE Compra (
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,
    FechaCompra DATETIME NOT NULL,
    IdCliente INT NOT NULL,
    IdPublicacion INT NOT NULL,

    FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente),
    FOREIGN KEY (IdPublicacion) REFERENCES Publicacion(IdPublicacion)
);

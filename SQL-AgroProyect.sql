CREATE DATABASE AgroMercado

use AgroMercado

-- Enum Rol (simulado con tabla o campo int)
-- Enum TipoDePublicacion (guardado como int)
-- Enum TipoCombustible, TipoDireccion también como int en Caracteristica

CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Email VARCHAR(255) UNIQUE NOT NULL, --El Email es unico para cada usuario
    Contrasenia VARCHAR(255) NOT NULL,
    Rol char(1) NOT NULL CHECK(Rol IN('A','C')) -- El rol del usuario puede ser Administrador(A) o Cliente(C)
);

CREATE TABLE Cliente (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL UNIQUE,--Se le impone UNIQUE porque cada usuario puede ser como máximo un cliente.
    Nombre VARCHAR(100) NOT NULL, -- si algun dia necesito guardar nombres occidentales utilizo el NVARCHAR
    Apellido VARCHAR(100) NOT NULL,
    Telefono VARCHAR(15) NOT NULL CHECK (
    ( 
	-- Formato internacional: debe empezar con '+' seguido solo de números y tener entre 11 y 15 caracteres
        Telefono LIKE '+[0-9]%' AND
        Telefono NOT LIKE '%[^0-9+]%' AND
        LEN(Telefono) BETWEEN 11 AND 15
    )  
    OR
    (
	-- Formato nacional: debe empezar con 0 y seguido con 9, y debe de tener 9 caracteres
        Telefono NOT LIKE '%[^0-9]%' AND 
        LEN(Telefono) = 9
    )
)
,
   CONSTRAINT FK_CliUsuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE Administrador (
    IdAdministrador INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL UNIQUE, --Se le impone UNIQUE porque cada usuario puede ser como máximo un Administrador.
    Apodo VARCHAR(100) NOT NULL,
   CONSTRAINT FK_AdminUsuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE Direccion (
    IdDireccion INT IDENTITY(1,1) PRIMARY KEY,
    Pais VARCHAR(100),
    Ciudad VARCHAR(100),
    Barrio VARCHAR(100)
);

CREATE TABLE Caracteristica (
    IdCaracteristica INT IDENTITY(1,1) PRIMARY KEY,
    Categoria VARCHAR(100),
    Marca VARCHAR(100),
    Modelo VARCHAR(100),
    Anio INT CHECK(Anio BETWEEN 1900 AND YEAR(GETDATE())),
    EsUsado BIT CHECK (EsUsado IN (0,1)),-- 0 = No usado, 1 = Usado
    UnicoDuenio BIT CHECK (UnicoDuenio IN (0,1)), -- 0 = No es unico duenio , 1 = Es unico duenio
    TipoDeCombustible INT CHECK(TipoDeCombustible IN(0,1)), -- 0=GASOIL,1=NAFTA
    TipoDeDireccion INT CHECK(TipoDeDireccion IN (1,2))     -- 0=AUTOMATICO,1=MECANICO
);

CREATE TABLE Maquinaria (
    IdMaquinaria INT IDENTITY(1,1) PRIMARY KEY,
    IdDireccion INT NOT NULL,
    IdCaracteristica INT NOT NULL,
    OtrasCaracteristicas VARCHAR(255),

--CORRECCION FUTURA CON TRIGGERS:Validaciones condicionales
--En SQL Server puro, no hay forma directa de hacer validaciones condicionales que digan:
--"Si TipoMaquinaria es 'Tractor', entonces TieneCabina no puede ser NULL".
--Esto suele manejarse desde la lógica de la aplicación o con triggers.

    TipoMaquinaria VARCHAR(50) NOT NULL
	CHECK (TipoMaquinaria IN ('Tractor', 'Sembradora', 'Fertilizadora', 'Cosechadora', 'CargadoraPala')), 
	
	--ESTOY USANDO PARA LAS HERENCIAS Table per Hierarchy:
    -- Campos específicos opcionales para herencia, pueden dejarse NULL si no aplican
    TieneCabina BIT NULL CHECK(TieneCabina IN(0,1)),-- Tractor, CHECK(0 = No tiene cabina, 1 = tiene cabina)
    TipoDeSembradora VARCHAR(100) NULL, -- Sembradora
    MarcaMotor VARCHAR(100) NULL, -- Fertilizadora, CargadoraPala
    Potencia INT NULL,-- Fertilizadora
    DobleTraccion BIT NULL CHECK(DobleTraccion IN(0,1)),-- Fertilizadora, CHECK(0 = No es doble traccion, 1 = Es doble traccion)
    TipoCosechadora VARCHAR(100) NULL, -- Cosechadora
    CapacidadDeCarga INT NULL,-- Cosechadora
    EsRuedaDual BIT NULL CHECK(EsRuedaDual IN(0,1)),-- Cosechadora, 
    Cilindro INT NULL-- CargadoraPala
);

ALTER TABLE Maquinaria
ADD CONSTRAINT FK_Maquinaria_Direccion FOREIGN KEY (IdDireccion) REFERENCES Direccion(IdDireccion);

ALTER TABLE Maquinaria
ADD CONSTRAINT FK_Maquinaria_Caracteristica FOREIGN KEY (IdCaracteristica) REFERENCES Caracteristica(IdCaracteristica);

CREATE TABLE Publicacion (
    IdPublicacion INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(255) NOT NULL,
    Foto VARCHAR(255) NOT NULL,
    IdMaquinaria INT NOT NULL,
    IdCliente INT NOT NULL,
    TipoDePublicacion INT NOT NULL, -- Enum: 0=GRATIS, 1=PLATA, 2=ORO, 3=PREMIUM

  CONSTRAINT FK_MaquinariaPublicada  FOREIGN KEY (IdMaquinaria) REFERENCES Maquinaria(IdMaquinaria),
  CONSTRAINT FK_ClientePublica FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
);

CREATE TABLE Venta (
	--IdVenta INT 
    IdPublicacion INT PRIMARY KEY,
    FechaPublicacionVenta DATETIME NOT NULL,
    PrecioVenta DECIMAL(18,2) NOT NULL,

    CONSTRAINT FK_VentaPublicada FOREIGN KEY (IdPublicacion) REFERENCES Publicacion(IdPublicacion)
);

CREATE TABLE Compra (
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,
    FechaCompra DATETIME NOT NULL,
    IdCliente INT NOT NULL,
    IdPublicacion INT NOT NULL,

    CONSTRAINT FK_ClienteCompro FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente),
    CONSTRAINT FK_PublicacionComprada FOREIGN KEY (IdPublicacion) REFERENCES Publicacion(IdPublicacion)
);


--Devuelve todos los clientes que tienen al menos una compra registrada.
select c.IdCliente,c.Nombre,c.Apellido
from Cliente c
where exists(select 1 from Compra co where co.IdCliente = c.IdCliente)

--Devuelve todos los clientes que no tienen compras registrada.
select c.IdCliente,c.Nombre,c.Apellido
from Cliente c
where NOT EXISTS(select IdCompra from Compra co where co.IdCliente = c.IdCliente)

--obtener los clientes que tienen más de 3 compras
select c.IdCliente,c.Nombre,c.Apellido ,COUNT(co.IdCompra) as CantidadComprasDelCliente
from Cliente c
inner join Compra co on co.IdCliente = c.IdCliente
group by c.IdCliente,c.Nombre,c.Apellido
having COUNT(co.IdCompra) > 3

--Mostrar los nombres y apellidos de los clientes que realizaron una cantidad de compras mayor 
--que el promedio de compras por cliente.
select c.Nombre,c.Apellido
from  Cliente c
where c.IdCliente IN (select co.IdCliente from Compra co
group by co.IdCliente having count(co.IdCompra) > (select AVG(CantidadCompras) from
(select count(*) AS CantidadCompras  from Compra group by IdCliente )AS SubPromedio
));

--Mostrar los nombres y apellidos de los clientes que hayan hecho compras, pero solo aquellos que
--tienen un número de compras menor o igual al promedio de compras por cliente.
select c.Nombre,c.Apellido
from Cliente c
where c.IdCliente in (select co.IdCliente from Compra co 
group by co.IdCliente having count(co.IdCompra) <= (select AVG(PromedioCompraMenor)  from (
select count(*)AS PromedioCompraMenor from Compra group by IdCliente)AS PromedioMenor
));

--Obtener los nombres y apellidos de los clientes que hayan comprado maquinaria cuyo año de fabricación 
--(en Caracteristica.Anio) sea mayor al promedio de años de todas las maquinarias vendidas.
select c.Nombre,c.Apellido
from Cliente c
where c.IdCliente in (select co.IdCliente from Compra co
inner join Publicacion p on p.IdPublicacion = co.IdPublicacion
inner join Maquinaria m on m.IdMaquinaria = p.IdMaquinaria
inner join Caracteristica c on c.IdCaracteristica = m.IdCaracteristica
having AVG(c.Anio) > (select AVG(c2.Anio) from Compra
inner join Publicacion p on p.IdPublicacion = co.IdPublicacion
inner join Maquinaria m on m.IdMaquinaria = p.IdMaquinaria
inner join Caracteristica c2 on c.IdCaracteristica = m.IdCaracteristica))
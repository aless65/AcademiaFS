--GO
--USE master
--GO
--DROP DATABASE SistemaViajes
GO
CREATE DATABASE SistemaViajesDb
GO
USE SistemaViajesDb
GO
--CREATE SCHEMA acce
--GO
--CREATE SCHEMA gral
--GO
--CREATE SCHEMA viaj
--GO


--ESQUEMA ACCESO
CREATE TABLE Usuarios(
	IdUsuario				INT IDENTITY(1,1),
	Nombre					NVARCHAR(100)	NOT NULL,
	Contrasena				NVARCHAR(MAX)	NOT NULL,
	Imagen					NVARCHAR(MAX)	NOT NULL,
	EsAdmin					BIT				NOT NULL,
	IdRol					INT,

	Estado					BIT NOT NULL CONSTRAINT DF_tbUsuarios_Estado DEFAULT 1,
	UsuaCreacion			INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	UsuaModificacion		INT,
	FechaModificacion		DATETIME

	CONSTRAINT PK_tbUsuarios_usua_Id		PRIMARY KEY(IdUsuario),
	CONSTRAINT UC_tbUsuarios_usua_Nombre	UNIQUE(Nombre)
);
GO
--GO
--EXEC acce.UDP_tbUsuarios_Insertar 'admin', '123', 'https://static.wikia.nocookie.net/ba0628fe-3bc1-42c3-9c0c-aa91ba24f03c/scale-to-width/370', 1, NULL, 1, '2023-11-08'
--GO

INSERT INTO Usuarios(Nombre,
					 Contrasena,
					 Imagen,
					 EsAdmin,
					 IdRol,
					 UsuaCreacion,
					 FechaCreacion)
VALUES ('admin', '123', 'https://static.wikia.nocookie.net/ba0628fe-3bc1-42c3-9c0c-aa91ba24f03c/scale-to-width/370', 1, NULL, 1, GETDATE())
--******************************

--******************************
--CONSTRAINTS DE AUDITORÍA DE USUARIOS
ALTER TABLE Usuarios
ADD CONSTRAINT FK_Usuarios_Usuarios_IdUsuario_UsuaCreacion		FOREIGN KEY(UsuaCreacion)		REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Usuarios_Usuarios_IdUsuario_Modificacion		FOREIGN KEY(UsuaModificacion)	REFERENCES Usuarios(IdUsuario)
GO
--******************************

CREATE TABLE Roles(
	IdRol					INT IDENTITY(1,1),
	Nombre					NVARCHAR(100)	NOT NULL,

	Estado					BIT				DEFAULT 1,
	UsuaCreacion			INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	UsuaModificacion		INT,
	FechaModificacion		DATETIME

	CONSTRAINT PK_Roles_IdRol									PRIMARY KEY(IdRol),
	CONSTRAINT UC_Roles_role_Nombre								UNIQUE(Nombre),
	CONSTRAINT FK_Roles_Usuarios_UsuaCreacion_IdUsuario			FOREIGN KEY(UsuaCreacion)		REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Roles_Usuarios_Modificacion_IdUsuario			FOREIGN KEY(UsuaModificacion)	REFERENCES Usuarios(IdUsuario),
);
GO

CREATE TABLE Pantallas(
	IdPantalla					INT IDENTITY(1,1),
	Nombre						NVARCHAR(100)	NOT NULL,
	[URL]						NVARCHAR(MAX)	NOT NULL,
	Icon						NVARCHAR(250)	NOT NULL

	CONSTRAINT PK_Pantallas_IdPantalla		PRIMARY KEY(IdPantalla),
	CONSTRAINT UC_Pantallas_Nombre			UNIQUE(Nombre),
);
GO

CREATE TABLE RolesXPantallas(
	IdRolesXPantallas		INT IDENTITY(1,1),
	IdRol					INT,
	IdPantalla				INT,

	UsuaCreacion			INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL

	CONSTRAINT PK_RolesXPantallas_IdRolesXPantallas						PRIMARY KEY(IdRolesXPantallas),
	CONSTRAINT FK_RolesXPantallas_Roles_IdRol							FOREIGN KEY(IdRol)				REFERENCES Roles(IdRol),
	CONSTRAINT FK_RolesXPantallas_Pantallas_IdPantalla					FOREIGN KEY(IdPantalla)			REFERENCES Pantallas(IdPantalla),
	CONSTRAINT FK_RolesXPantallas_Usuarios_UsuaCreacion_IdUsuario		FOREIGN KEY(UsuaCreacion)		REFERENCES Usuarios(IdUsuario)
);
GO


--ESQUEMA GENERAL
CREATE TABLE Departamentos(
	IdDepartamento  			INT IDENTITY(1,1),
	Codigo						CHAR(2)			NOT NULL,
	Nombre 						NVARCHAR(100)	NOT NULL,

	UsuaCreacion				INT				NOT NULL,
	FechaCreacion				DATETIME		NOT NULL,
	UsuaModificacion			INT,
	FechaModificacion			DATETIME,
	Estado						BIT NOT NULL CONSTRAINT DF_Depa_Estado DEFAULT(1)
	CONSTRAINT PK_Departamentos_IdDepartamento 											PRIMARY KEY(IdDepartamento),
	CONSTRAINT UC_Departamentos_Nombre													UNIQUE(Nombre),
	CONSTRAINT UC_Departamentos_Codigo													UNIQUE(Codigo),
	CONSTRAINT FK_Departamentos_Usuarios_UsuCreacion_IdUsuario  						FOREIGN KEY(UsuaCreacion) 		REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Departamentos_Usuarios_UsuModificacion_IdUsuario  					FOREIGN KEY(UsuaModificacion) 	REFERENCES Usuarios(IdUsuario)
);
GO

CREATE TABLE Municipios(
	IdMunicipio					INT IDENTITY(1,1),
	Codigo						CHAR(4)			NOT NULL,
	Nombre						NVARCHAR(80)	NOT NULL,
	IdDepartamento				INT				NOT NULL,

	UsuaCreacion				INT	NOT NULL,
	FechaCreacion				DATETIME NOT NULL,
	UsuaModificacion			INT,
	FechaModificacion			DATETIME,
	Estado						BIT	NOT NULL CONSTRAINT DF_Muni_Estado DEFAULT(1)
	CONSTRAINT PK_Municipios_IdMunicipio							PRIMARY KEY(IdMunicipio),
	CONSTRAINT UC_Municipios_Nombre_Codigo_IdDepartamento			UNIQUE(Nombre, Codigo, IdDepartamento),
	CONSTRAINT UC_Municipios_muni_Codigo							UNIQUE(Codigo),
	CONSTRAINT FK_Municipios_Departamentos_IdDepartamento 			FOREIGN KEY(IdDepartamento) 			REFERENCES Departamentos(IdDepartamento),
	CONSTRAINT FK_Municipios_Usuarios_UsuaCreacion_IdUsuario  		FOREIGN KEY(UsuaCreacion) 				REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Municipios_Usuarios_UsuaModificacion_IdUsuario  	FOREIGN KEY(UsuaModificacion) 			REFERENCES Usuarios(IdUsuario)
);
GO

CREATE TABLE Sucursales(
	IdSucursal			INT IDENTITY(1,1),
	Nombre				NVARCHAR(300)	NOT NULL,
	Direccion			NVARCHAR(600)	NOT NULL,
	IdMunicipio			INT				NOT NULL,

	Estado				BIT	NOT NULL CONSTRAINT DF_Sucu_Estado DEFAULT 1,
	UsuaCreacion		INT				NOT NULL,
	FechaCreacion		DATETIME		NOT NULL,
	UsuaModificacion	INT,
	FechaModificacion	DATETIME

	CONSTRAINT PK_Sucursales_IdSucursal								PRIMARY KEY(IdSucursal),
	CONSTRAINT UC_Sucursales_Nombre									UNIQUE(Nombre),
	CONSTRAINT FK_Sucursales_Municipios_IdMunicipio 				FOREIGN KEY(IdMunicipio) 				REFERENCES Municipios(IdMunicipio),
	CONSTRAINT FK_Sucursales_Usuarios_UsuaCreacion_IdUsuario		FOREIGN KEY(UsuaCreacion)		REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Sucursales_Usuarios_Modificacion_IdUsuario		FOREIGN KEY(UsuaModificacion)	REFERENCES Usuarios(IdUsuario)
);
GO

--ESQUEMA VIAJES
CREATE TABLE Colaboradores(
	IdColaborador			INT IDENTITY(1,1),
	Nombres					NVARCHAR(300)	NOT NULL,
	Apellidos				NVARCHAR(300)	NOT NULL,
	Identidad				VARCHAR(13)		NOT NULL,
	Direccion				NVARCHAR(600)	NOT NULL,
	IdMunicipio				INT				NOT NULL,
	FechaNacimiento			DATE			NOT NULL,
	Sexo					CHAR			NOT NULL,

	Estado					BIT	NOT NULL CONSTRAINT DF_Cola_Estado DEFAULT 1,
	UsuaCreacion			INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	UsuaModificacion		INT,
	FechaModificacion		DATETIME

	CONSTRAINT PK_Colaboradores_IdColaborador								PRIMARY KEY(IdColaborador),
	CONSTRAINT UC_Colaboradores_Identidad									UNIQUE(Identidad),
	CONSTRAINT CK_Colaboradores_Sexo										CHECK(Sexo IN ('F', 'M')),
	CONSTRAINT FK_Colaboradores_Municipios_IdMunicipio 						FOREIGN KEY(IdMunicipio) 				REFERENCES Municipios(IdMunicipio),
	CONSTRAINT FK_Colaboradores_Usuarios_UsuaCreacion_IdUsuario				FOREIGN KEY(UsuaCreacion)		REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Colaboradores_Usuarios_Modificacion_IdUsuario				FOREIGN KEY(UsuaModificacion)	REFERENCES Usuarios(IdUsuario)
);
GO

CREATE TABLE Transportistas(
	IdTransportista					INT IDENTITY(1,1),
	Nombres							NVARCHAR(300)	NOT NULL,
	Apellidos						NVARCHAR(300)	NOT NULL,
	Identidad						VARCHAR(13)		NOT NULL,
	TarifaKm						DECIMAL(18, 2)	NOT NULL,
	FechaNacimiento					DATE			NOT NULL,
	Sexo							CHAR			NOT NULL,

	Estado							BIT	NOT NULL CONSTRAINT DF_Tran_Estado DEFAULT 1,
	UsuaCreacion					INT				NOT NULL,
	FechaCreacion					DATETIME		NOT NULL,
	UsuaModificacion				INT,
	FechaModificacion				DATETIME

	CONSTRAINT PK_Transportistas_IdTransportista								PRIMARY KEY(IdTransportista),
	CONSTRAINT UC_Transportistas_Identidad										UNIQUE(Identidad),
	CONSTRAINT CK_Transportistas_Sexo											CHECK(Sexo IN ('F', 'M')),
	CONSTRAINT FK_Transportistas_Usuarios_UsuaCreacion_IdUsuario				FOREIGN KEY(UsuaCreacion)		REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Transportistas_Usuarios_Modificacion_IdUsuario				FOREIGN KEY(UsuaModificacion)	REFERENCES Usuarios(IdUsuario)
);
GO

CREATE TABLE SucursalesXColaboradores(
	IdSucursalXColaborador		INT IDENTITY(1,1),
	IdSucursal					INT				NOT NULL,
	IdColaborador				INT				NOT NULL,

	DistanciaKm					DECIMAL(18, 2)	NOT NULL,
	UsuaCreacion				INT				NOT NULL,
	FechaCreacion				DATETIME		NOT NULL

	CONSTRAINT PK_SucursalesXColaboradores_IdSucursalXColaborador							PRIMARY KEY(IdSucursalXColaborador),
	CONSTRAINT UC_SucursalesXColaboradores_IdSucursal_IdColaborador							UNIQUE(IdSucursal, IdColaborador),
	CONSTRAINT FK_SucursalesXColaboradores_Sucursales_IdSucursal 							FOREIGN KEY(IdSucursal) 				REFERENCES Sucursales(IdSucursal),
	CONSTRAINT FK_SucursalesXColaboradores_Colaboradores_IdColaborador 						FOREIGN KEY(IdColaborador) 				REFERENCES Colaboradores(IdColaborador),
	CONSTRAINT FK_SucursalesXColaboradores_Usuarios_UsuaCreacion_IdUsuario					FOREIGN KEY(UsuaCreacion)				REFERENCES Usuarios(IdUsuario)
);
GO

CREATE TABLE Viajes(
	IdViaje					INT IDENTITY(1,1),
	FechaYHora				DATETIME		NOT NULL,
	TarifaActual			DECIMAL(18, 2)	NOT NULL,
	TotalKm					DECIMAL(18, 2)	NOT NULL,
	IdSucursal				INT				NOT NULL,
	IdTransportista			INT				NOT NULL,

	Estado				BIT	NOT NULL CONSTRAINT DF_Viaj_Estado DEFAULT 1,
	UsuaCreacion		INT				NOT NULL,
	FechaCreacion		DATETIME		NOT NULL,
	UsuaModificacion	INT,
	FechaModificacion	DATETIME

	CONSTRAINT PK_Viajes_IdViaje										PRIMARY KEY(IdViaje),
	CONSTRAINT FK_Viajes_Sucursales_IdSucursal 							FOREIGN KEY(IdSucursal) 				REFERENCES Sucursales(IdSucursal),
	CONSTRAINT FK_Viajes_Transportistas_IdTransportista 				FOREIGN KEY(IdTransportista) 			REFERENCES Transportistas(IdTransportista),
	CONSTRAINT FK_Viajes_Usuarios_UsuaCreacion_IdUsuario				FOREIGN KEY(UsuaCreacion)						REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Viajes_Usuarios_Modificacion_IdUsuario				FOREIGN KEY(UsuaModificacion)					REFERENCES Usuarios(IdUsuario)
);
GO

CREATE TABLE ViajesDetalles(
	IdViajeDetalle			INT IDENTITY(1,1),
	IdViaje					INT				NOT NULL,
	IdColaborador			INT				NOT NULL,
	DistanciaActual			DECIMAL(18,2)	NOT NULL,

	Estado				BIT	NOT NULL CONSTRAINT DF_ViajeDetalle_Estado DEFAULT 1,
	UsuaCreacion		INT				NOT NULL,
	FechaCreacion		DATETIME		NOT NULL,
	UsuaModificacion	INT,
	FechaModificacion	DATETIME

	CONSTRAINT PK_ViajesDetalles_IdViajeDetalle							PRIMARY KEY(IdViajeDetalle),
	CONSTRAINT FK_ViajesDetalles_Viajes_IdViaje 						FOREIGN KEY(IdViaje) 				REFERENCES Viajes(IdViaje),
	CONSTRAINT FK_ViajesDetalles_Colaboradores_IdColaborador 			FOREIGN KEY(IdColaborador) 				REFERENCES Colaboradores(IdColaborador),
	CONSTRAINT FK_ViajesDetalles_Usuarios_UsuaCreacion_IdUsuario		FOREIGN KEY(UsuaCreacion)		REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_ViajesDetalles_Usuarios_UsuaModificacion_IdUsuario	FOREIGN KEY(UsuaModificacion)	REFERENCES Usuarios(IdUsuario)
);
GO
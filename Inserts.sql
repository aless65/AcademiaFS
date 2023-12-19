INSERT INTO [dbo].[Transportistas](Nombres, 
								   Apellidos, 
								   Identidad, 
								   TarifaKm, 
								   FechaNacimiento, 
								   Sexo, 
								   UsuaCreacion, 
								   FechaCreacion)
VALUES ('Juan Fernando', 'Cruz', '0501200506758', 12, '2003-02-12', 'M', 1, GETDATE()),
	   ('Luisa', 'Hernandez', '0501200506745', 12, '2005-12-12', 'F', 1, GETDATE()),
	   ('Caijta', 'Feliz', '06550569985', 20, '1998-06-30', 'M', 1, GETDATE())


INSERT INTO [dbo].[Sucursales](Nombre, 
							   Direccion, 
							   IdMunicipio,
							   UsuaCreacion, 
							   FechaCreacion)
VALUES ('Sucursal 1', 'jefes', 1, 1, GETDATE()),
       ('Sucursal 2', 'hglfhld', 1, 1, GETDATE()),
       ('Sucursal 3', 'aaaaa', 1, 1, GETDATE())

INSERT INTO [dbo].[Colaboradores](Nombres, 
								  Apellidos, 
								  Identidad, 
								  Direccion, 
								  IdMunicipio, 
								  FechaNacimiento, 
								  Sexo, 
								  UsuaCreacion, 
								  FechaCreacion)
VALUES ('Hernán', 'De las Grandes Brisas', '0201198054878', 'hacer algo', 1, '1979-01-30', 'M', 1, GETDATE())
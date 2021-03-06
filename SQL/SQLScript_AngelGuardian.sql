USE [Angel_Guardian]
GO
if exists(select * from sys.all_objects where name = 'fk_Servicio_Negocio' and type = 'F')
begin 
	ALTER TABLE [dbo].[Servicio] DROP CONSTRAINT [fk_Servicio_Negocio]
end
GO
if exists(select * from sys.all_objects where name = 'fk_Negocio_Usuario' and type = 'F')
begin 
	ALTER TABLE [dbo].[Negocio] DROP CONSTRAINT [fk_Negocio_Usuario]
end 
GO
if exists(select * from sys.all_objects where name = 'fk_Negocio_Municipio' and type = 'F')
begin
	ALTER TABLE [dbo].[Negocio] DROP CONSTRAINT [fk_Negocio_Municipio]
end
GO
if exists(select * from sys.all_objects where name = 'fk_Negocio_Imagen' and type = 'F')
begin
	ALTER TABLE [dbo].[Negocio] DROP CONSTRAINT [fk_Negocio_Imagen]
end 
GO
if exists(select * from sys.all_objects where name = 'fk_Negocio_Estado' and type = 'F')
begin
	ALTER TABLE [dbo].[Negocio] DROP CONSTRAINT [fk_Negocio_Estado]
end
GO
if exists(select * from sys.all_objects where name = 'FK_Municipio_Estado' and type = 'F')
begin
	ALTER TABLE [dbo].[Municipio] DROP CONSTRAINT [FK_Municipio_Estado]
end
GO
if exists(select * from sys.all_objects where name = 'FK_Direccion_Usuario' and type = 'F')
begin
	ALTER TABLE [dbo].[Direccion] DROP CONSTRAINT [FK_Direccion_Usuario]
end
GO
if exists(select * from sys.all_objects where name = 'FK_Direccion_Municipio' and type = 'F')
begin
	ALTER TABLE [dbo].[Direccion] DROP CONSTRAINT [FK_Direccion_Municipio]
end
GO
if exists(select * from sys.all_objects where name = 'FK_Direcccion_Estado' and type = 'F')
begin
	ALTER TABLE [dbo].[Direccion] DROP CONSTRAINT [FK_Direcccion_Estado]
end
GO
if exists(select * from sys.all_objects where name = 'fk_ComprobanteDetalle_Servicio' and type = 'F')
begin
	ALTER TABLE [dbo].[ComprobanteDetalle] DROP CONSTRAINT [fk_ComprobanteDetalle_Servicio]
end
GO
if exists(select * from sys.all_objects where name = 'fk_ComprobanteDetalle_Comprobante' and type = 'F')
begin
	ALTER TABLE [dbo].[ComprobanteDetalle] DROP CONSTRAINT [fk_ComprobanteDetalle_Comprobante]
end
GO
if exists(select * from sys.all_objects where name = 'fk_Comprobante_Usuario' and type = 'F')
begin
	ALTER TABLE [dbo].[Comprobante] DROP CONSTRAINT [fk_Comprobante_Usuario]
end
GO
if exists(select * from sys.all_objects where name = 'fk_Comprobante_Negocio' and type = 'F')
begin
	ALTER TABLE [dbo].[Comprobante] DROP CONSTRAINT [fk_Comprobante_Negocio]
end
GO
if exists(select * from sys.all_objects where name = 'fk_Comprobante_Estatus' and type = 'F')
begin
	ALTER TABLE [dbo].[Comprobante] DROP CONSTRAINT [fk_Comprobante_Estatus]
end
GO
if exists(select * from sys.all_objects where name = 'fk_Comprobante_Direccion' and type = 'F')
begin
	ALTER TABLE [dbo].[Comprobante] DROP CONSTRAINT [fk_Comprobante_Direccion]
end
GO
if exists(select * from sys.all_objects where name = 'Usuario' and type = 'U')
begin
	DROP TABLE [dbo].[Usuario]
end
GO
if exists(select * from sys.all_objects where name = 'Servicio' and type = 'U')
begin
	DROP TABLE [dbo].[Servicio]
end
GO
if exists(select * from sys.all_objects where name = 'Negocio' and type = 'U')
begin
	DROP TABLE [dbo].[Negocio]
end
GO
if exists(select * from sys.all_objects where name = 'Municipio' and type = 'U')
begin
	DROP TABLE [dbo].[Municipio]
end
GO
if exists(select * from sys.all_objects where name = 'Imagen' and type = 'U')
begin
	DROP TABLE [dbo].[Imagen]
end
GO
if exists(select * from sys.all_objects where name = 'Estatus' and type = 'U')
begin
	DROP TABLE [dbo].[Estatus]
end
GO
if exists(select * from sys.all_objects where name = 'Estado' and type = 'U')
begin
	DROP TABLE [dbo].[Estado]
end
GO
if exists(select * from sys.all_objects where name = 'Direccion' and type = 'U')
begin
	DROP TABLE [dbo].[Direccion]
end
GO
if exists(select * from sys.all_objects where name = 'ComprobanteDetalle' and type = 'U')
begin
	DROP TABLE [dbo].[ComprobanteDetalle]
end
GO
if exists(select * from sys.all_objects where name = 'Comprobante' and type = 'U')
begin
	DROP TABLE [dbo].[Comprobante]
end
GO
CREATE TABLE [dbo].[Comprobante](
	[IdComprobante] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdNegocio] [int] NOT NULL,
	[Efectivo] [bit] NOT NULL,
	[IdEstatus] [int] NOT NULL,
	[IdDireccion] [int] NOT NULL,
	[Puntuacion] [int] NOT NULL,
	[Precio] [float] NOT NULL,
	[Pago] [float] NOT NULL,
	[Cambio] [float] NOT NULL,
	[Fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[ComprobanteDetalle](
	[IdComprobanteDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdComprobante] [int] NOT NULL,
	[IdServicio] [int] NOT NULL,
	[Puntuacion] [int] NOT NULL,
	[Precio] [float] NOT NULL,
	[Cambio] [float] NULL,
	[Fecha] [datetime] NOT NULL,
	[Cantidad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdComprobanteDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Direccion](
	[IdDireccion] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[IdMunicipio] [int] NOT NULL,
	[Calle] [nvarchar](200) NOT NULL,
	[Colonia] [nvarchar](50) NOT NULL,
	[NumeroInterior] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Estado](
	[IdEstado] [int] NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Estatus](
	[IdEstatus] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Imagen](
	[IdImagen] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Ruta] [text] NOT NULL,
	[Size] [float] NOT NULL,
	[Fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdImagen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE TABLE [dbo].[Municipio](
	[IdMunicipio] [int] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMunicipio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Negocio](
	[IdNegocio] [int] IDENTITY(1,1) NOT NULL,
	[IdImagen] [int] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[IdMunicipio] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[RazonSocial] [text] NOT NULL,
	[PuntuacionPromedio] [int] NOT NULL,
	[Calle] [nvarchar](200) NOT NULL,
	[Colonia] [nvarchar](50) NOT NULL,
	[NumeroInterior] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNegocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE TABLE [dbo].[Servicio](
	[IdServicio] [int] IDENTITY(1,1) NOT NULL,
	[IdNegocio] [int] NOT NULL,
	[Puntuacion] [int] NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[Duracion] [float] NOT NULL,
	[Precio] [float] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NickName] [nvarchar](50) NOT NULL,
	[ApellidoPaterno] [nvarchar](50) NOT NULL,
	[ApellidoMaterno] [nvarchar](50) NOT NULL,
	[Celular] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Consumidor] [bit] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[NombreUsuario] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Direccion] ([IdDireccion], [IdUsuario], [IdEstado], [IdMunicipio], [Calle], [Colonia], [NumeroInterior]) VALUES (1, 10, 19, 696, N'Pozo del Marin', N'Praderas de Marin', 420)
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (1, N'AGUASCALIENTES')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (2, N'BAJA CAL. NORTE')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (3, N'BAJA CAL. SUR')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (4, N'CAMPECHE')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (5, N'COAHUILA')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (6, N'COLIMA')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (7, N'CHIAPAS')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (8, N'CHIHUAHUA')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (9, N'CIUDAD DE MEXICO')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (10, N'DURANGO')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (11, N'EDO. DE MEXICO')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (12, N'GUANAJUATO')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (13, N'GUERRERO')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (14, N'HIDALGO')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (15, N'JALISCO')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (16, N'MICHOACAN')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (17, N'MORELOS')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (18, N'NAYARIT')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (19, N'NUEVO LEON')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (20, N'OAXACA')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (21, N'PUEBLA')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (22, N'QUERETARO')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (23, N'QUINTANA ROO')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (24, N'SAN LUIS POTOSI')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (25, N'SINALOA')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (26, N'SONORA')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (27, N'TABASCO')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (28, N'TAMAULIPAS')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (29, N'TLAXCALA')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (30, N'VERACRUZ')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (31, N'YUCATAN')
INSERT [dbo].[Estado] ([IdEstado], [Nombre]) VALUES (32, N'ZACATECAS')
SET IDENTITY_INSERT [dbo].[Estatus] ON 

INSERT [dbo].[Estatus] ([IdEstatus], [Nombre], [Fecha]) VALUES (2, N'Pendiente', CAST(0x0000AD10011EC6DA AS DateTime))
INSERT [dbo].[Estatus] ([IdEstatus], [Nombre], [Fecha]) VALUES (3, N'Comprado', CAST(0x0000AD10011EC6DA AS DateTime))
INSERT [dbo].[Estatus] ([IdEstatus], [Nombre], [Fecha]) VALUES (4, N'Entregado', CAST(0x0000AD10011EC6DA AS DateTime))
INSERT [dbo].[Estatus] ([IdEstatus], [Nombre], [Fecha]) VALUES (5, N'Pagado', CAST(0x0000AD10011EC6DA AS DateTime))
SET IDENTITY_INSERT [dbo].[Estatus] OFF
SET IDENTITY_INSERT [dbo].[Imagen] ON 

INSERT [dbo].[Imagen] ([IdImagen], [Nombre], [Ruta], [Size], [Fecha]) VALUES (1, N'Prueba.jpg', N'ImagenesMamalonas/Prueba.jpg', 500, CAST(0x0000AD130010A2A1 AS DateTime))
INSERT [dbo].[Imagen] ([IdImagen], [Nombre], [Ruta], [Size], [Fecha]) VALUES (2, N'Prueba2.jpg', N'ImagenesMamalonas/Prueba2.jpg', 500, CAST(0x0000AD1300B6FC4D AS DateTime))
SET IDENTITY_INSERT [dbo].[Imagen] OFF
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (679, 19, N'ABASOLO')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (680, 19, N'AGUALEGUAS')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (681, 19, N'LOS ALDAMAS')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (682, 19, N'ALLENDE')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (683, 19, N'ANAHUAC')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (684, 19, N'APODACA')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (685, 19, N'ARAMBERRI')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (686, 19, N'BUSTAMANTE')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (687, 19, N'CADEREYTA JIMENEZ')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (688, 19, N'CARMEN')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (689, 19, N'CERRALVO')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (690, 19, N'CIENEGA DE FLORES')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (691, 19, N'CHINA')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (692, 19, N'DOCTOR ARROYO')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (693, 19, N'DOCTOR COSS')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (694, 19, N'DOCTOR GONZALEZ')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (695, 19, N'GALEANA')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (696, 19, N'GARCÍA')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (697, 19, N'SAN PEDRO GARZA GARCIA')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (698, 19, N'GENERAL BRAVO')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (699, 19, N'GENERAL ESCOBEDO')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (700, 19, N'GENERAL TERAN')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (701, 19, N'GENERAL TREVINO')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (702, 19, N'GENERAL ZARAGOZA')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (703, 19, N'GENERAL ZUAZUA')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (704, 19, N'GUADALUPE')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (705, 19, N'LOS HERRERAS')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (706, 19, N'HIGUERAS')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (707, 19, N'HUALAHUISES')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (708, 19, N'ITURBIDE')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (709, 19, N'GENERAL TREVINO')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (710, 19, N'LAMPAZOS DE NARANJO')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (711, 19, N'LINARES')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (712, 19, N'MARIN')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (713, 19, N'MELCHOR OCAMPO')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (714, 19, N'MIER Y NORIEGA')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (715, 19, N'MINA')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (716, 19, N'MONTEMORELOS')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (717, 19, N'MONTERREY')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (718, 19, N'PARAS')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (719, 19, N'PESQUERIA')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (720, 19, N'LOS RAMONES')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (721, 19, N'RAYONES')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (722, 19, N'SABINAS HIDALGO')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (723, 19, N'SALINAS VICTORIA')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (724, 19, N'SAN NICOLAS DE LOS GARZA')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (725, 19, N'HIDALGO')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (726, 19, N'SANTA CATARINA')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (727, 19, N'SANTIAGO')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (728, 19, N'VALLECILLO')
INSERT [dbo].[Municipio] ([IdMunicipio], [IdEstado], [Nombre]) VALUES (729, 19, N'VILLALDAMA')
SET IDENTITY_INSERT [dbo].[Negocio] ON 

INSERT [dbo].[Negocio] ([IdNegocio], [IdImagen], [IdEstado], [IdMunicipio], [Nombre], [RazonSocial], [PuntuacionPromedio], [Calle], [Colonia], [NumeroInterior], [Fecha], [IdUsuario], [Activo]) VALUES (1, 1, 19, 684, N'La Parada del Vocho', N'La Parada del Vocho S.A', 0, N'Alamo Canadiense', N'Los Alamos', 409, CAST(0x0000AD13001E07C6 AS DateTime), 10, 1)
INSERT [dbo].[Negocio] ([IdNegocio], [IdImagen], [IdEstado], [IdMunicipio], [Nombre], [RazonSocial], [PuntuacionPromedio], [Calle], [Colonia], [NumeroInterior], [Fecha], [IdUsuario], [Activo]) VALUES (2, 1, 19, 684, N'Taco Feliz', N'Taco Feliz S.A', 0, N'San Lorenzo', N'San Patricio', 620, CAST(0x0000AD1300D0110C AS DateTime), 10, 0)
SET IDENTITY_INSERT [dbo].[Negocio] OFF
SET IDENTITY_INSERT [dbo].[Servicio] ON 

INSERT [dbo].[Servicio] ([IdServicio], [IdNegocio], [Puntuacion], [Nombre], [Descripcion], [Duracion], [Precio], [Fecha], [Activo]) VALUES (1, 1, 0, N'Afinacion Menor', N'Se hace cambio de aceite, filtro y bujias', 30, 350.5, CAST(0x0000AD1300354A0D AS DateTime), 1)
INSERT [dbo].[Servicio] ([IdServicio], [IdNegocio], [Puntuacion], [Nombre], [Descripcion], [Duracion], [Precio], [Fecha], [Activo]) VALUES (2, 1, 0, N'Afinacion Mayor', N'Se hace cambio de aceite, filtro, bujias, banda del motor y filtros de aire', 30, 700, CAST(0x0000AD130035D99F AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Servicio] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [NickName], [ApellidoPaterno], [ApellidoMaterno], [Celular], [Email], [Consumidor], [Fecha], [Password], [NombreUsuario]) VALUES (10, N'ecarrasco', N'Carrasco', N'Carrillo', N'8123526245', N'sombra_rc94@hotmail.com', 0, CAST(0x0000AD110164F61B AS DateTime), N'123456789', N'Edson')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [fk_Comprobante_Direccion] FOREIGN KEY([IdDireccion])
REFERENCES [dbo].[Direccion] ([IdDireccion])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [fk_Comprobante_Direccion]
GO
ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [fk_Comprobante_Estatus] FOREIGN KEY([IdEstatus])
REFERENCES [dbo].[Estatus] ([IdEstatus])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [fk_Comprobante_Estatus]
GO
ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [fk_Comprobante_Negocio] FOREIGN KEY([IdNegocio])
REFERENCES [dbo].[Negocio] ([IdNegocio])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [fk_Comprobante_Negocio]
GO
ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [fk_Comprobante_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [fk_Comprobante_Usuario]
GO
ALTER TABLE [dbo].[ComprobanteDetalle]  WITH CHECK ADD  CONSTRAINT [fk_ComprobanteDetalle_Comprobante] FOREIGN KEY([IdComprobante])
REFERENCES [dbo].[Comprobante] ([IdComprobante])
GO
ALTER TABLE [dbo].[ComprobanteDetalle] CHECK CONSTRAINT [fk_ComprobanteDetalle_Comprobante]
GO
ALTER TABLE [dbo].[ComprobanteDetalle]  WITH CHECK ADD  CONSTRAINT [fk_ComprobanteDetalle_Servicio] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicio] ([IdServicio])
GO
ALTER TABLE [dbo].[ComprobanteDetalle] CHECK CONSTRAINT [fk_ComprobanteDetalle_Servicio]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direcccion_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estado] ([IdEstado])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direcccion_Estado]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Municipio] FOREIGN KEY([IdMunicipio])
REFERENCES [dbo].[Municipio] ([IdMunicipio])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Municipio]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Usuario]
GO
ALTER TABLE [dbo].[Municipio]  WITH CHECK ADD  CONSTRAINT [FK_Municipio_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estado] ([IdEstado])
GO
ALTER TABLE [dbo].[Municipio] CHECK CONSTRAINT [FK_Municipio_Estado]
GO
ALTER TABLE [dbo].[Negocio]  WITH CHECK ADD  CONSTRAINT [fk_Negocio_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estado] ([IdEstado])
GO
ALTER TABLE [dbo].[Negocio] CHECK CONSTRAINT [fk_Negocio_Estado]
GO
ALTER TABLE [dbo].[Negocio]  WITH CHECK ADD  CONSTRAINT [fk_Negocio_Imagen] FOREIGN KEY([IdImagen])
REFERENCES [dbo].[Imagen] ([IdImagen])
GO
ALTER TABLE [dbo].[Negocio] CHECK CONSTRAINT [fk_Negocio_Imagen]
GO
ALTER TABLE [dbo].[Negocio]  WITH CHECK ADD  CONSTRAINT [fk_Negocio_Municipio] FOREIGN KEY([IdMunicipio])
REFERENCES [dbo].[Municipio] ([IdMunicipio])
GO
ALTER TABLE [dbo].[Negocio] CHECK CONSTRAINT [fk_Negocio_Municipio]
GO
ALTER TABLE [dbo].[Negocio]  WITH CHECK ADD  CONSTRAINT [fk_Negocio_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Negocio] CHECK CONSTRAINT [fk_Negocio_Usuario]
GO
ALTER TABLE [dbo].[Servicio]  WITH CHECK ADD  CONSTRAINT [fk_Servicio_Negocio] FOREIGN KEY([IdNegocio])
REFERENCES [dbo].[Negocio] ([IdNegocio])
GO
ALTER TABLE [dbo].[Servicio] CHECK CONSTRAINT [fk_Servicio_Negocio]
GO

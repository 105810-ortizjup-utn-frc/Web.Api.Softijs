/****** Object:  Table [dbo].[Autorizaciones]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autorizaciones](
	[Id_Autorizacion] [int] IDENTITY(1,1) NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Autorizaciones] PRIMARY KEY CLUSTERED 
(
	[Id_Autorizacion] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Barrios]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barrios](
	[Id_Barrio] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Ciudad] [varchar](50) NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Barrios] PRIMARY KEY CLUSTERED 
(
	[Id_Barrio] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[Id_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id_Categoria] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudades]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudades](
	[Id_Ciudad] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Codigo_Provincia] [varchar](10) NULL,
	[Campo] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[Id_Ciudad] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[DNI] [varchar](50) NOT NULL,
	[Id_Informacion_Contacto] [int] NULL,
	[Id_Barrio] [int] NULL,
	[Id_Ciudad] [int] NULL,
	[Calle] [varchar](50) NULL,
	[Numero] [int] NULL,
	[Id_Tipo_Fidelizacion] [int] NULL,
	[Activado] [bit] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id_Cliente] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comprobantes_Pagos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comprobantes_Pagos](
	[Id_Comprobante_Pago] [int] IDENTITY(1,1) NOT NULL,
	[Nro_Comprobante] [int] NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Comprobantes_Pagos] PRIMARY KEY CLUSTERED 
(
	[Id_Comprobante_Pago] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalles_Ordenes_Pagos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_Ordenes_Pagos](
	[Id_Detalle_Orden_Pago] [int] IDENTITY(1,1) NOT NULL,
	[Id_Forma_Pago] [int] NOT NULL,
	[Id_Liquidacion] [int] NULL,
	[Id_Orden_Pago] [int] NULL,
	[Id_Comprobante_Pago] [int] NOT NULL,
	[Monto] [decimal](8, 2) NULL,
	[Id_Autorizacion_1] [int] NULL,
	[Id_Autorizacion_2] [int] NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Detalles_Ordenes_Pagos] PRIMARY KEY CLUSTERED 
(
	[Id_Detalle_Orden_Pago] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalles_Pedidos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_Pedidos](
	[Nro_Detalle_Pedido] [int] IDENTITY(1,1) NOT NULL,
	[Nro_Producto] [int] NOT NULL,
	[Nro_Pedido] [int] NOT NULL,
	[Monto] [decimal](8, 2) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Id_Pago] [int] NULL,
 CONSTRAINT [PK_Detalle_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Nro_Detalle_Pedido] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados_Ordenes_Pagos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados_Ordenes_Pagos](
	[Id_Estado_Orden_Pago] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estados_Ordenes_Pagos] PRIMARY KEY CLUSTERED 
(
	[Id_Estado_Orden_Pago] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados_Pedidos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados_Pedidos](
	[Id_Estado_Pedido] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estados_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Id_Estado_Pedido] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Formas_Pagos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formas_Pagos](
	[Id_Forma_Pago] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Formas_Pagos] PRIMARY KEY CLUSTERED 
(
	[Id_Forma_Pago] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gustos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gustos](
	[Id_Gusto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NULL,
	[Nombre] [varchar](50) NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Gustos] PRIMARY KEY CLUSTERED 
(
	[Id_Gusto] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Informaciones_Contactos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Informaciones_Contactos](
	[Id_Informacion_Contacto] [int] IDENTITY(1,1) NOT NULL,
	[Telefono] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Celular] [varchar](50) NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Informaciones_Contactos] PRIMARY KEY CLUSTERED 
(
	[Id_Informacion_Contacto] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Liquidaciones]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Liquidaciones](
	[Id_Liquidacion] [int] IDENTITY(1,1) NOT NULL,
	[Id_Usuario] [int] NOT NULL,
	[Fecha_Liquidacion] [datetime] NOT NULL,
	[Cantidad_Hora_Trabajada] [int] NOT NULL,
	[Monto_Por_Hora] [decimal](8, 2) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Liquidaciones] PRIMARY KEY CLUSTERED 
(
	[Id_Liquidacion] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[Id_Marca] [int] NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Razon_Social] [varchar](50) NOT NULL,
	[Id_Informacion_Contacto] [int] NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[Id_Marca] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordenes_Pagos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordenes_Pagos](
	[Id_Orden_Pago] [int] IDENTITY(1,1) NOT NULL,
	[Id_Tipo_Orden_Pago] [int] NOT NULL,
	[Fecha_Vencimiento] [datetime] NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Id_Estado_Orden_Pago] [int] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Ordenes_Pagos] PRIMARY KEY CLUSTERED 
(
	[Id_Orden_Pago] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[Id_Pago] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Pago] [datetime] NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Id_Forma_Pago] [int] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Pagos] PRIMARY KEY CLUSTERED 
(
	[Id_Pago] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[Nro_Pedido] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Id_Usuario] [int] NOT NULL,
	[Id_Cliente] [int] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Id_Forma_Pago] [int] NULL,
	[Id_Estado_Pedido] [int] NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Nro_Pedido] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Nro_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Fecha_Vencimiento] [datetime] NOT NULL,
	[Id_Proveedor] [int] NOT NULL,
	[Precio] [decimal](8, 2) NOT NULL,
	[Lote] [varchar](50) NOT NULL,
	[Punto_Necesario] [int] NOT NULL,
	[Punto_Otorgado] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Id_Unidad_Medida] [int] NOT NULL,
	[Id_Gusto] [int] NOT NULL,
	[Id_Marca] [int] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Id_Categoria] [int] NOT NULL,
	[Codigo] [int] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Nro_Producto] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[Id_Proveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Id_Informacion_Contacto] [int] NULL,
	[Id_Barrio] [int] NULL,
	[Id_Ciudad] [int] NULL,
	[Calle] [varchar](50) NULL,
	[Numero] [int] NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[Id_Proveedor] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[Id_Provincia] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Descripcion] [varbinary](50) NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[Id_Provincia] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puntos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puntos](
	[Id_Punto] [int] IDENTITY(1,1) NOT NULL,
	[Id_Cliente] [int] NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Nro_Producto] [int] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Puntos] PRIMARY KEY CLUSTERED 
(
	[Id_Punto] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id_Rol] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id_Rol] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Fidelizaciones]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_Fidelizaciones](
	[Id_Tipo_Fidelizacion] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Descuento] [varchar](50) NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Tipos_Fidelizaciones|] PRIMARY KEY CLUSTERED 
(
	[Id_Tipo_Fidelizacion] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Ordenes_Pagos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_Ordenes_Pagos](
	[Id_Tipo_Orden_Pago] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tipos_Ordenes_Pagos] PRIMARY KEY CLUSTERED 
(
	[Id_Tipo_Orden_Pago] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Productos]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_Productos](
	[Id_Tipo_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Tipos_Productos] PRIMARY KEY CLUSTERED 
(
	[Id_Tipo_Producto] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Usuarios]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_Usuarios](
	[Id_Tipo_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Tipos_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id_Tipo_Usuario] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unidades_Medidas]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unidades_Medidas](
	[Id_Unidad_Medida] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Unidades_Medidas] PRIMARY KEY CLUSTERED 
(
	[Id_Unidad_Medida] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Legajo] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[Id_Informacion_Contacto] [int] NULL,
	[Id_Barrio] [int] NULL,
	[Id_Ciudad] [int] NULL,
	[Calle] [varchar](50) NULL,
	[Numero] [int] NULL,
	[Id_Tipo_Usuario] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Hash_Contrasenia] [binary](70) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios_Roles]    Script Date: 13/10/2022 02:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios_Roles](
	[Id_Usuario_Rol] [int] IDENTITY(1,1) NOT NULL,
	[Id_Rol] [int] NULL,
	[Id_Usuario] [int] NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios_Roles] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario_Rol] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Barrios] ON 
GO
INSERT [dbo].[Barrios] ([Id_Barrio], [Codigo_Ciudad], [Descripcion], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Creado_Por]) VALUES (1, N'1', N'test', CAST(N'1900-01-17T00:00:00.000' AS DateTime), N'lucio', CAST(N'1900-01-17T00:00:00.000' AS DateTime), N'lucio')
GO
SET IDENTITY_INSERT [dbo].[Barrios] OFF
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 
GO
INSERT [dbo].[Categorias] ([Id_Categoria], [Codigo], [Descripcion], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Creado_Por]) VALUES (2, N'CA', N'CATEGORIA', CAST(N'2022-10-13T02:35:49.960' AS DateTime), N'jortiz', CAST(N'2022-10-13T02:35:49.980' AS DateTime), N'joritz')
GO
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Ciudades] ON 
GO
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Codigo], [Descripcion], [Codigo_Provincia], [Campo], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Creado_Por]) VALUES (1, N'1', N'test', N'1', N'test', CAST(N'1900-01-17T00:00:00.000' AS DateTime), N'lucio', CAST(N'1900-01-17T00:00:00.000' AS DateTime), N'lucio')
GO
SET IDENTITY_INSERT [dbo].[Ciudades] OFF
GO
SET IDENTITY_INSERT [dbo].[Gustos] ON 
GO
INSERT [dbo].[Gustos] ([Id_Gusto], [Codigo], [Nombre], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion]) VALUES (1, N'TEST', N'TEST', N'JUAN', CAST(N'2022-10-10T00:00:00.000' AS DateTime), N'JUAN', CAST(N'2022-10-10T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Gustos] ([Id_Gusto], [Codigo], [Nombre], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion]) VALUES (2, N'1', N'Frutilla', N'Inaki', CAST(N'2022-10-12T12:15:20.813' AS DateTime), N'Inaki', CAST(N'2022-10-12T12:15:20.813' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Gustos] OFF
GO
SET IDENTITY_INSERT [dbo].[Informaciones_Contactos] ON 
GO
INSERT [dbo].[Informaciones_Contactos] ([Id_Informacion_Contacto], [Telefono], [Email], [Celular], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion]) VALUES (1, N'4516908', N'ArcorSa@gmail.com', N'3513011413', N'Inaki', CAST(N'2022-10-12T12:25:00.010' AS DateTime), N'Inaki', CAST(N'2022-10-12T12:25:00.010' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Informaciones_Contactos] OFF
GO
INSERT [dbo].[Marcas] ([Id_Marca], [Codigo], [Nombre], [Razon_Social], [Id_Informacion_Contacto], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion]) VALUES (1, N'MA', N'MARCA', N'MARCA', NULL, N'JUAN', CAST(N'2022-10-14T00:00:00.000' AS DateTime), N'JUAN', CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Marcas] ([Id_Marca], [Codigo], [Nombre], [Razon_Social], [Id_Informacion_Contacto], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion]) VALUES (2, N'Ar', N'Arcor', N'Arcor SA', 1, N'Inaki', CAST(N'2022-10-12T12:26:22.273' AS DateTime), N'Inaki', CAST(N'2022-10-12T12:26:22.273' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 
GO
INSERT [dbo].[Productos] ([Nro_Producto], [Nombre], [Fecha_Vencimiento], [Id_Proveedor], [Precio], [Lote], [Punto_Necesario], [Punto_Otorgado], [Activo], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Id_Unidad_Medida], [Id_Gusto], [Id_Marca], [Creado_Por], [Id_Categoria], [Codigo]) VALUES (1, N'test', CAST(N'2022-10-12T12:54:17.327' AS DateTime), 1, CAST(200.00 AS Decimal(8, 2)), N'test', 13, 3, 1, CAST(N'2022-10-12T12:54:17.327' AS DateTime), N'Inaki', CAST(N'2022-10-12T12:54:17.327' AS DateTime), 1, 1, 1, N'Inaki', 2, 1)
GO
INSERT [dbo].[Productos] ([Nro_Producto], [Nombre], [Fecha_Vencimiento], [Id_Proveedor], [Precio], [Lote], [Punto_Necesario], [Punto_Otorgado], [Activo], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Id_Unidad_Medida], [Id_Gusto], [Id_Marca], [Creado_Por], [Id_Categoria], [Codigo]) VALUES (2, N'test', CAST(N'2022-10-12T12:54:17.327' AS DateTime), 1, CAST(200.00 AS Decimal(8, 2)), N'test', 13, 3, 1, CAST(N'2022-10-12T12:54:17.327' AS DateTime), N'Inaki', CAST(N'2022-10-12T12:54:17.327' AS DateTime), 1, 1, 2, N'Inaki', 2, 2)
GO
INSERT [dbo].[Productos] ([Nro_Producto], [Nombre], [Fecha_Vencimiento], [Id_Proveedor], [Precio], [Lote], [Punto_Necesario], [Punto_Otorgado], [Activo], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Id_Unidad_Medida], [Id_Gusto], [Id_Marca], [Creado_Por], [Id_Categoria], [Codigo]) VALUES (3, N'asdasd', CAST(N'2022-10-12T13:09:14.063' AS DateTime), 1, CAST(120.00 AS Decimal(8, 2)), N'AR', 16, 3, 1, CAST(N'2022-10-12T13:09:14.063' AS DateTime), N'Inaki', CAST(N'2022-10-12T13:09:14.063' AS DateTime), 1, 1, 2, N'Inaki', 2, 3)
GO
INSERT [dbo].[Productos] ([Nro_Producto], [Nombre], [Fecha_Vencimiento], [Id_Proveedor], [Precio], [Lote], [Punto_Necesario], [Punto_Otorgado], [Activo], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Id_Unidad_Medida], [Id_Gusto], [Id_Marca], [Creado_Por], [Id_Categoria], [Codigo]) VALUES (4, N'pls', CAST(N'2022-10-12T13:15:32.777' AS DateTime), 1, CAST(120.00 AS Decimal(8, 2)), N'AR', 16, 3, 1, CAST(N'2022-10-12T13:15:32.777' AS DateTime), N'Inaki', CAST(N'2022-10-12T13:15:32.777' AS DateTime), 1, 1, 2, N'Inaki', 2, 4)
GO
INSERT [dbo].[Productos] ([Nro_Producto], [Nombre], [Fecha_Vencimiento], [Id_Proveedor], [Precio], [Lote], [Punto_Necesario], [Punto_Otorgado], [Activo], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Id_Unidad_Medida], [Id_Gusto], [Id_Marca], [Creado_Por], [Id_Categoria], [Codigo]) VALUES (6, N'string', CAST(N'2022-10-12T13:46:31.793' AS DateTime), 1, CAST(1111.00 AS Decimal(8, 2)), N'string', 111, 21, 1, CAST(N'2022-10-12T13:46:31.793' AS DateTime), N'Inaki', CAST(N'2022-10-12T13:46:31.793' AS DateTime), 1, 1, 2, N'Inaki', 2, 6)
GO
INSERT [dbo].[Productos] ([Nro_Producto], [Nombre], [Fecha_Vencimiento], [Id_Proveedor], [Precio], [Lote], [Punto_Necesario], [Punto_Otorgado], [Activo], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Id_Unidad_Medida], [Id_Gusto], [Id_Marca], [Creado_Por], [Id_Categoria], [Codigo]) VALUES (7, N'segundaprueba', CAST(N'2022-10-12T13:49:30.323' AS DateTime), 1, CAST(11.00 AS Decimal(8, 2)), N'segundaprueba', 120, 10, 1, CAST(N'2022-10-12T13:49:30.323' AS DateTime), N'Inaki', CAST(N'2022-10-12T13:49:30.323' AS DateTime), 1, 1, 1, N'Inaki', 2, 7)
GO
INSERT [dbo].[Productos] ([Nro_Producto], [Nombre], [Fecha_Vencimiento], [Id_Proveedor], [Precio], [Lote], [Punto_Necesario], [Punto_Otorgado], [Activo], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Id_Unidad_Medida], [Id_Gusto], [Id_Marca], [Creado_Por], [Id_Categoria], [Codigo]) VALUES (9, N'TEST POST 2', CAST(N'2022-10-12T13:56:08.773' AS DateTime), 1, CAST(123.00 AS Decimal(8, 2)), N'string', 200, 10, 1, CAST(N'2022-10-12T13:56:08.773' AS DateTime), N'asd', CAST(N'2022-10-12T13:56:08.773' AS DateTime), 1, 1, 2, N'string', 2, 9)
GO
INSERT [dbo].[Productos] ([Nro_Producto], [Nombre], [Fecha_Vencimiento], [Id_Proveedor], [Precio], [Lote], [Punto_Necesario], [Punto_Otorgado], [Activo], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Id_Unidad_Medida], [Id_Gusto], [Id_Marca], [Creado_Por], [Id_Categoria], [Codigo]) VALUES (17, N'string', CAST(N'2022-10-12T14:56:14.053' AS DateTime), 1, CAST(100.00 AS Decimal(8, 2)), N'string', 121, 12, 1, CAST(N'2022-10-12T14:56:14.053' AS DateTime), N'Inaki', CAST(N'2022-10-12T14:56:14.053' AS DateTime), 1, 1, 2, N'Inaki', 2, 10)
GO
INSERT [dbo].[Productos] ([Nro_Producto], [Nombre], [Fecha_Vencimiento], [Id_Proveedor], [Precio], [Lote], [Punto_Necesario], [Punto_Otorgado], [Activo], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Id_Unidad_Medida], [Id_Gusto], [Id_Marca], [Creado_Por], [Id_Categoria], [Codigo]) VALUES (18, N'string', CAST(N'2022-10-12T15:05:16.087' AS DateTime), 1, CAST(1.00 AS Decimal(8, 2)), N'string', 123, 12, 1, CAST(N'2022-10-12T15:05:16.087' AS DateTime), N'Inaki', CAST(N'2022-10-12T15:05:16.087' AS DateTime), 1, 1, 2, N'Inaki', 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 
GO
INSERT [dbo].[Proveedores] ([Id_Proveedor], [Nombre], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Creado_Por]) VALUES (1, N'Test', NULL, NULL, NULL, N'Test', 351, CAST(N'2022-10-11T00:00:00.000' AS DateTime), N'2022-10-11', CAST(N'2022-10-11T00:00:00.000' AS DateTime), N'2022-10-11')
GO
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
SET IDENTITY_INSERT [dbo].[Provincias] ON 
GO
INSERT [dbo].[Provincias] ([Id_Provincia], [Codigo], [Descripcion], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion]) VALUES (1, N'1', 0x00000001, N'lucio', CAST(N'1900-01-17T00:00:00.000' AS DateTime), N'lucio', CAST(N'1900-01-17T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Provincias] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipos_Usuarios] ON 
GO
INSERT [dbo].[Tipos_Usuarios] ([Id_Tipo_Usuario], [Codigo], [Descripcion], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion]) VALUES (1, N'1', N'1', N'lucio', CAST(N'1900-01-17T00:00:00.000' AS DateTime), N'lucio', CAST(N'1900-01-17T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Tipos_Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Unidades_Medidas] ON 
GO
INSERT [dbo].[Unidades_Medidas] ([Id_Unidad_Medida], [Descripcion], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Codigo]) VALUES (1, N'TEST', N'JUAN', CAST(N'2022-10-10T00:00:00.000' AS DateTime), N'KIAM', CAST(N'2022-10-10T00:00:00.000' AS DateTime), N'AA')
GO
SET IDENTITY_INSERT [dbo].[Unidades_Medidas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (1, N'Test', N'test', N'1', N'12@a.com', 1, 1, 1, N'prueba', 1, 1, 1, N'lucio', CAST(N'1900-01-17T00:00:00.000' AS DateTime), N'lucio', CAST(N'1900-01-17T00:00:00.000' AS DateTime), 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000007B)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (3, NULL, NULL, NULL, N'test@test.com', NULL, NULL, NULL, NULL, NULL, 1, 1, N'Lucio', CAST(N'2022-10-12T18:23:20.453' AS DateTime), N'Lucio', CAST(N'2022-10-12T18:23:20.453' AS DateTime), 0xD77B057C212C3D7942CDFE2D36E2A459578FB59A3F18B34B1B44A34FFCBCE20A0000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (19, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-12T23:04:05.583' AS DateTime), N'string', CAST(N'2022-10-12T23:04:05.583' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (20, N'string', NULL, NULL, N'123@gmail.com', NULL, NULL, NULL, NULL, NULL, 1, 1, N'string', CAST(N'2022-10-12T23:10:34.633' AS DateTime), N'string', CAST(N'2022-10-12T23:10:34.633' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (21, N'string', NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T02:57:33.483' AS DateTime), N'string', CAST(N'2022-10-13T02:57:33.483' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (22, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:02:13.627' AS DateTime), N'string', CAST(N'2022-10-13T03:02:13.627' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (23, N'string', NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:05:12.217' AS DateTime), N'string', CAST(N'2022-10-13T03:05:12.217' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (24, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:05:28.400' AS DateTime), N'string', CAST(N'2022-10-13T03:05:28.400' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (25, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:09:09.853' AS DateTime), N'string', CAST(N'2022-10-13T03:09:09.853' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (26, N'string', NULL, NULL, N'jerovera@gmail.com', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:13:10.703' AS DateTime), N'string', CAST(N'2022-10-13T03:13:10.703' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (27, N'string', NULL, NULL, N'jerovera@gmail.com', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:13:10.703' AS DateTime), N'string', CAST(N'2022-10-13T03:13:10.703' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (28, N'string', NULL, NULL, N'jerovera1026@gmail.com', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:15:11.007' AS DateTime), N'string', CAST(N'2022-10-13T03:15:11.007' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (29, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:18:49.327' AS DateTime), N'string', CAST(N'2022-10-13T03:18:49.327' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (30, N'string', NULL, NULL, N'asd', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:18:49.327' AS DateTime), N'string', CAST(N'2022-10-13T03:18:49.327' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (31, N'string', NULL, NULL, N'dfs', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:19:30.647' AS DateTime), N'string', CAST(N'2022-10-13T03:19:30.647' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (32, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:20:50.223' AS DateTime), N'string', CAST(N'2022-10-13T03:20:50.223' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (33, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:21:50.607' AS DateTime), N'string', CAST(N'2022-10-13T03:21:50.607' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (34, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:22:40.560' AS DateTime), N'string', CAST(N'2022-10-13T03:22:40.560' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (35, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:22:40.560' AS DateTime), N'string', CAST(N'2022-10-13T03:22:40.560' AS DateTime), 0xD717F800853AFCF7897C5B9389D16BC78AB75E5759FAEC6AC08325E9B20EF80D0000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (36, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:28:18.417' AS DateTime), N'string', CAST(N'2022-10-13T03:28:18.417' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (37, N'string', NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:28:37.317' AS DateTime), N'string', CAST(N'2022-10-13T03:28:37.317' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (38, N'string', NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:28:37.317' AS DateTime), N'string', CAST(N'2022-10-13T03:28:37.317' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (39, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:28:50.407' AS DateTime), N'string', CAST(N'2022-10-13T03:28:50.407' AS DateTime), 0xE3B0C44298FC1C149AFBF4C8996FB92427AE41E4649B934CA495991B7852B8550000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (40, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:28:50.407' AS DateTime), N'string', CAST(N'2022-10-13T03:28:50.407' AS DateTime), 0xE3B0C44298FC1C149AFBF4C8996FB92427AE41E4649B934CA495991B7852B8550000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (41, N'string', NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:32:30.543' AS DateTime), N'string', CAST(N'2022-10-13T03:32:30.543' AS DateTime), 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA80000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (42, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:41:29.997' AS DateTime), N'string', CAST(N'2022-10-13T03:41:29.997' AS DateTime), 0xE3B0C44298FC1C149AFBF4C8996FB92427AE41E4649B934CA495991B7852B8550000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
INSERT [dbo].[Usuarios] ([Id_Usuario], [Nombre], [Apellido], [Legajo], [Email], [Id_Informacion_Contacto], [Id_Barrio], [Id_Ciudad], [Calle], [Numero], [Id_Tipo_Usuario], [Activo], [Creado_Por], [Fecha_Creacion], [Modificado_Por], [Fecha_Modificacion], [Hash_Contrasenia]) VALUES (43, N'string', NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 1, 0, N'string', CAST(N'2022-10-13T03:43:24.430' AS DateTime), N'string', CAST(N'2022-10-13T03:43:24.430' AS DateTime), 0x74234E98AFE7498FB5DAF1F36AC2D78ACC339464F950703B8C019892F982B90B0000000000000000000000000000000000000000000000000000000000000000000000000000)
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Categorias] ADD  DEFAULT (getdate()) FOR [Fecha_Creacion]
GO
ALTER TABLE [dbo].[Categorias] ADD  DEFAULT ('jortiz') FOR [Modificado_Por]
GO
ALTER TABLE [dbo].[Categorias] ADD  DEFAULT (getdate()) FOR [Fecha_Modificacion]
GO
ALTER TABLE [dbo].[Categorias] ADD  DEFAULT ('joritz') FOR [Creado_Por]
GO
ALTER TABLE [dbo].[Comprobantes_Pagos] ADD  DEFAULT (getdate()) FOR [Fecha_Creacion]
GO
ALTER TABLE [dbo].[Comprobantes_Pagos] ADD  DEFAULT ('jortiz') FOR [Modificado_Por]
GO
ALTER TABLE [dbo].[Comprobantes_Pagos] ADD  DEFAULT (getdate()) FOR [Fecha_Modificacion]
GO
ALTER TABLE [dbo].[Comprobantes_Pagos] ADD  DEFAULT ('joritz') FOR [Creado_Por]
GO
ALTER TABLE [dbo].[Productos] ADD  DEFAULT ((0)) FOR [Codigo]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Barrios] FOREIGN KEY([Id_Barrio])
REFERENCES [dbo].[Barrios] ([Id_Barrio])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Barrios]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Ciudades] FOREIGN KEY([Id_Ciudad])
REFERENCES [dbo].[Ciudades] ([Id_Ciudad])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Ciudades]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_InformacionesContactos] FOREIGN KEY([Id_Informacion_Contacto])
REFERENCES [dbo].[Informaciones_Contactos] ([Id_Informacion_Contacto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_InformacionesContactos]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TiposFidelizaciones] FOREIGN KEY([Id_Tipo_Fidelizacion])
REFERENCES [dbo].[Tipos_Fidelizaciones] ([Id_Tipo_Fidelizacion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_TiposFidelizaciones]
GO
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos]  WITH CHECK ADD  CONSTRAINT [FK_DetallesOrdenesPagos_Autorizaciones1] FOREIGN KEY([Id_Autorizacion_1])
REFERENCES [dbo].[Autorizaciones] ([Id_Autorizacion])
GO
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos] CHECK CONSTRAINT [FK_DetallesOrdenesPagos_Autorizaciones1]
GO
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos]  WITH CHECK ADD  CONSTRAINT [FK_DetallesOrdenesPagos_Autorizaciones2] FOREIGN KEY([Id_Autorizacion_2])
REFERENCES [dbo].[Autorizaciones] ([Id_Autorizacion])
GO
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos] CHECK CONSTRAINT [FK_DetallesOrdenesPagos_Autorizaciones2]
GO
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos]  WITH CHECK ADD  CONSTRAINT [FK_DetallesOrdenesPagos_Comprobantes] FOREIGN KEY([Id_Comprobante_Pago])
REFERENCES [dbo].[Comprobantes_Pagos] ([Id_Comprobante_Pago])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos] CHECK CONSTRAINT [FK_DetallesOrdenesPagos_Comprobantes]
GO
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos]  WITH CHECK ADD  CONSTRAINT [FK_DetallesOrdenesPagos_FormasPagos] FOREIGN KEY([Id_Forma_Pago])
REFERENCES [dbo].[Formas_Pagos] ([Id_Forma_Pago])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos] CHECK CONSTRAINT [FK_DetallesOrdenesPagos_FormasPagos]
GO
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos]  WITH CHECK ADD  CONSTRAINT [FK_DetallesOrdenesPagos_Liquidaciones] FOREIGN KEY([Id_Liquidacion])
REFERENCES [dbo].[Liquidaciones] ([Id_Liquidacion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos] CHECK CONSTRAINT [FK_DetallesOrdenesPagos_Liquidaciones]
GO
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos]  WITH CHECK ADD  CONSTRAINT [FK_DetallesOrdenesPagos_OrdenesPagos] FOREIGN KEY([Id_Orden_Pago])
REFERENCES [dbo].[Ordenes_Pagos] ([Id_Orden_Pago])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos] CHECK CONSTRAINT [FK_DetallesOrdenesPagos_OrdenesPagos]
GO
ALTER TABLE [dbo].[Detalles_Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_DetallesPedidos_Pagos] FOREIGN KEY([Id_Pago])
REFERENCES [dbo].[Pagos] ([Id_Pago])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalles_Pedidos] CHECK CONSTRAINT [FK_DetallesPedidos_Pagos]
GO
ALTER TABLE [dbo].[Detalles_Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_DetallesPedidos_Pedidos] FOREIGN KEY([Nro_Pedido])
REFERENCES [dbo].[Pedidos] ([Nro_Pedido])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalles_Pedidos] CHECK CONSTRAINT [FK_DetallesPedidos_Pedidos]
GO
ALTER TABLE [dbo].[Detalles_Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_DetallesPedidos_Productos] FOREIGN KEY([Nro_Producto])
REFERENCES [dbo].[Productos] ([Nro_Producto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalles_Pedidos] CHECK CONSTRAINT [FK_DetallesPedidos_Productos]
GO
ALTER TABLE [dbo].[Liquidaciones]  WITH CHECK ADD  CONSTRAINT [FK_Liquidaciones_Usuarios] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuarios] ([Id_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Liquidaciones] CHECK CONSTRAINT [FK_Liquidaciones_Usuarios]
GO
ALTER TABLE [dbo].[Ordenes_Pagos]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesPagos_EstadosOrdenesPagos] FOREIGN KEY([Id_Estado_Orden_Pago])
REFERENCES [dbo].[Estados_Ordenes_Pagos] ([Id_Estado_Orden_Pago])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ordenes_Pagos] CHECK CONSTRAINT [FK_OrdenesPagos_EstadosOrdenesPagos]
GO
ALTER TABLE [dbo].[Ordenes_Pagos]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesPagos_TiposOrdenesPagos] FOREIGN KEY([Id_Tipo_Orden_Pago])
REFERENCES [dbo].[Tipos_Ordenes_Pagos] ([Id_Tipo_Orden_Pago])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ordenes_Pagos] CHECK CONSTRAINT [FK_OrdenesPagos_TiposOrdenesPagos]
GO
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD  CONSTRAINT [FK_Pagos_FormasPagos] FOREIGN KEY([Id_Forma_Pago])
REFERENCES [dbo].[Formas_Pagos] ([Id_Forma_Pago])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pagos] CHECK CONSTRAINT [FK_Pagos_FormasPagos]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Clientes] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Clientes] ([Id_Cliente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Clientes]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_EstadosPedidos] FOREIGN KEY([Id_Estado_Pedido])
REFERENCES [dbo].[Estados_Pedidos] ([Id_Estado_Pedido])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_EstadosPedidos]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_FormasPagos] FOREIGN KEY([Id_Forma_Pago])
REFERENCES [dbo].[Formas_Pagos] ([Id_Forma_Pago])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_FormasPagos]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Usuarios] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuarios] ([Id_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Usuarios]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Categorias] FOREIGN KEY([Id_Categoria])
REFERENCES [dbo].[Categorias] ([Id_Categoria])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Categorias]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Gustos] FOREIGN KEY([Id_Gusto])
REFERENCES [dbo].[Gustos] ([Id_Gusto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Gustos]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Marcas] FOREIGN KEY([Id_Marca])
REFERENCES [dbo].[Marcas] ([Id_Marca])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Marcas]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Proveedores] FOREIGN KEY([Id_Proveedor])
REFERENCES [dbo].[Proveedores] ([Id_Proveedor])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Proveedores]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_UnidadesMedidas] FOREIGN KEY([Id_Unidad_Medida])
REFERENCES [dbo].[Unidades_Medidas] ([Id_Unidad_Medida])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_UnidadesMedidas]
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Barrios] FOREIGN KEY([Id_Barrio])
REFERENCES [dbo].[Barrios] ([Id_Barrio])
GO
ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Barrios]
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Ciudades] FOREIGN KEY([Id_Ciudad])
REFERENCES [dbo].[Ciudades] ([Id_Ciudad])
GO
ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Ciudades]
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_InformacionesContactos] FOREIGN KEY([Id_Informacion_Contacto])
REFERENCES [dbo].[Informaciones_Contactos] ([Id_Informacion_Contacto])
GO
ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_InformacionesContactos]
GO
ALTER TABLE [dbo].[Puntos]  WITH CHECK ADD  CONSTRAINT [FK_Puntos_Clientes] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Clientes] ([Id_Cliente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Puntos] CHECK CONSTRAINT [FK_Puntos_Clientes]
GO
ALTER TABLE [dbo].[Puntos]  WITH CHECK ADD  CONSTRAINT [FK_Puntos_Productos] FOREIGN KEY([Nro_Producto])
REFERENCES [dbo].[Productos] ([Nro_Producto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Puntos] CHECK CONSTRAINT [FK_Puntos_Productos]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Barrios] FOREIGN KEY([Id_Barrio])
REFERENCES [dbo].[Barrios] ([Id_Barrio])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Barrios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Ciudades] FOREIGN KEY([Id_Ciudad])
REFERENCES [dbo].[Ciudades] ([Id_Ciudad])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Ciudades]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_InformacionesContactos] FOREIGN KEY([Id_Informacion_Contacto])
REFERENCES [dbo].[Informaciones_Contactos] ([Id_Informacion_Contacto])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_InformacionesContactos]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_TipoUsuarios] FOREIGN KEY([Id_Tipo_Usuario])
REFERENCES [dbo].[Tipos_Usuarios] ([Id_Tipo_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_TipoUsuarios]
GO
ALTER TABLE [dbo].[Usuarios_Roles]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosRoles_Roles] FOREIGN KEY([Id_Rol])
REFERENCES [dbo].[Roles] ([Id_Rol])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuarios_Roles] CHECK CONSTRAINT [FK_UsuariosRoles_Roles]
GO
ALTER TABLE [dbo].[Usuarios_Roles]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosRoles_Usuarios] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuarios] ([Id_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuarios_Roles] CHECK CONSTRAINT [FK_UsuariosRoles_Usuarios]
GO

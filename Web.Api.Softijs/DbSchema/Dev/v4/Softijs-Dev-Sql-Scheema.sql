/****** Object:  Table [dbo].[Autorizaciones]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Barrios]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Categorias]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Ciudades]    Script Date: 9/12/2022 10:47:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudades](
	[Id_Ciudad] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](100) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Codigo_Provincia] [varchar](100) NULL,
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
/****** Object:  Table [dbo].[Clientes]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Comprobantes_Pagos]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Detalles_Ordenes_Pagos]    Script Date: 9/12/2022 10:47:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_Ordenes_Pagos](
	[Id_Detalle_Orden_Pago] [int] IDENTITY(1,1) NOT NULL,
	[Id_Forma_Pago] [int] NOT NULL,
	[Id_Liquidacion] [int] NULL,
	[Id_Orden_Pago] [int] NULL,
	[Id_Comprobante_Pago] [int] NULL,
	[Monto] [decimal](8, 2) NULL,
	[Id_Autorizacion_1] [int] NULL,
	[Id_Autorizacion_2] [int] NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Id_Proveedor] [int] NULL,
 CONSTRAINT [PK_Detalles_Ordenes_Pagos] PRIMARY KEY CLUSTERED 
(
	[Id_Detalle_Orden_Pago] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalles_Pedidos]    Script Date: 9/12/2022 10:47:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_Pedidos](
	[Nro_Detalle_Pedido] [int] IDENTITY(1,1) NOT NULL,
	[Nro_Producto] [int] NOT NULL,
	[Nro_Pedido] [int] NOT NULL,
	[PrecioUnitario] [decimal](8, 2) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Detalle_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Nro_Detalle_Pedido] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados_Ordenes_Pagos]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Estados_Pedidos]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Formas_Pagos]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Gustos]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Informaciones_Contactos]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Liquidaciones]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Marcas]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Ordenes_Pagos]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Pagos]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Pedidos]    Script Date: 9/12/2022 10:47:12 ******/
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
	[Id_Estado_Pedido] [int] NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Nro_Pedido] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos_FormasPagos]    Script Date: 9/12/2022 10:47:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos_FormasPagos](
	[Id_PedidoFormasPago] [int] IDENTITY(1,1) NOT NULL,
	[Id_FormaPago] [int] NOT NULL,
	[Nro_Pedido] [int] NOT NULL,
	[Monto] [decimal](8, 2) NOT NULL,
	[Creado_Por] [varchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Modificado_Por] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_PedidoFormasPago] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 9/12/2022 10:47:12 ******/
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
	[Id_Gusto] [int] NULL,
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
/****** Object:  Table [dbo].[Proveedores]    Script Date: 9/12/2022 10:47:12 ******/
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
	[Id_Provincia] [int] NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[Id_Proveedor] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 9/12/2022 10:47:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[Id_Provincia] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](100) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
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
/****** Object:  Table [dbo].[Puntos]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Tipos_Fidelizaciones]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Tipos_Ordenes_Pagos]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Tipos_Productos]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Tipos_Usuarios]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Unidades_Medidas]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 9/12/2022 10:47:12 ******/
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
/****** Object:  Table [dbo].[Usuarios_Roles]    Script Date: 9/12/2022 10:47:12 ******/
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
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos] ADD  DEFAULT ('Pago luz') FOR [Descripcion]
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
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos]  WITH CHECK ADD  CONSTRAINT [FK_DetallesOrdenesPagos_Proveedores] FOREIGN KEY([Id_Proveedor])
REFERENCES [dbo].[Proveedores] ([Id_Proveedor])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalles_Ordenes_Pagos] CHECK CONSTRAINT [FK_DetallesOrdenesPagos_Proveedores]
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
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Usuarios] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuarios] ([Id_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Usuarios]
GO
ALTER TABLE [dbo].[Pedidos_FormasPagos]  WITH CHECK ADD  CONSTRAINT [FK_PedidosFormasPagos_FormasPagos] FOREIGN KEY([Id_FormaPago])
REFERENCES [dbo].[Formas_Pagos] ([Id_Forma_Pago])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pedidos_FormasPagos] CHECK CONSTRAINT [FK_PedidosFormasPagos_FormasPagos]
GO
ALTER TABLE [dbo].[Pedidos_FormasPagos]  WITH CHECK ADD  CONSTRAINT [FK_PedidosFormasPagos_Pedidos] FOREIGN KEY([Nro_Pedido])
REFERENCES [dbo].[Pedidos] ([Nro_Pedido])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pedidos_FormasPagos] CHECK CONSTRAINT [FK_PedidosFormasPagos_Pedidos]
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
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Provincias] FOREIGN KEY([Id_Provincia])
REFERENCES [dbo].[Provincias] ([Id_Provincia])
GO
ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Provincias]
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

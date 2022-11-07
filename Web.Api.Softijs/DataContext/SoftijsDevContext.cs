using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.DataContext
{
    public partial class SoftijsDevContext : DbContext
    {
        public SoftijsDevContext()
        {
        }

        public SoftijsDevContext(DbContextOptions<SoftijsDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autorizacione> Autorizaciones { get; set; } = null!;
        public virtual DbSet<Barrio> Barrios { get; set; } = null!;
        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Ciudade> Ciudades { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<ComprobantesPago> ComprobantesPagos { get; set; } = null!;
        public virtual DbSet<DetallesOrdenesPago> DetallesOrdenesPagos { get; set; } = null!;
        public virtual DbSet<DetallesPedido> DetallesPedidos { get; set; } = null!;
        public virtual DbSet<EstadosOrdenesPago> EstadosOrdenesPagos { get; set; } = null!;
        public virtual DbSet<EstadosPedido> EstadosPedidos { get; set; } = null!;
        public virtual DbSet<FormasPago> FormasPagos { get; set; } = null!;
        public virtual DbSet<Gusto> Gustos { get; set; } = null!;
        public virtual DbSet<InformacionesContacto> InformacionesContactos { get; set; } = null!;
        public virtual DbSet<Liquidacione> Liquidaciones { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<OrdenesPago> OrdenesPagos { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<PedidosFormasPago> PedidosFormasPagos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<Provincia> Provincias { get; set; } = null!;
        public virtual DbSet<Punto> Puntos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TiposFidelizacione> TiposFidelizaciones { get; set; } = null!;
        public virtual DbSet<TiposOrdenesPago> TiposOrdenesPagos { get; set; } = null!;
        public virtual DbSet<TiposProducto> TiposProductos { get; set; } = null!;
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; } = null!;
        public virtual DbSet<UnidadesMedida> UnidadesMedidas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuariosRole> UsuariosRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Persist Security Info=False;Data Source=2022-softijs-sql-server-dev.database.windows.net;User ID=softijs-web-api;Password=MeGustaElIceCream2022;Initial Catalog=2022-softijs-sql-db-dev");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autorizacione>(entity =>
            {
                entity.HasKey(e => e.IdAutorizacion);

                entity.Property(e => e.IdAutorizacion).HasColumnName("Id_Autorizacion");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");
            });

            modelBuilder.Entity<Barrio>(entity =>
            {
                entity.HasKey(e => e.IdBarrio);

                entity.Property(e => e.IdBarrio).HasColumnName("Id_Barrio");

                entity.Property(e => e.CodigoCiudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Ciudad");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK_Categoria");

                entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por")
                    .HasDefaultValueSql("('joritz')");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por")
                    .HasDefaultValueSql("('jortiz')");
            });

            modelBuilder.Entity<Ciudade>(entity =>
            {
                entity.HasKey(e => e.IdCiudad)
                    .HasName("PK_Localidades");

                entity.Property(e => e.IdCiudad).HasColumnName("Id_Ciudad");

                entity.Property(e => e.Campo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoProvincia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Provincia");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Dni)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.IdBarrio).HasColumnName("Id_Barrio");

                entity.Property(e => e.IdCiudad).HasColumnName("Id_Ciudad");

                entity.Property(e => e.IdInformacionContacto).HasColumnName("Id_Informacion_Contacto");

                entity.Property(e => e.IdTipoFidelizacion).HasColumnName("Id_Tipo_Fidelizacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBarrioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdBarrio)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Clientes_Barrios");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdCiudad)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Clientes_Ciudades");

                entity.HasOne(d => d.IdInformacionContactoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdInformacionContacto)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Clientes_InformacionesContactos");

                entity.HasOne(d => d.IdTipoFidelizacionNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdTipoFidelizacion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Clientes_TiposFidelizaciones");
            });

            modelBuilder.Entity<ComprobantesPago>(entity =>
            {
                entity.HasKey(e => e.IdComprobantePago);

                entity.ToTable("Comprobantes_Pagos");

                entity.Property(e => e.IdComprobantePago).HasColumnName("Id_Comprobante_Pago");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por")
                    .HasDefaultValueSql("('joritz')");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por")
                    .HasDefaultValueSql("('jortiz')");

                entity.Property(e => e.NroComprobante).HasColumnName("Nro_Comprobante");
            });

            modelBuilder.Entity<DetallesOrdenesPago>(entity =>
            {
                entity.HasKey(e => e.IdDetalleOrdenPago);

                entity.ToTable("Detalles_Ordenes_Pagos");

                entity.Property(e => e.IdDetalleOrdenPago).HasColumnName("Id_Detalle_Orden_Pago");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.IdAutorizacion1).HasColumnName("Id_Autorizacion_1");

                entity.Property(e => e.IdAutorizacion2).HasColumnName("Id_Autorizacion_2");

                entity.Property(e => e.IdComprobantePago).HasColumnName("Id_Comprobante_Pago");

                entity.Property(e => e.IdFormaPago).HasColumnName("Id_Forma_Pago");

                entity.Property(e => e.IdLiquidacion).HasColumnName("Id_Liquidacion");

                entity.Property(e => e.IdOrdenPago).HasColumnName("Id_Orden_Pago");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Descripcion");

                entity.Property(e => e.Monto).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.IdAutorizacion1Navigation)
                    .WithMany(p => p.DetallesOrdenesPagoIdAutorizacion1Navigations)
                    .HasForeignKey(d => d.IdAutorizacion1)
                    .HasConstraintName("FK_DetallesOrdenesPagos_Autorizaciones1");

                entity.HasOne(d => d.IdAutorizacion2Navigation)
                    .WithMany(p => p.DetallesOrdenesPagoIdAutorizacion2Navigations)
                    .HasForeignKey(d => d.IdAutorizacion2)
                    .HasConstraintName("FK_DetallesOrdenesPagos_Autorizaciones2");

                entity.HasOne(d => d.IdComprobantePagoNavigation)
                    .WithMany(p => p.DetallesOrdenesPagos)
                    .HasForeignKey(d => d.IdComprobantePago)
                    .HasConstraintName("FK_DetallesOrdenesPagos_Comprobantes");

                entity.HasOne(d => d.IdFormaPagoNavigation)
                    .WithMany(p => p.DetallesOrdenesPagos)
                    .HasForeignKey(d => d.IdFormaPago)
                    .HasConstraintName("FK_DetallesOrdenesPagos_FormasPagos");

                entity.HasOne(d => d.IdLiquidacionNavigation)
                    .WithMany(p => p.DetallesOrdenesPagos)
                    .HasForeignKey(d => d.IdLiquidacion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_DetallesOrdenesPagos_Liquidaciones");

                entity.HasOne(d => d.IdOrdenPagoNavigation)
                    .WithMany(p => p.DetallesOrdenesPagos)
                    .HasForeignKey(d => d.IdOrdenPago)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_DetallesOrdenesPagos_OrdenesPagos");
            });

            modelBuilder.Entity<DetallesPedido>(entity =>
            {
                entity.HasKey(e => e.NroDetallePedido)
                    .HasName("PK_Detalle_Pedidos");

                entity.ToTable("Detalles_Pedidos");

                entity.Property(e => e.NroDetallePedido).HasColumnName("Nro_Detalle_Pedido");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.NroPedido).HasColumnName("Nro_Pedido");

                entity.Property(e => e.NroProducto).HasColumnName("Nro_Producto");

                entity.HasOne(d => d.NroPedidoNavigation)
                    .WithMany(p => p.DetallesPedidos)
                    .HasForeignKey(d => d.NroPedido)
                    .HasConstraintName("FK_DetallesPedidos_Pedidos");

                entity.HasOne(d => d.NroProductoNavigation)
                    .WithMany(p => p.DetallesPedidos)
                    .HasForeignKey(d => d.NroProducto)
                    .HasConstraintName("FK_DetallesPedidos_Productos");
            });

            modelBuilder.Entity<EstadosOrdenesPago>(entity =>
            {
                entity.HasKey(e => e.IdEstadoOrdenPago);

                entity.ToTable("Estados_Ordenes_Pagos");

                entity.Property(e => e.IdEstadoOrdenPago).HasColumnName("Id_Estado_Orden_Pago");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");
            });

            modelBuilder.Entity<EstadosPedido>(entity =>
            {
                entity.HasKey(e => e.IdEstadoPedido);

                entity.ToTable("Estados_Pedidos");

                entity.Property(e => e.IdEstadoPedido).HasColumnName("Id_Estado_Pedido");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");
            });

            modelBuilder.Entity<FormasPago>(entity =>
            {
                entity.HasKey(e => e.IdFormaPago);

                entity.ToTable("Formas_Pagos");

                entity.Property(e => e.IdFormaPago).HasColumnName("Id_Forma_Pago");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");
            });

            modelBuilder.Entity<Gusto>(entity =>
            {
                entity.HasKey(e => e.IdGusto);

                entity.Property(e => e.IdGusto).HasColumnName("Id_Gusto");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InformacionesContacto>(entity =>
            {
                entity.HasKey(e => e.IdInformacionContacto);

                entity.ToTable("Informaciones_Contactos");

                entity.Property(e => e.IdInformacionContacto).HasColumnName("Id_Informacion_Contacto");

                entity.Property(e => e.Celular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Liquidacione>(entity =>
            {
                entity.HasKey(e => e.IdLiquidacion);

                entity.Property(e => e.IdLiquidacion).HasColumnName("Id_Liquidacion");

                entity.Property(e => e.CantidadHoraTrabajada).HasColumnName("Cantidad_Hora_Trabajada");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaLiquidacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Liquidacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.Property(e => e.MontoPorHora)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Monto_Por_Hora");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Liquidaciones)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Liquidaciones_Usuarios");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK_Marca");

                entity.Property(e => e.IdMarca)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Marca");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.IdInformacionContacto).HasColumnName("Id_Informacion_Contacto");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Razon_Social");
            });

            modelBuilder.Entity<OrdenesPago>(entity =>
            {
                entity.HasKey(e => e.IdOrdenPago);

                entity.ToTable("Ordenes_Pagos");

                entity.Property(e => e.IdOrdenPago).HasColumnName("Id_Orden_Pago");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Vencimiento");

                entity.Property(e => e.IdEstadoOrdenPago).HasColumnName("Id_Estado_Orden_Pago");

                entity.Property(e => e.IdTipoOrdenPago).HasColumnName("Id_Tipo_Orden_Pago");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.HasOne(d => d.IdEstadoOrdenPagoNavigation)
                    .WithMany(p => p.OrdenesPagos)
                    .HasForeignKey(d => d.IdEstadoOrdenPago)
                    .HasConstraintName("FK_OrdenesPagos_EstadosOrdenesPagos");

                entity.HasOne(d => d.IdTipoOrdenPagoNavigation)
                    .WithMany(p => p.OrdenesPagos)
                    .HasForeignKey(d => d.IdTipoOrdenPago)
                    .HasConstraintName("FK_OrdenesPagos_TiposOrdenesPagos");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago);

                entity.Property(e => e.IdPago).HasColumnName("Id_Pago");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.FechaPago)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Pago");

                entity.Property(e => e.IdFormaPago).HasColumnName("Id_Forma_Pago");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.HasOne(d => d.IdFormaPagoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdFormaPago)
                    .HasConstraintName("FK_Pagos_FormasPagos");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.NroPedido);

                entity.Property(e => e.NroPedido).HasColumnName("Nro_Pedido");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.IdEstadoPedido).HasColumnName("Id_Estado_Pedido");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Pedidos_Clientes");

                entity.HasOne(d => d.IdEstadoPedidoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEstadoPedido)
                    .HasConstraintName("FK_Pedidos_EstadosPedidos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Pedidos_Usuarios");
            });

            modelBuilder.Entity<PedidosFormasPago>(entity =>
            {
                entity.HasKey(e => e.IdPedidoFormasPago)
                    .HasName("PK__Pedidos___60AB0A5964654A2B");

                entity.ToTable("Pedidos_FormasPagos");

                entity.Property(e => e.IdPedidoFormasPago).HasColumnName("Id_PedidoFormasPago");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.IdFormaPago).HasColumnName("Id_FormaPago");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.Property(e => e.Monto).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.NroPedido).HasColumnName("Nro_Pedido");

                entity.HasOne(d => d.IdFormaPagoNavigation)
                    .WithMany(p => p.PedidosFormasPagos)
                    .HasForeignKey(d => d.IdFormaPago)
                    .HasConstraintName("FK_PedidosFormasPagos_FormasPagos");

                entity.HasOne(d => d.NroPedidoNavigation)
                    .WithMany(p => p.PedidosFormasPagos)
                    .HasForeignKey(d => d.NroPedido)
                    .HasConstraintName("FK_PedidosFormasPagos_Pedidos");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.NroProducto);

                entity.Property(e => e.NroProducto).HasColumnName("Nro_Producto");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Vencimiento");

                entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");

                entity.Property(e => e.IdGusto).HasColumnName("Id_Gusto");

                entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");

                entity.Property(e => e.IdProveedor).HasColumnName("Id_Proveedor");

                entity.Property(e => e.IdUnidadMedida).HasColumnName("Id_Unidad_Medida");

                entity.Property(e => e.Lote)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.PuntoNecesario).HasColumnName("Punto_Necesario");

                entity.Property(e => e.PuntoOtorgado).HasColumnName("Punto_Otorgado");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Productos_Categorias");

                entity.HasOne(d => d.IdGustoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdGusto)
                    .HasConstraintName("FK_Productos_Gustos");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_Productos_Marcas");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_Productos_Proveedores");

                entity.HasOne(d => d.IdUnidadMedidaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdUnidadMedida)
                    .HasConstraintName("FK_Productos_UnidadesMedidas");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.Property(e => e.IdProveedor).HasColumnName("Id_Proveedor");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.IdBarrio).HasColumnName("Id_Barrio");

                entity.Property(e => e.IdCiudad).HasColumnName("Id_Ciudad");

                entity.Property(e => e.IdInformacionContacto).HasColumnName("Id_Informacion_Contacto");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK_Proveedores_Provincias");

                entity.HasOne(d => d.IdBarrioNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdBarrio)
                    .HasConstraintName("FK_Proveedores_Barrios");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdCiudad)
                    .HasConstraintName("FK_Proveedores_Ciudades");

                entity.HasOne(d => d.IdInformacionContactoNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdInformacionContacto)
                    .HasConstraintName("FK_Proveedores_InformacionesContactos");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.IdProvincia);

                entity.Property(e => e.IdProvincia).HasColumnName("Id_Provincia");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");
            });

            modelBuilder.Entity<Punto>(entity =>
            {
                entity.HasKey(e => e.IdPunto);

                entity.Property(e => e.IdPunto).HasColumnName("Id_Punto");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.Property(e => e.NroProducto).HasColumnName("Nro_Producto");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Puntos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Puntos_Clientes");

                entity.HasOne(d => d.NroProductoNavigation)
                    .WithMany(p => p.Puntos)
                    .HasForeignKey(d => d.NroProducto)
                    .HasConstraintName("FK_Puntos_Productos");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");
            });

            modelBuilder.Entity<TiposFidelizacione>(entity =>
            {
                entity.HasKey(e => e.IdTipoFidelizacion)
                    .HasName("PK_Tipos_Fidelizaciones|");

                entity.ToTable("Tipos_Fidelizaciones");

                entity.Property(e => e.IdTipoFidelizacion).HasColumnName("Id_Tipo_Fidelizacion");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descuento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");
            });

            modelBuilder.Entity<TiposOrdenesPago>(entity =>
            {
                entity.HasKey(e => e.IdTipoOrdenPago);

                entity.ToTable("Tipos_Ordenes_Pagos");

                entity.Property(e => e.IdTipoOrdenPago).HasColumnName("Id_Tipo_Orden_Pago");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");
            });

            modelBuilder.Entity<TiposProducto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProducto);

                entity.ToTable("Tipos_Productos");

                entity.Property(e => e.IdTipoProducto).HasColumnName("Id_Tipo_Producto");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.ToTable("Tipos_Usuarios");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("Id_Tipo_Usuario");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");
            });

            modelBuilder.Entity<UnidadesMedida>(entity =>
            {
                entity.HasKey(e => e.IdUnidadMedida);

                entity.ToTable("Unidades_Medidas");

                entity.Property(e => e.IdUnidadMedida).HasColumnName("Id_Unidad_Medida");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.HashContrasenia)
                    .HasMaxLength(70)
                    .HasColumnName("Hash_Contrasenia")
                    .IsFixedLength();

                entity.Property(e => e.IdBarrio).HasColumnName("Id_Barrio");

                entity.Property(e => e.IdCiudad).HasColumnName("Id_Ciudad");

                entity.Property(e => e.IdInformacionContacto).HasColumnName("Id_Informacion_Contacto");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("Id_Tipo_Usuario");

                entity.Property(e => e.Legajo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBarrioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdBarrio)
                    .HasConstraintName("FK_Usuarios_Barrios");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdCiudad)
                    .HasConstraintName("FK_Usuarios_Ciudades");

                entity.HasOne(d => d.IdInformacionContactoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdInformacionContacto)
                    .HasConstraintName("FK_Usuarios_InformacionesContactos");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK_Usuarios_TipoUsuarios");
            });

            modelBuilder.Entity<UsuariosRole>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioRol);

                entity.ToTable("Usuarios_Roles");

                entity.Property(e => e.IdUsuarioRol).HasColumnName("Id_Usuario_Rol");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Creado_Por");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Modificacion");

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modificado_Por");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.UsuariosRoles)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UsuariosRoles_Roles");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosRoles)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UsuariosRoles_Usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        public virtual int SaveChanges(string usuario)
        {
            this.AplicarAutidoria(usuario);
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(string usuario)
        {
            this.AplicarAutidoria(usuario);
            return await base.SaveChangesAsync();
        }

        private void AplicarAutidoria(string usuario = null, bool systemChanges = false)
        {
            this.ChangeTracker?
                .Entries<IAuditable>()
                .ToList()
                .ForEach(e => this.Aplicar(e.Entity, e.State, usuario, systemChanges));
        }

        private void Aplicar(IAuditable entity, EntityState estado, string usuario, bool systemChanges = false)
        {
            var date = DateTime.Now;

            if (estado == EntityState.Added)
            {
                entity.CreadoPor = usuario;
                entity.FechaCreacion = date;

                entity.ModificadoPor = usuario;
                entity.FechaModificacion = date;
                return;
            }

            if (estado == EntityState.Modified)
            {
                entity.ModificadoPor = usuario;
                entity.FechaModificacion = date;
                return;
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

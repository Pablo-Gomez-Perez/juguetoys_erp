using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace juguetoys_erp.Models;

public partial class JuguetoysDbContext : DbContext
{
    public JuguetoysDbContext()
    {
    }

    public JuguetoysDbContext(DbContextOptions<JuguetoysDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<PCliente> PClientes { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PermisosXRol> PermisosXRols { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductosXCompra> ProductosXCompras { get; set; }

    public virtual DbSet<ProductosXVenta> ProductosXVentas { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__compras__C4BAA604D48139B4");

            entity.ToTable("compras");

            entity.HasIndex(e => e.FldFolioFactura, "UQ__compras__FAA74CC71087887A").IsUnique();

            entity.Property(e => e.IdCompra).HasColumnName("id_compra");
            entity.Property(e => e.FldFecha)
                .HasColumnType("date")
                .HasColumnName("fld_fecha");
            entity.Property(e => e.FldFolioFactura)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("fld_folioFactura");
            entity.Property(e => e.FldTotal)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("fld_total");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_compras_empleados");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_compras_proveedor");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__empleado__88B513942746524A");

            entity.ToTable("empleados");

            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.FldActivo).HasColumnName("fld_activo");
            entity.Property(e => e.FldDireccion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("fld_direccion");
            entity.Property(e => e.FldNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fld_nombre");
            entity.Property(e => e.FldPassword)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fld_password");
            entity.Property(e => e.FldTelefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fld_telefono");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
        });

        modelBuilder.Entity<PCliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("p_clientes");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.FldDireccion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("fld_direccion");
            entity.Property(e => e.FldNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fld_nombre");
            entity.Property(e => e.FldTelefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fld_telefono");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso);

            entity.ToTable("permisos");

            entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");
            entity.Property(e => e.FldAccion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("fld_accion");
            entity.Property(e => e.FldActivo).HasColumnName("fld_activo");
            entity.Property(e => e.FldControlador)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fld_controlador");
            entity.Property(e => e.FldNombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("fld_nombre");
        });

        modelBuilder.Entity<PermisosXRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permisos__3213E83F801C14E8");

            entity.ToTable("permisos_x_rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");

            entity.HasOne(d => d.IdPermisoNavigation).WithMany(p => p.PermisosXRols)
                .HasForeignKey(d => d.IdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_permisos_x_rol_permisos");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.PermisosXRols)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_permisos_x_rol_permisos_x_rol");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__FF341C0D5A795182");

            entity.ToTable("productos");

            entity.HasIndex(e => e.FldCodigo, "UQ__producto__A85F2C38772465A5").IsUnique();

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.FldActivo).HasColumnName("fld_activo");
            entity.Property(e => e.FldCodigo)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("fld_codigo");
            entity.Property(e => e.FldCosto)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("fld_costo");
            entity.Property(e => e.FldExistencia).HasColumnName("fld_existencia");
            entity.Property(e => e.FldNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fld_nombre");
            entity.Property(e => e.FldPrecio)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("fld_precio");
        });

        modelBuilder.Entity<ProductosXCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producto__3213E83F8E9FF9F0");

            entity.ToTable("productos_x_compras");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FldCantidad).HasColumnName("fld_cantidad");
            entity.Property(e => e.FldSubtotal)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("fld_subtotal");
            entity.Property(e => e.IdCompra).HasColumnName("id_compra");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
        });

        modelBuilder.Entity<ProductosXVenta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producto__3213E83F00EBBEED");

            entity.ToTable("productos_x_ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FldCantidad).HasColumnName("fld_cantidad");
            entity.Property(e => e.FldSubTotal)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("fld_subTotal");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductosXVenta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_productos_x_ventas_productos");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.ProductosXVenta)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_productos_x_ventas_ventas");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__proveedo__8D3DFE28B4AB6CC7");

            entity.ToTable("proveedor");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.FldActivo).HasColumnName("fld_activo");
            entity.Property(e => e.FldDireccion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("fld_direccion");
            entity.Property(e => e.FldNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fld_nombre");
            entity.Property(e => e.FldTelefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fld_telefono");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("roles");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.FldDescripcion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("fld_descripcion");
            entity.Property(e => e.FldNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fld_nombre");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__ventas__459533BF67BD254C");

            entity.ToTable("ventas");

            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.FldActivo).HasColumnName("fld_activo");
            entity.Property(e => e.FldFecha)
                .HasColumnType("date")
                .HasColumnName("fld_fecha");
            entity.Property(e => e.FldTotal)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("fld_total");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ventas_p_clientes");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ventas_empleados");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

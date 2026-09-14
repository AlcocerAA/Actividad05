using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Actividad05.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EvaluacionesProveedor> EvaluacionesProveedors { get; set; }

    public virtual DbSet<FormulaProduccion> FormulaProduccions { get; set; }

    public virtual DbSet<InspeccionesCalidad> InspeccionesCalidads { get; set; }

    public virtual DbSet<MateriasPrima> MateriasPrimas { get; set; }

    public virtual DbSet<MovimientosInventario> MovimientosInventarios { get; set; }

    public virtual DbSet<OrdenesProduccion> OrdenesProduccions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-dry-fire-ax8mffcl-pooler.c-4.us-east-2.aws.neon.tech; Database=neondb; Username=neondb_owner; Password=npg_CQJX83bNhGir; SSL Mode=VerifyFull; Channel Binding=Require;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("estado_orden", new[] { "planificada", "en_proceso", "finalizada", "cancelada" })
            .HasPostgresEnum("resultado_inspeccion", new[] { "aprobado", "defectuoso", "reproceso" })
            .HasPostgresEnum("tipo_item", new[] { "materia_prima", "producto_terminado" })
            .HasPostgresEnum("tipo_movimiento", new[] { "entrada", "salida", "ajuste" });

        modelBuilder.Entity<EvaluacionesProveedor>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacion).HasName("evaluaciones_proveedor_pkey");

            entity.ToTable("evaluaciones_proveedor");

            entity.Property(e => e.IdEvaluacion).HasColumnName("id_evaluacion");
            entity.Property(e => e.CalidadInsumo).HasColumnName("calidad_insumo");
            entity.Property(e => e.FechaEvaluacion)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("fecha_evaluacion");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
            entity.Property(e => e.PrecioCompetitivo).HasColumnName("precio_competitivo");
            entity.Property(e => e.Puntualidad).HasColumnName("puntualidad");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.EvaluacionesProveedors)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("evaluaciones_proveedor_id_proveedor_fkey");
        });

        modelBuilder.Entity<FormulaProduccion>(entity =>
        {
            entity.HasKey(e => new { e.IdProducto, e.IdMateriaPrima }).HasName("formula_produccion_pkey");

            entity.ToTable("formula_produccion");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdMateriaPrima).HasColumnName("id_materia_prima");
            entity.Property(e => e.CantidadRequerida)
                .HasPrecision(10, 4)
                .HasColumnName("cantidad_requerida");

            entity.HasOne(d => d.IdMateriaPrimaNavigation).WithMany(p => p.FormulaProduccions)
                .HasForeignKey(d => d.IdMateriaPrima)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("formula_produccion_id_materia_prima_fkey");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.FormulaProduccions)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("formula_produccion_id_producto_fkey");
        });

        modelBuilder.Entity<InspeccionesCalidad>(entity =>
        {
            entity.HasKey(e => e.IdInspeccion).HasName("inspecciones_calidad_pkey");

            entity.ToTable("inspecciones_calidad");

            entity.Property(e => e.IdInspeccion).HasColumnName("id_inspeccion");
            entity.Property(e => e.CantidadDefectuosa)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad_defectuosa");
            entity.Property(e => e.CantidadInspeccionada)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad_inspeccionada");
            entity.Property(e => e.Etapa)
                .HasMaxLength(100)
                .HasColumnName("etapa");
            entity.Property(e => e.FechaInspeccion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_inspeccion");
            entity.Property(e => e.IdOrden).HasColumnName("id_orden");
            entity.Property(e => e.Inspector)
                .HasMaxLength(100)
                .HasColumnName("inspector");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");

            entity.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.InspeccionesCalidads)
                .HasForeignKey(d => d.IdOrden)
                .HasConstraintName("inspecciones_calidad_id_orden_fkey");
        });

        modelBuilder.Entity<MateriasPrima>(entity =>
        {
            entity.HasKey(e => e.IdMateriaPrima).HasName("materias_primas_pkey");

            entity.ToTable("materias_primas");

            entity.Property(e => e.IdMateriaPrima).HasColumnName("id_materia_prima");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precio_unitario");
            entity.Property(e => e.StockActual)
                .HasPrecision(12, 2)
                .HasColumnName("stock_actual");
            entity.Property(e => e.StockMinimo)
                .HasPrecision(12, 2)
                .HasColumnName("stock_minimo");
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(20)
                .HasColumnName("unidad_medida");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.MateriasPrimas)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("materias_primas_id_proveedor_fkey");
        });

        modelBuilder.Entity<MovimientosInventario>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).HasName("movimientos_inventario_pkey");

            entity.ToTable("movimientos_inventario");

            entity.Property(e => e.IdMovimiento).HasColumnName("id_movimiento");
            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad");
            entity.Property(e => e.FechaMovimiento)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_movimiento");
            entity.Property(e => e.IdMateriaPrima).HasColumnName("id_materia_prima");
            entity.Property(e => e.IdOrden).HasColumnName("id_orden");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Responsable)
                .HasMaxLength(100)
                .HasColumnName("responsable");

            entity.HasOne(d => d.IdMateriaPrimaNavigation).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.IdMateriaPrima)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("movimientos_inventario_id_materia_prima_fkey");

            entity.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.IdOrden)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("movimientos_inventario_id_orden_fkey");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("movimientos_inventario_id_producto_fkey");
        });

        modelBuilder.Entity<OrdenesProduccion>(entity =>
        {
            entity.HasKey(e => e.IdOrden).HasName("ordenes_produccion_pkey");

            entity.ToTable("ordenes_produccion");

            entity.Property(e => e.IdOrden).HasColumnName("id_orden");
            entity.Property(e => e.CantidadPlaneada)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad_planeada");
            entity.Property(e => e.CantidadProducida)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad_producida");
            entity.Property(e => e.FechaEntrega)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_entrega");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaPlanificada).HasColumnName("fecha_planificada");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.LineaProduccion)
                .HasMaxLength(100)
                .HasColumnName("linea_produccion");
            entity.Property(e => e.Responsable)
                .HasMaxLength(100)
                .HasColumnName("responsable");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.OrdenesProduccions)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ordenes_produccion_id_producto_fkey");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("productos_pkey");

            entity.ToTable("productos");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.CostoEstimado)
                .HasPrecision(10, 2)
                .HasColumnName("costo_estimado");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.StockActual)
                .HasPrecision(12, 2)
                .HasColumnName("stock_actual");
            entity.Property(e => e.StockMinimo)
                .HasPrecision(12, 2)
                .HasColumnName("stock_minimo");
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(20)
                .HasColumnName("unidad_medida");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("proveedores_pkey");

            entity.ToTable("proveedores");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.CalificacionPromedio)
                .HasPrecision(3, 2)
                .HasDefaultValue(0m)
                .HasColumnName("calificacion_promedio");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .HasColumnName("contacto");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

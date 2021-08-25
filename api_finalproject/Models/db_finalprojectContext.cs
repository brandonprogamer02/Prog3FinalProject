using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace api_finalproject.Models
{
    public partial class db_finalprojectContext : IdentityDbContext 
    {
        public db_finalprojectContext()
        {
        }

        public db_finalprojectContext(DbContextOptions<db_finalprojectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aspnetrole> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetuser> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserrole> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetalleOrden> DetalleOrdens { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<EstadoOrden> EstadoOrdens { get; set; }
        public virtual DbSet<EstadoPedido> EstadoPedidos { get; set; }
        public virtual DbSet<Orden> Ordens { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;uid=root;pwd=mysql;database=db_finalproject", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Aspnetrole>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetroleclaim>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetuser>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEnd).HasMaxLength(6);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetuserclaim>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserrole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusertoken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("aspnetusertokens");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("email");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Latitud).HasColumnName("latitud");

                entity.Property(e => e.Longitud).HasColumnName("longitud");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nombre_completo");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nombre_usuario");

                entity.Property(e => e.NumeroContacto)
                    .HasColumnType("int(11)")
                    .HasColumnName("numero_contacto");
            });

            modelBuilder.Entity<DetalleOrden>(entity =>
            {
                entity.ToTable("detalle_orden");

                entity.HasIndex(e => e.OrdenId, "orden_id");

                entity.HasIndex(e => e.ProductoId, "producto_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("int(11)")
                    .HasColumnName("cantidad");

                entity.Property(e => e.OrdenId)
                    .HasColumnType("int(11)")
                    .HasColumnName("orden_id");

                entity.Property(e => e.ProductoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("producto_id");

                entity.HasOne(d => d.Orden)
                    .WithMany(p => p.DetalleOrdens)
                    .HasForeignKey(d => d.OrdenId)
                    .HasConstraintName("detalle_orden_ibfk_1");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetalleOrdens)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("detalle_orden_ibfk_2");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<EstadoOrden>(entity =>
            {
                entity.ToTable("estado_orden");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<EstadoPedido>(entity =>
            {
                entity.ToTable("estado_pedido");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("orden");

                entity.HasIndex(e => e.ClienteId, "cliente_id");

                entity.HasIndex(e => e.EstadoOrdenId, "estado_orden_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ClienteId)
                    .HasColumnType("int(11)")
                    .HasColumnName("cliente_id");

                entity.Property(e => e.ComentarioDireccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("comentario_direccion");

                entity.Property(e => e.EstadoOrdenId)
                    .HasColumnType("int(11)")
                    .HasColumnName("estado_orden_id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("orden_ibfk_2");

                entity.HasOne(d => d.EstadoOrden)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.EstadoOrdenId)
                    .HasConstraintName("orden_ibfk_1");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("pedido");

                entity.HasIndex(e => e.EstadoPedidoId, "estado_pedido_id");

                entity.HasIndex(e => e.OrdenId, "orden_id1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.EstadoPedidoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("estado_pedido_id");

                entity.Property(e => e.Latitud).HasColumnName("latitud");

                entity.Property(e => e.Longitud).HasColumnName("longitud");

                entity.Property(e => e.OrdenId)
                    .HasColumnType("int(11)")
                    .HasColumnName("orden_id");

                entity.HasOne(d => d.EstadoPedido)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.EstadoPedidoId)
                    .HasConstraintName("pedido_ibfk_1");

                entity.HasOne(d => d.Orden)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.OrdenId)
                    .HasConstraintName("pedido_ibfk_2");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.HasIndex(e => e.CategoriaId, "categoria_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CategoriaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_id");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("imagen");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("int(11)")
                    .HasColumnName("precio");

                entity.Property(e => e.Stock)
                    .HasColumnType("int(11)")
                    .HasColumnName("stock");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("producto_ibfk_1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("contrasena");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nombre_completo");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("nombre_usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

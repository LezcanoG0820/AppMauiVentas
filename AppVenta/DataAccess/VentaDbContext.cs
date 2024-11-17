using AppVenta.Modelos;
using AppVenta.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace AppVenta.DataAccess
{
    public class VentaDbContext : DbContext
    {

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDb = $"Filename={ConexionDb.DevolverRuta("venta.db")}";
            optionsBuilder.UseSqlite(conexionDb);
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(c => c.IdCategoria);
                entity.Property(c => c.IdCategoria).IsRequired().ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(p => p.IdProducto);
                entity.Property(p => p.IdProducto).IsRequired().ValueGeneratedOnAdd();
                entity.HasOne(p => p.RefCategoria).WithMany(c => c.Productos)
                .HasForeignKey(p => p.IdCategoria);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(v => v.IdVenta);
                entity.Property(v => v.IdVenta).IsRequired().ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(dv => dv.IdDetalleVenta);
                entity.Property(dv => dv.IdDetalleVenta).IsRequired().ValueGeneratedOnAdd();
                entity.HasOne(dv => dv.RefVenta).WithMany(v => v.RefDetalleVenta)
                .HasForeignKey(dv => dv.IdVenta);
                entity.HasOne(dv => dv.RefProducto).WithMany(p => p.RefDetalleVenta)
               .HasForeignKey(p => p.IdProducto);
            });

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { IdCategoria = 1, Nombre = "Consultas" },
                new Categoria { IdCategoria = 2, Nombre = "Farmacia" },
                new Categoria { IdCategoria = 3, Nombre = "Examenes" },
                new Categoria { IdCategoria = 4, Nombre = "Emergencias" },
                new Categoria { IdCategoria = 5, Nombre = "Servicio al cliente" },
                new Categoria { IdCategoria = 6, Nombre = "Informacion" }
                );


            modelBuilder.Entity<Producto>().HasData(
                new Producto
                    {
                        IdProducto = 1,
                        Codigo = "111111",
                        Nombre = "Agendar cita",
                        IdCategoria = 1,
                        Cantidad= 20,
                        Precio = 2500
                    },
               
                new Producto
                {
                    IdProducto = 4,
                    Codigo = "444444",
                    Nombre = "Panadol",
                    IdCategoria = 2,
                    Cantidad = 25,
                    Precio = 1050
                },
                new Producto
                {
                    IdProducto = 5,
                    Codigo = "555555",
                    Nombre = "Advil",
                    IdCategoria = 2,
                    Cantidad = 15,
                    Precio = 1400
                },
                new Producto
                {
                    IdProducto = 6,
                    Codigo = "666666",
                    Nombre = "Enterogermina",
                    IdCategoria = 2,
                    Cantidad = 18,
                    Precio = 1350
                },
                new Producto
                {
                    IdProducto = 7,
                    Codigo = "777777",
                    Nombre = "Dolor de cabeza",
                    IdCategoria = 3,
                    Cantidad = 30,
                    Precio = 800
                },
                new Producto
                {
                    IdProducto = 8,
                    Codigo = "888888",
                    Nombre = "Dolor de estomago",
                    IdCategoria = 3,
                    Cantidad = 20,
                    Precio = 1000
                },
                new Producto
                {
                    IdProducto = 9,
                    Codigo = "999999",
                    Nombre = "Depresion post-parciales",
                    IdCategoria = 3,
                    Cantidad = 20,
                    Precio = 1000
                },
                new Producto
                {
                    IdProducto = 10,
                    Codigo = "101010",
                    Nombre = "Hueso roto",
                    IdCategoria = 4,
                    Cantidad = 20,
                    Precio = 800
                },
                new Producto
                {
                    IdProducto = 11,
                    Codigo = "111110",
                    Nombre = "Lesion Grave",
                    IdCategoria = 4,
                    Cantidad = 20,
                    Precio = 680
                },
                new Producto
                {
                    IdProducto = 12,
                    Codigo = "121212",
                    Nombre = "Partirse la pata jugando voleibol",
                    IdCategoria = 4,
                    Cantidad = 25,
                    Precio = 950
                },
                new Producto
                {
                    IdProducto = 13,
                    Codigo = "131313",
                    Nombre = "Servicio al cliente",
                    IdCategoria = 5,
                    Cantidad = 20,
                    Precio = 200
                },
               
                new Producto
                {
                    IdProducto = 15,
                    Codigo = "151515",
                    Nombre = "Informacion",
                    IdCategoria = 6,
                    Cantidad = 25,
                    Precio = 260
                }
                );
        }


    }
}

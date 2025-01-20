using MagicVilla_API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Nombre = "Villa Real",
                    Detalle = "Detalle de la Villa...",
                    Tarifa = 200,
                    Ocupantes = 5,
                    MetrosCuadrados = 50,
                    ImagenUrl = "",
                    Amenidad = "",
                    FechaCreacion = System.DateTime.Now,
                    FechaActualizacion = System.DateTime.Now
                },
                new Villa
                {
                    Id = 2,
                    Nombre = "Premium vista a la piscina",
                    Detalle = "Detalle de la villa 2",
                    Tarifa = 150,
                    Ocupantes = 4,
                    MetrosCuadrados = 40,
                    ImagenUrl = "",
                    Amenidad = "",
                    FechaCreacion = System.DateTime.Now,
                    FechaActualizacion = System.DateTime.Now
                }
            );
        }
    }

}

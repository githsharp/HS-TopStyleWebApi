using Microsoft.EntityFrameworkCore;

namespace HS_TopStyleWebApi.Repos.Entities
{
    public class ProductContext: DbContext
    {

        //En konstruktor måste sättas upp så här. Gör att man kan skicka in tex en connectionsträng
        //för att kommunicera med databasen som skapas

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        //Detta är mappningen mellan de entitetsklasser som finns och databasen

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}

//Detta kommando lägger en migration i en speciell mapp som vi styr 
//add-migration createHS-TopStyle -o Repos\Migrations

//Att uppdatera eller skapa en databas utifrån en migration
//update-database

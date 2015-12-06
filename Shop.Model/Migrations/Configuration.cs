using System.Collections.Generic;
using System.Linq;
using Shop.Model.Models;

namespace Shop.Model.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopContext context)
        {


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Komputery", Properties = new List<string> { "Producent", "Rok produkcji", "Model"} },
                new Category { Name = "Tablety", Properties = new List<string> { "Producent", "Rok produkcji", "Model",
                    "Przek�tna ekranu", "Szybko�� taktowania procesora(GHz)", "Rozmiar pami�ci RAM(MB)", "Pami�� wewn�trzna(GB)" } },
                new Category { Name = "Telefony", Properties = new List<string> { "Producent", "Rok produkcji", "Model" } });
            context.SaveChanges();
            Category computers = context.Categories.SingleOrDefault(x => x.Name == "Komputery");
            //Category tablets = context.Categories.SingleOrDefault(x => x.Name == "Tablety");
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Procesory", BaseCategory = computers, Properties = new List<string> { "Producent", "Rok produkcji", "Model", "Cz�stotliwo�� taktowania", "Pami�c cache(MB)" } },
                new Category { Name = "Pami�ci RAM", BaseCategory = computers, Properties = new List<string> { "Producent", "Rok produkcji", "Model", "Cz�stotliwo�� taktowania", "Rozmiar(MB)", "Typ" } },
                new Category { Name = "Monitory", BaseCategory = computers, Properties = new List<string> { "Producent", "Rok produkcji", "Model", "Przek�tna ekranu" } });
            context.SaveChanges();
            Category phones = context.Categories.SingleOrDefault(x => x.Name == "Telefony");
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Stacjonarne", BaseCategory = phones, Properties = new List<string> { "Producent", "Rok produkcji", "Model" } },
                new Category { Name = "Kom�rkowe", BaseCategory = phones, Properties = new List<string> { "Producent", "Rok produkcji", "Model", "Przek�tna ekranu" } });
            context.SaveChanges();
            Category mobiles = context.Categories.SingleOrDefault(x => x.Name == "Kom�rkowe");
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Tradycyjne", BaseCategory = mobiles, Properties = new List<string> { "Producent", "Rok produkcji", "Model", "Przek�tna ekranu", "Ilo�� mo�liwych numer�w" } },
                new Category { Name = "Dotykowe", BaseCategory = mobiles, Properties = new List<string> { "Producent", "Rok produkcji", "Model", "Przek�tna ekranu", "Wbudowana pami��(MB)" } });
            context.SaveChanges();
        }
    }
}

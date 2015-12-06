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
                    "Przek¹tna ekranu", "Szybkoœæ taktowania procesora(GHz)", "Rozmiar pamiêci RAM(MB)", "Pamiêæ wewnêtrzna(GB)" } },
                new Category { Name = "Telefony", Properties = new List<string> { "Producent", "Rok produkcji", "Model" } });
            context.SaveChanges();
            Category computers = context.Categories.SingleOrDefault(x => x.Name == "Komputery");
            //Category tablets = context.Categories.SingleOrDefault(x => x.Name == "Tablety");
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Procesory", BaseCategory = computers, Properties = new List<string> { "Producent", "Rok produkcji", "Model", "Czêstotliwoœæ taktowania", "Pamiêc cache(MB)" } },
                new Category { Name = "Pamiêci RAM", BaseCategory = computers, Properties = new List<string> { "Producent", "Rok produkcji", "Model", "Czêstotliwoœæ taktowania", "Rozmiar(MB)", "Typ" } },
                new Category { Name = "Monitory", BaseCategory = computers, Properties = new List<string> { "Producent", "Rok produkcji", "Model", "Przek¹tna ekranu" } });
            context.SaveChanges();
            Category phones = context.Categories.SingleOrDefault(x => x.Name == "Telefony");
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Stacjonarne", BaseCategory = phones, Properties = new List<string> { "Producent", "Rok produkcji", "Model" } },
                new Category { Name = "Komórkowe", BaseCategory = phones, Properties = new List<string> { "Producent", "Rok produkcji", "Model", "Przek¹tna ekranu" } });
            context.SaveChanges();
            Category mobiles = context.Categories.SingleOrDefault(x => x.Name == "Komórkowe");
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Tradycyjne", BaseCategory = mobiles, Properties = new List<string> { "Producent", "Rok produkcji", "Model", "Przek¹tna ekranu", "Iloœæ mo¿liwych numerów" } },
                new Category { Name = "Dotykowe", BaseCategory = mobiles, Properties = new List<string> { "Producent", "Rok produkcji", "Model", "Przek¹tna ekranu", "Wbudowana pamiêæ(MB)" } });
            context.SaveChanges();
        }
    }
}

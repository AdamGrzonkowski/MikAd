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
            _InitCategories(context);
            _InitProducts(context);
            
        }

        private void _InitCategories(ShopContext context)
        {
            Category baseCategory = new Category
            {
                Name = "Wszystkie produkty",
                Properties = new List<string> {"Producent", "Rok produkcji", "Model"}
            };
            context.Categories.AddOrUpdate(p => p.Name, baseCategory);
            context.SaveChanges();
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Komputery", BaseCategory = baseCategory, Properties = baseCategory.Properties },
                new Category { Name = "Tablety", BaseCategory = baseCategory, Properties = baseCategory.Properties.Concat(new List<string> { "Przek�tna ekranu", "Szybko�� taktowania procesora(GHz)", "Rozmiar pami�ci RAM(MB)", "Pami�� wewn�trzna(GB)" }).ToList() },
                new Category { Name = "Telefony", BaseCategory = baseCategory, Properties = baseCategory.Properties });
            context.SaveChanges();
            Category computers = context.Categories.SingleOrDefault(x => x.Name == "Komputery");
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Procesory", BaseCategory = computers, Properties = computers.Properties.Concat(new List<string> { "Cz�stotliwo�� taktowania", "Pami�c cache(MB)" }).ToList() },
                new Category { Name = "Pami�ci RAM", BaseCategory = computers, Properties = computers.Properties.Concat(new List<string> { "Cz�stotliwo�� taktowania", "Rozmiar(MB)", "Typ" }).ToList() },
                new Category { Name = "Monitory", BaseCategory = computers, Properties = computers.Properties.Concat(new List<string> { "Przek�tna ekranu" }).ToList() });
            context.SaveChanges();
            Category phones = context.Categories.SingleOrDefault(x => x.Name == "Telefony");
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Stacjonarne", BaseCategory = phones, Properties = phones.Properties },
                new Category { Name = "Kom�rkowe", BaseCategory = phones, Properties = phones.Properties.Concat(new List<string> { "Przek�tna ekranu" }).ToList() });
            context.SaveChanges();
            Category mobiles = context.Categories.SingleOrDefault(x => x.Name == "Kom�rkowe");
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Tradycyjne", BaseCategory = mobiles, Properties = mobiles.Properties.Concat(new List<string> { "Przek�tna ekranu", "Ilo�� mo�liwych numer�w" }).ToList() },
                new Category { Name = "Dotykowe", BaseCategory = mobiles, Properties = mobiles.Properties.Concat(new List<string> { "Przek�tna ekranu", "Wbudowana pami��(MB)" }).ToList() });
            context.SaveChanges();
        }

        private void _InitProducts(ShopContext context)
        {
            
        }
    }
}

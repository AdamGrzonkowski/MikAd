using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.Model.Models;


namespace Shop.Model.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ShopContext context)
        {   
            
            _InitAdminUser(context);
            //_InitCategories(context);
            //_InitProducts(context);   
        }

        private void _InitAdminUser(ShopContext context)
        {
            //Stw�rz rol� admina
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User();

                user.Email = "Sklep_MVC@wp.pl";
                user.EmailConfirmed = true;
                user.UserName = "admin";
                var password = "admin";

                var hash = new PasswordHasher();
                user.PasswordHash = hash.HashPassword(password);
                user.SecurityStamp = "blabla";

                manager.Create(user);

                manager.AddToRole(user.Id, "admin");
            }
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
            Category computers = context.Categories.SingleOrDefault(x => x.Name.Equals("Komputery"));
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Procesory", BaseCategory = computers, Properties = computers.Properties.Concat(new List<string> { "Cz�stotliwo�� taktowania", "Pami�c cache(MB)" }).ToList() },
                new Category { Name = "Pami�ci RAM", BaseCategory = computers, Properties = computers.Properties.Concat(new List<string> { "Cz�stotliwo�� taktowania", "Rozmiar(MB)", "Typ" }).ToList() },
                new Category { Name = "Monitory", BaseCategory = computers, Properties = computers.Properties.Concat(new List<string> { "Przek�tna ekranu" }).ToList() });
            context.SaveChanges();
            Category phones = context.Categories.SingleOrDefault(x => x.Name.Equals("Telefony"));
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Telefony stacjonarne", BaseCategory = phones, Properties = phones.Properties },
                new Category { Name = "Telefony kom�rkowe", BaseCategory = phones, Properties = phones.Properties.Concat(new List<string> { "Przek�tna ekranu" }).ToList() });
            context.SaveChanges();
            Category mobiles = context.Categories.SingleOrDefault(x => x.Name.Equals("Telefony kom�rkowe"));
            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "Kom�rkowe tradycyjne", BaseCategory = mobiles, Properties = mobiles.Properties.Concat(new List<string> { "Przek�tna ekranu(cale)", "Ilo�� mo�liwych numer�w" }).ToList() },
                new Category { Name = "Kom�rkowe dotykowe", BaseCategory = mobiles, Properties = mobiles.Properties.Concat(new List<string> { "Przek�tna ekranu(cale)", "Wbudowana pami��(MB)" }).ToList() });
            context.SaveChanges();
        }

        private void _InitProducts(ShopContext context)
        {
            // Category ramMemories = context.Categories.SingleOrDefault(x => x.Name.Equals("Pami�ci RAM"));
            Category normalMobiles = context.Categories.SingleOrDefault(x => x.Name.Equals("Kom�rkowe tradycyjne"));

            context.Products.AddOrUpdate(
                p => p.Name,
                new Product
                {
                    Name = "Nokia 3310",
                    Description = "Telefon, jak ka�dy inny.",
                    Amount = 13,
                    Price = 19.99M,
                    Properties = new Dictionary<string, string> { {"Producent", "Nokia"}, {"Rok produkcji", "1999"}, {"Model", "3310" }, {"Przek�tna ekranu(cale)", "2"}, {"Wbudowana pami��(MB)", "0"} },
                    Category = normalMobiles
                },
                new Product
                {
                    Name = "Sony Ericsson K750i",
                    Description = "Telefon, jak ka�dy inny.",
                    Amount = 13,
                    Price = 19.99M,
                    Properties = new Dictionary<string, string> { { "Producent", "Sony Ericsson" }, { "Rok produkcji", "2007" }, { "Model", "K750i" }, { "Przek�tna ekranu(cale)", "2" }, { "Wbudowana pami��(MB)", "64" } },
                    Category = normalMobiles
                },
                new Product
                {
                    Name = "Nokia 3510",
                    Description = "To ju� badziew z kolorowym wy�wietlaczem.",
                    Amount = 13,
                    Price = 29.99M,
                    Properties = new Dictionary<string, string> { { "Producent", "Nokia" }, { "Rok produkcji", "1999" }, { "Model", "3310" }, { "Przek�tna ekranu(cale)", "2" }, { "Wbudowana pami��(MB)", "0" } },
                    Category = normalMobiles
                });
            context.SaveChanges();
        }
    }
}

using Foodee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Persistence.Context
{
    public class FoodeeContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-68GKB9L\\SQLEXPRESS;initial Catalog=Foodee;integrated Security=true;TrustServerCertificate=true;");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
    }
}

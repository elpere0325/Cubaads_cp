using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DbCubaAdContext : DbContext
    {
        public DbCubaAdContext(DbContextOptions<DbCubaAdContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Business> Businesses => Set<Business>();
        public DbSet<AppClient> AppClients => Set<AppClient>();
        public DbSet<Ad> Ads => Set<Ad>();
        public DbSet<AdView> AdViews => Set<AdView>();
        public DbSet<Campain> Campains => Set<Campain>();
        public DbSet<ClickEvent> ClickEvents => Set<ClickEvent>();
        public DbSet<Pricing> Pricings => Set<Pricing>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Business
            modelBuilder.Entity<User>()
        }



    }
}


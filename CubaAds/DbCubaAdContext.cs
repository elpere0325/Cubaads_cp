using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace CubaAds.Context
{
    public class DbCubaAdContext : DbContext
    {
        public DbCubaAdContext(DbContextOptions<DbCubaAdContext> options) : base(options) { }

        #region creacion de tablas
        public DbSet<User> Users => Set<User>();
        public DbSet<Business> Businesses => Set<Business>();
        public DbSet<AppClient> AppClients => Set<AppClient>();
        public DbSet<Ad> Ads => Set<Ad>();
        public DbSet<AdView> AdViews => Set<AdView>();
        public DbSet<Campain> Campains => Set<Campain>();
        public DbSet<ClickEvent> ClickEvents => Set<ClickEvent>();
        public DbSet<Pricing> Pricings => Set<Pricing>();

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Conversion de enums
            //Enums, conversion de valor su rrepresentacion en string
            //users
            modelBuilder.Entity<User>()
                .Property(u => u.rol)
                .HasConversion<string>();
            //ads
            modelBuilder.Entity<Ad>()
                .Property(a => a.media_type)
                .HasConversion<string>();

            modelBuilder.Entity<Ad>()
                .Property(a => a.status)
                .HasConversion<string>();
            
            modelBuilder.Entity<Ad>()
                .Property(a => a.ad_type)
                .HasConversion<string>();         

            //appclient
            modelBuilder.Entity<AppClient>()
                .Property(ac => ac.app_type)
                .HasConversion<string>();

            //campain
            modelBuilder.Entity<Campain>()
                .Property(c => c.allowed_app_type)
                .HasConversion<string>();

            //pricing
            modelBuilder.Entity<Pricing>()
                .Property(p => p.app_type)
                .HasConversion<string>();

            modelBuilder.Entity<Pricing>()
                .Property(p => p.ad_type)
                .HasConversion<string>();

            #endregion


            #region Claves primarias
            modelBuilder.Entity<Ad>()
                .HasKey(a => a.id);

            modelBuilder.Entity<AdView>()
                .HasKey(av => av.id);

            modelBuilder.Entity<AppClient>()
                .HasKey(ac => ac.id);

            modelBuilder.Entity<Business>()
                .HasKey(b => b.id);

            modelBuilder.Entity<Campain>()
                .HasKey(c => c.id);

            modelBuilder.Entity<ClickEvent>()
                .HasKey(ce => ce.id);

            modelBuilder.Entity<Pricing>()
                .HasKey(p => p.id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.id);
            #endregion


            #region Desarrollo de relaciones de claves primarias con claves foraneas
            //Desarrollo de relaciones entre clave directa y claves foraneas
            //Users
            modelBuilder.Entity<Business>()
                .HasOne(b => b.user)
                .WithMany(u => u.Businesses)
                .HasForeignKey(b => b.user_id)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<AppClient>()
                .HasOne(ap  => ap.user)
                .WithMany(u => u.AppClients)
                .HasForeignKey(ap =>  ap.user_id)
                .OnDelete(DeleteBehavior.Cascade);

            //Busienesses
            modelBuilder.Entity<Ad>()
                .HasOne(a => a.business)
                .WithMany(b => b.Ads)
                .HasForeignKey(a => a.business_id)  
                .OnDelete(DeleteBehavior.Cascade);

            //Ads
            modelBuilder.Entity<AdView>()
                .HasOne(av => av.ad)
                .WithMany(a => a.Adviews)
                .HasForeignKey(av => av.ad_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Campain>()
                .HasOne(c => c.ad)
                .WithMany(a => a.Campains)
                .HasForeignKey(c => c.ad_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ClickEvent>()
                .HasOne(ce => ce.ad)
                .WithMany(a => a.ClickEvents)
                .HasForeignKey(ce => ce.ad_id)
                .OnDelete(DeleteBehavior.Cascade);

            //AppClient
            modelBuilder.Entity<AdView>()
                .HasOne(av => av.ad)
                .WithMany(a => a.Adviews)
                .HasForeignKey(av => av.ad_id)
                .OnDelete(DeleteBehavior.Cascade);
                
            modelBuilder.Entity<ClickEvent>()
                .HasOne(ce => ce.ad)
                .WithMany(a => a.ClickEvents)
                .HasForeignKey(ce => ce.ad_id)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion


            #region Campos unicos
            modelBuilder.Entity<User>()
                .HasIndex(u => u.email)
                .IsUnique();

            modelBuilder.Entity<Business>()
                .HasIndex(b => b.contact_email)
                .IsUnique();

            modelBuilder.Entity<AppClient>()
                .HasIndex(ac => ac.api_key)
                .IsUnique();
            #endregion


        }



    }
}


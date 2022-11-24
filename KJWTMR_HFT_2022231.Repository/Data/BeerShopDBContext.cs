using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_HTF_2022231.Models.Data
{
    public class BeerShopDBContext : DbContext
    {
        public virtual DbSet<Beer> Beers { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        public BeerShopDBContext()
        {
            this.Database.EnsureCreated();
        }

        public BeerShopDBContext(DbContextOptions<BeerShopDBContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseInMemoryDatabase("BeerShop")
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>(entity =>
            {
                entity.HasOne(beer => beer.Brand)
                    .WithMany(brand => brand.Beers)
                    .HasForeignKey(beer => beer.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Beer>(entity =>
            {
                entity.HasOne(beer => beer.Type)
                    .WithMany(type => type.Beers)
                    .HasForeignKey(beer => beer.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            //brands
            Brand soproni = new Brand() { Id = 1, Name="Soproni" };
            Brand borsodi = new Brand() { Id = 2, Name= "Borsodi" };
            Brand staropramen = new Brand() { Id = 3, Name= "Staropramen" };
            Brand heineken = new Brand() { Id = 4, Name= "Heineken" };
            Brand dreher = new Brand() { Id = 5, Name= "Dreher" };
            Brand pecsi = new Brand() { Id = 6, Name= "Pécsi" };
            Brand tuborg = new Brand() { Id = 7, Name= "Tuborg" };
            //types
            Type ipa = new Type() { Id=1, TypeName="Ipa", Alcohol_Content=6 };
            Type meggy = new Type() { Id=2, TypeName= "Meggy sör", Alcohol_Content=4 };
            Type barna = new Type() { Id=3, TypeName= "Barna sör", Alcohol_Content=5 };
            Type vilagos = new Type() { Id=4, TypeName= "Világos sör", Alcohol_Content=4 };
            Type buza = new Type() { Id=5, TypeName= "Búza sör", Alcohol_Content=4 };

            //beers
                //sopronis
            Beer soproni_vilagos = new Beer() { Id=1, BrandId=soproni.Id, Price=280, TypeId=vilagos.Id };
            Beer soproni_barna = new Beer() { Id=2, BrandId=soproni.Id, Price=375, TypeId=barna.Id };
            Beer soproni_ipa = new Beer() { Id=3, BrandId=soproni.Id, Price=375, TypeId=ipa.Id };
            Beer soproni_meggy = new Beer() { Id=4, BrandId=soproni.Id, Price=375, TypeId=meggy.Id };
            Beer soproni_buza = new Beer() { Id=5, BrandId=soproni.Id, Price=375, TypeId=buza.Id };
                //borsodis
            Beer borsodi_vilagos = new Beer() { Id=6, BrandId=borsodi.Id, Price=305, TypeId=vilagos.Id };
            Beer borsodi_ipa = new Beer() { Id=7, BrandId=borsodi.Id, Price=375, TypeId=ipa.Id };
            Beer borsodi_meggy = new Beer() { Id=8, BrandId=borsodi.Id, Price=375, TypeId=meggy.Id };
                //staropramens
            Beer staropramen_vilagos = new Beer() { Id = 9, BrandId = staropramen.Id, Price = 345, TypeId = vilagos.Id };
            Beer staropramen_barna = new Beer() { Id = 10, BrandId = staropramen.Id, Price = 345, TypeId = barna.Id };
                //heineken
            Beer heineken_vilagos = new Beer() { Id = 11, BrandId = heineken.Id, Price = 360, TypeId = vilagos.Id };
                //dreher
            Beer dreher_vilagos = new Beer() { Id = 12, BrandId = dreher.Id, Price = 300, TypeId = vilagos.Id };
                //pécsi
            Beer pecsi_buza = new Beer() { Id = 13, BrandId = pecsi.Id, Price = 375, TypeId = buza.Id };
                //tuborg
            Beer tuborg_buza = new Beer() { Id = 14, BrandId = tuborg.Id, Price = 310, TypeId = buza.Id };

            modelBuilder.Entity<Beer>().HasData(soproni_vilagos, soproni_barna, soproni_ipa, soproni_meggy, soproni_buza,
                borsodi_vilagos, borsodi_ipa, borsodi_meggy, staropramen_vilagos, staropramen_barna,
                heineken_vilagos, dreher_vilagos, pecsi_buza, tuborg_buza);

            modelBuilder.Entity<Brand>().HasData(soproni,borsodi,staropramen,heineken,dreher,pecsi,tuborg);

            modelBuilder.Entity<Type>().HasData(ipa,meggy,barna,vilagos,buza);
        }

    }
}

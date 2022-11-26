using KJWTMR_HTF_2022231.Logic.Interfaces;
using KJWTMR_HTF_2022231.Models;
using KJWTMR_HTF_2022231.Models.Interfaces;
using KJWTMR_HTF_2022231.Models.Non_Crud_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

namespace KJWTMR_HTF_2022231.Logic
{
    public  class BeerLogic : IBeerLogic
    {
        IRepository<Beer> repository;

        public BeerLogic(IRepository<Beer> repository)
        {          
            this.repository = repository;
        }

        public void Create(Beer item)
        {                     
            this.repository.Create(item);
        }
        public Beer Read(int id)
        {
            var beer = this.repository.Read(id);
            if (beer == null)
            {
                throw new ArgumentException("Beer not exists!");
            }
            return beer;
        }
        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public IEnumerable<Beer> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Beer item)
        {
            this.repository.Update(item);
        }

        public double AVGPrice()
        {
            return this.repository.ReadAll()
                .Average(t => t.Price);
        }

        //Non-Cruds
        public IEnumerable<BrandAvgPriceStatistics> BrandsAvgPrice()
        {
            return from beer in this.repository.ReadAll()
                   group beer by beer.Brand.Name into grp
                   select new BrandAvgPriceStatistics() { Name = grp.Key, AvgPrice = grp.Average(x => x.Price) };
        }
        public IEnumerable<TypeAvgPriceStatistics> TypesAvgPrice()
        {
            return from beer in this.repository.ReadAll()
                   group beer by beer.Type.TypeName into grp
                   select new TypeAvgPriceStatistics() { Name = grp.Key, AvgPrice = grp.Average(x => x.Price) };
        }      
        public IEnumerable<BrandsBeerCountStatistics> BrandsBeerCount()
        {
            return from beer in this.repository.ReadAll()
                   group beer by beer.Brand.Name into grp
                   select new BrandsBeerCountStatistics() { Name = grp.Key, BeerCount = grp.Count() };
        }
        public IEnumerable<TypesBeerCountStatistics> TypesBeerCount()
        {
            return from beer in this.repository.ReadAll()
                   group beer by beer.Type.TypeName into grp
                   select new TypesBeerCountStatistics() { Name = grp.Key, BeerCount = grp.Count() };
        }
        public IEnumerable<MostExpensiveBeerPerBrandStatistics> MostExpensiveBeerPerBrand()
        {
            return from beer in this.repository.ReadAll()
                   group beer by beer.Brand.Name into grp
                   select new MostExpensiveBeerPerBrandStatistics() { Name=grp.Key, Price=grp.Max(x=>x.Price)};
        }

    }        
}

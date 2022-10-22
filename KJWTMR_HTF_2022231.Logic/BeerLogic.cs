﻿using KJWTMR_HTF_2022231.Models;
using KJWTMR_HTF_2022231.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace KJWTMR_HTF_2022231.Logic
{
    public  class BeerLogic : IBeerShopLogic<Beer>
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

        //Non-Cruds
        //public IQueryable<string> BeerPricesAndBrandNames()
        //{
        //    return this.repository
        //        .ReadAll()
        //        .Select(b => $"{b.Price} from {b.Brand.Name}");
        //}

        public IEnumerable<BrandAvgPriceStatistics> BrandsAvgPrice()
        {
            return from beer in this.repository.ReadAll()
                   group beer by beer.BrandId into grp
                   select new BrandAvgPriceStatistics() { BrandId = grp.Key, AvgPrice = grp.Average(x => x.Price) };
        }

        public IEnumerable<TypeAvgPriceStatistics> TypesAvgPrice()
        {
            return from beer in this.repository.ReadAll()
                   group beer by beer.TypeId into grp
                   select new TypeAvgPriceStatistics() { TypeId = grp.Key, AvgPrice = grp.Average(x => x.Price) };
        }


    }
    public class BrandAvgPriceStatistics
    {
        public int BrandId { get; set; }
        public double? AvgPrice { get; set; }
    }
    public class TypeAvgPriceStatistics
    {
        public int TypeId { get; set; }
        public double? AvgPrice { get; set; }
    }
}
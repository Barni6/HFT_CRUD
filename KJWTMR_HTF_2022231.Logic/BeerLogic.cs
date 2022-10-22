using KJWTMR_HTF_2022231.Models;
using KJWTMR_HTF_2022231.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace KJWTMR_HTF_2022231.Logic
{
    public  class BeerLogic
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
    }
}

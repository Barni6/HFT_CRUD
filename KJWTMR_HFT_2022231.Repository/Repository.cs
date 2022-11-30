using KJWTMR_HTF_2022231.Models.Data;
using KJWTMR_HTF_2022231.Models.Interfaces;
using System;
using System.Linq;

namespace KJWTMR_HFT_2022231.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected BeerShopDBContext ctx;
        public Repository(BeerShopDBContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            //ctx.Set<T>().Remove(Read(Id));
            ctx.Remove(Read(Id));
            ctx.SaveChanges();
        }    

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public abstract T Read(int Id);

        public abstract void Update(T item);
    }
}

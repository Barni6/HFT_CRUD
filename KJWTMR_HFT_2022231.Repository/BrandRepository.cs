using KJWTMR_HTF_2022231.Models;
using KJWTMR_HTF_2022231.Models.Data;
using KJWTMR_HTF_2022231.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_HFT_2022231.Repository
{
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(BeerShopDBContext ctx) : base(ctx)
        { }

        public override Brand Read(int Id)
        {
            return this.ctx.Brands.FirstOrDefault(t => t.Id == Id);
        }

        public override void Update(Brand item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}

using KJWTMR_HTF_2022231.Models;
using KJWTMR_HTF_2022231.Models.Data;
using KJWTMR_HTF_2022231.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_HFT_2022231.Repository
{
    public class BeerRepository : Repository<Beer>, IRepository<Beer>
    {
        public BeerRepository(BeerShopDBContext ctx) : base(ctx)
        { }

        public override Beer Read(int Id)
        {
            return this.ctx.Beers.FirstOrDefault(t => t.Id == Id);
        }

        public override void Update(Beer item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}

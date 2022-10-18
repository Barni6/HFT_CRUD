using KJWTMR_HTF_2022231.Models;
using KJWTMR_HTF_2022231.Models.Data;
using KJWTMR_HTF_2022231.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = KJWTMR_HTF_2022231.Models.Type;

namespace KJWTMR_HFT_2022231.Repository
{
    internal class TypeRepository : Repository<Type>, IRepository<Type>
    {
        public TypeRepository(BeerShopDBContext ctx) : base(ctx)
        { }

        public override Type Read(int Id)
        {
            return this.ctx.Types.First(t => t.Id == Id);
        }

        public override void Update(Type item)
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

using KJWTMR_HTF_2022231.Models.Interfaces;
using KJWTMR_HTF_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_HTF_2022231.Logic
{
    public class BrandLogic : IBeerShopLogic<Brand>
    {
        IRepository<Brand> repository;

        public BrandLogic(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public void Create(Brand item)
        {
            if (item.Id <=0)
            {
                throw new Exception("The Id is lower or equal with 0!");
            }
            this.repository.Create(item);
        }
        public Brand Read(int id)
        {
            var brand = this.repository.Read(id);
            if (brand == null)
            {
                throw new ArgumentException("Brand not exists!");
            }
            return brand;
        }
        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public IEnumerable<Brand> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Brand item)
        {
            this.repository.Update(item);
        }

    }
}

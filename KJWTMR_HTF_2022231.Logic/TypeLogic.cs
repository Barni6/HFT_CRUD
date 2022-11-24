using KJWTMR_HTF_2022231.Models.Interfaces;
using KJWTMR_HTF_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = KJWTMR_HTF_2022231.Models.Type;

namespace KJWTMR_HTF_2022231.Logic
{
    public class TypeLogic : IBeerShopLogic<Type>
    {
        IRepository<Type> repository;

        public TypeLogic(IRepository<Type> repository)
        {
            this.repository = repository;
        }

        public void Create(Type item)
        {
            if (item.TypeName.Length <= 1)
            {
                throw new ArgumentException("The Type name is too short!");
            }
            this.repository.Create(item);
        }
        public Type Read(int id)
        {
            var type = this.repository.Read(id);
            if (type == null)
            {
                throw new ArgumentException("Brand not exists!");
            }
            return type;
        }
        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public IEnumerable<Type> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Type item)
        {
            this.repository.Update(item);
        }
    }
}

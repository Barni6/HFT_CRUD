using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_HTF_2022231.Models.Interfaces
{
    public interface IBeerShopLogic<T> where T : class
    {
        void Create(T item);
        void Delete(int Id);
        T Read(int id);
        IEnumerable<T> ReadAll();
        void Update(T item);
    }
}

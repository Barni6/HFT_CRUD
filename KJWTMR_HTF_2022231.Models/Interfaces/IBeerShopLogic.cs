using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_HTF_2022231.Models.Interfaces
{
    public interface IBeerShopLogic
    {
        void Create(Beer item);
        void Delete(int Id);
        Beer Read(int id);
        IEnumerable<Beer> ReadAll();
        void Update(Beer item);
    }
}

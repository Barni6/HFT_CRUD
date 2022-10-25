using KJWTMR_HTF_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_HTF_2022231.Logic.Interfaces
{
    public interface IBeerLogic
    {
        void Create(Beer item);
        void Delete(int Id);
        Beer Read(int id);
        IEnumerable<Beer> ReadAll();
        void Update(Beer item);

        //Non-Cruds
        //IQueryable<string> BeerPricesAndBrandNames();
        public double AVGPrice();
        IEnumerable<BrandAvgPriceStatistics> BrandsAvgPrice();
        IEnumerable<TypeAvgPriceStatistics> TypesAvgPrice();
    }
}

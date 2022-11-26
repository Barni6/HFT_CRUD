using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_HTF_2022231.Models.Non_Crud_classes
{
    public class MostExpensiveBeerPerBrandStatistics
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public override bool Equals(object obj)
        {
            MostExpensiveBeerPerBrandStatistics b = obj as MostExpensiveBeerPerBrandStatistics;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Name == b.Name && this.Price == b.Price;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Price);
        }
        public override string ToString()
        {
            return $"Brand: {Name},  Price: {Price}";
        }
    }
}

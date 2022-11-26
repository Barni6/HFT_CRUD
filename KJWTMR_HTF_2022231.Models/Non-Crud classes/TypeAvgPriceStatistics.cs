using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_HTF_2022231.Models.Non_Crud_classes
{
    public class TypeAvgPriceStatistics
    {
        public string Name { get; set; }
        public double? AvgPrice { get; set; }

        public override bool Equals(object obj)
        {
            TypeAvgPriceStatistics b = obj as TypeAvgPriceStatistics;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Name == b.Name && this.AvgPrice == b.AvgPrice;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.AvgPrice);
        }

        public override string ToString()
        {
            return $"Type: {Name},  AvgPrice: {AvgPrice}";

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_HTF_2022231.Models.Non_Crud_classes
{
    public class BrandsBeerCountStatistics
    {
        public string Name { get; set; }
        public int BeerCount { get; set; }

        public override bool Equals(object obj)
        {
            BrandsBeerCountStatistics b = obj as BrandsBeerCountStatistics;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Name == b.Name && this.BeerCount == b.BeerCount;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.BeerCount);
        }
        public override string ToString()
        {
            return $"Brand: {Name},  BeerCount: {BeerCount}";

        }
    }
}

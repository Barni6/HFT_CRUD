using KJWTMR_HTF_2022231.Logic;
using KJWTMR_HTF_2022231.Logic.Interfaces;
using KJWTMR_HTF_2022231.Models;
using KJWTMR_HTF_2022231.Models.Non_Crud_classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KJWTMR_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBeerLogic beerLogic;
        public StatController(IBeerLogic beerLogic)
        {
            this.beerLogic = beerLogic;
        }

        [HttpGet]
        public IEnumerable<BrandAvgPriceStatistics> BrandsAvgPrice()
        {
            return this.beerLogic.BrandsAvgPrice();           
        }

        [HttpGet]
        public IEnumerable<TypeAvgPriceStatistics> TypesAvgPrice()
        {
            return this.beerLogic.TypesAvgPrice();
        }

        [HttpGet]
        public IEnumerable<BrandsBeerCountStatistics> BrandsBeerCount()
        {
            return this.beerLogic.BrandsBeerCount();
        }

        [HttpGet]
        public IEnumerable<TypesBeerCountStatistics> TypesBeerCount()
        {
            return this.beerLogic.TypesBeerCount();
        }

        [HttpGet]
        public IEnumerable<MostExpensiveBeerPerBrandStatistics> MostExpensiveBeerPerBrand()
        {
            return this.beerLogic.MostExpensiveBeerPerBrand();
        }
    }
}

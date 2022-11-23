using KJWTMR_HTF_2022231.Models.Interfaces;
using KJWTMR_HTF_2022231.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KJWTMR_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBeerShopLogic<Brand> brandLogic;

        public BrandController(IBeerShopLogic<Brand> brandLogic)
        {
            this.brandLogic = brandLogic;
        }

        [HttpGet]
        public IEnumerable<Brand> ReadAll()
        {
            return brandLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return this.brandLogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Brand value)
        {
            this.brandLogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            this.brandLogic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.brandLogic.Delete(id);
        }
    }
}

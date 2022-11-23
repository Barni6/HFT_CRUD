using KJWTMR_HTF_2022231.Logic.Interfaces;
using KJWTMR_HTF_2022231.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KJWTMR_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        IBeerLogic beerLogic;

        public BeerController(IBeerLogic beerLogic)
        {
            this.beerLogic = beerLogic;
        }

        [HttpGet]
        public IEnumerable<Beer> ReadAll()
        {
            return beerLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Beer Read(int id)
        {
            return this.beerLogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Beer value)
        {
            this.beerLogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Beer value)
        {
            this.beerLogic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.beerLogic.Delete(id);
        }
    }
}

using KJWTMR_HTF_2022231.Models;
using KJWTMR_HTF_2022231.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KJWTMR_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        IBeerShopLogic<Type> typeLogic;

        public TypeController(IBeerShopLogic<Type> typeLogic)
        {
            this.typeLogic = typeLogic;
        }

        [HttpGet]
        public IEnumerable<Type> ReadAll()
        {
            return typeLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Type Read(int id)
        {
            return this.typeLogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Type value)
        {
            this.typeLogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Type value)
        {
            this.typeLogic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.typeLogic.Delete(id);
        }
    }
}

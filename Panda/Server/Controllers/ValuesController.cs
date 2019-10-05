using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Entities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IPandaRepository pandaRepo;

        public ValuesController(IPandaRepository pandaRepository)
        {
            pandaRepo = pandaRepository;
        }

        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        public ActionResult<IEnumerable<Trader>> Get()
        {
            var traderModels = pandaRepo.GetAllTraders().Select(t => new Models.TraderModel(t));

            var products = pandaRepo.GetAllProducts();

            var allTradersFull = pandaRepo.GetAllTraders();

            var traderNo1 = pandaRepo.GetTraderById(1);

            var jb = pandaRepo.GetTraderByName("JBelfort");
            var jbalance = jb.BankAccount.Balance;

            var market = pandaRepo.GetAllMarketProducts();
            var lax = pandaRepo.GetProduct("LAX");

            return Ok(traderModels);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

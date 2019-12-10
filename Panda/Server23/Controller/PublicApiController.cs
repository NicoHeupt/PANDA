using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Server23.Data;
using Server23.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server23.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicApiController : ControllerBase
    {
        private readonly IPandaRepository pandaRepo;

        public PublicApiController(IPandaRepository pandaRepository)
        {
            pandaRepo = pandaRepository;
        }

        [Route("tradersFull")]
        [HttpGet()]
        public ActionResult<IEnumerable<Trader>> GetTradersFull()
        {
            //var traderModels = pandaRepo.GetAllTraders().Select(t => new Models.TraderModel(t));

            //var products = pandaRepo.GetAllProducts();

            var allTradersFull = pandaRepo.GetAllTraders();

            //var traderNo1 = pandaRepo.GetTraderById(1);

            //var jb = pandaRepo.GetTraderByName("JBelfort");
            //var jbalance = jb.BankAccount.Balance;

            //var market = pandaRepo.GetAllMarketProducts();
            //var lax = pandaRepo.GetProduct("LAX");

            return Ok(allTradersFull);
        }

        [Route("products")]
        [HttpGet()]
        public ActionResult<IEnumerable<Trader>> GetProducts()
        {
            //var traderModels = pandaRepo.GetAllTraders().Select(t => new Models.TraderModel(t));

            var products = pandaRepo.GetAllProducts();

            //var allTradersFull = pandaRepo.GetAllTraders();

            //var traderNo1 = pandaRepo.GetTraderById(1);

            //var jb = pandaRepo.GetTraderByName("JBelfort");
            //var jbalance = jb.BankAccount.Balance;

            //var market = pandaRepo.GetAllMarketProducts();
            //var lax = pandaRepo.GetProduct("LAX");

            return Ok(products);
        }

        // GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

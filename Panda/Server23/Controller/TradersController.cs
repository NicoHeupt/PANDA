using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server23.Data;
using Server23.Entities;
using Server23.Models;
using Server23.Helpers;

namespace Server23.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradersController : ControllerBase
    {
        private readonly IPandaRepository pandaRepo;

        public TradersController(IPandaRepository pandaRepository)
        {
            pandaRepo = pandaRepository;
        }

        // GET: api/Traders
        [HttpGet]
        public ActionResult<IEnumerable<Trader>> GetTraders()
        {
            var traderModels = pandaRepo.GetAllTraders().Select(t => new TraderModel(t));
            return Ok(traderModels);
        }

        //// GET: api/Traders/id/5
        //[Route("id/{id}")]
        //[HttpGet("{id}")]
        //public ActionResult<Trader> GetTrader(int id)
        //{
        //    var traderModel = new TraderModel(pandaRepo.GetTraderById(id));
        //    return Ok(traderModel);
        //}

        // GET: api/Traders/JBelfort
        [Authorize]
        [HttpGet("{name}")]
        public ActionResult<Trader> GetTrader(string name)
        {
            //var z = UserHelpers.GetUsername(User);
            //var traderModel = new TraderModel(pandaRepo.GetTraderByName(name));
            //return Ok(traderModel);

            if(name.ToUpper() == UserHelpers.GetUsername(User).ToUpper())
            {
                var traderModel = new TraderModel(pandaRepo.GetTraderByName(name));
                return Ok(traderModel);
            }
            return Unauthorized();
        }

        //// PUT: api/Traders/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTrader(int id, Trader trader)
        //{
        //    if (id != trader.Id)
        //    {
        //        return BadRequest();
        //    }

        //    pandaRepo.Entry(trader).State = EntityState.Modified;

        //    try
        //    {
        //        await pandaRepo.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TraderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Traders
        //[HttpPost]
        //public async Task<ActionResult<Trader>> PostTrader(Trader trader)
        //{
        //    pandaRepo.Traders.Add(trader);
        //    await pandaRepo.SaveChangesAsync();

        //    return CreatedAtAction("GetTrader", new { id = trader.Id }, trader);
        //}

        //// DELETE: api/Traders/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Trader>> DeleteTrader(int id)
        //{
        //    var trader = await pandaRepo.Traders.FindAsync(id);
        //    if (trader == null)
        //    {
        //        return NotFound();
        //    }

        //    pandaRepo.Traders.Remove(trader);
        //    await pandaRepo.SaveChangesAsync();

        //    return trader;
        //}

        //private bool TraderExists(int id)
        //{
        //    return pandaRepo.Traders.Any(e => e.Id == id);
        //}
    }
}

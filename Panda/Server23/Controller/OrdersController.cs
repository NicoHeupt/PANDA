using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server23.Data;
using Server23.Entities;

namespace Server23.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IPandaRepository pandaRepo;

        public OrdersController(IPandaRepository pandaRepository)
        {
            pandaRepo = pandaRepository;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<BookingOrder>> GetBookingOrders()
        {
            return Ok(pandaRepo.GetBookingOrdersUnbooked());
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<BookingOrder> GetBookingOrder(int id)
        {
            var bookingOrder = pandaRepo.GetBookingOrder(id);

            if (bookingOrder == null) return NotFound();

            return Ok(bookingOrder);
        }


        // POST: api/Orders
        [Authorize]
        [HttpPost]
        public ActionResult<BookingOrder> PostBookingOrder(string traderName, string productCode, int amount, decimal threshold)
        {
            var Trader = pandaRepo.GetTraderByName(traderName);
            var MarketProduct = pandaRepo.GetMarketProduct(productCode);
            var bookingOrder = new BookingOrder(Trader, MarketProduct, amount, threshold);

            pandaRepo.PlaceBookingOrder(bookingOrder);

            return CreatedAtAction("GetBookingOrder", new { id = bookingOrder.Id }, bookingOrder);
        }


        //// PUT: api/BookingOrders/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBookingOrder(int id, BookingOrder bookingOrder)
        //{
        //    if (id != bookingOrder.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(bookingOrder).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookingOrderExists(id))
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

        //// DELETE: api/BookingOrders/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<BookingOrder>> DeleteBookingOrder(int id)
        //{
        //    var bookingOrder = await _context.BookingOrders.FindAsync(id);
        //    if (bookingOrder == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.BookingOrders.Remove(bookingOrder);
        //    await _context.SaveChangesAsync();

        //    return bookingOrder;
        //}

        //private bool BookingOrderExists(int id)
        //{
        //    return _context.BookingOrders.Any(e => e.Id == id);
        //}
    }
}

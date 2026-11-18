using DeliveryService.Data;
using DeliveryService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Controllers
{
    [ApiController]
    [Route("Delivery")]
    public class DeliveryController : ControllerBase
    {
        private readonly DeliveryDbContext _context;

        public DeliveryController(DeliveryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDeliveries()
        {
            var deliveries = await _context.Deliveries.ToListAsync();

            return Ok(deliveries);
        }

        [HttpPost]
        public async Task<IActionResult> AddDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);

            await _context.SaveChangesAsync();

            return Ok(delivery);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDelivery(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            return Ok(delivery);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDelivery(int id, Delivery delivery)
        {
            var existingDelivery = await _context.Deliveries.FindAsync(id);

            if (existingDelivery == null)
            {
                return NotFound();
            }

            existingDelivery.OrderId = delivery.OrderId;
            existingDelivery.DeliveryAddress = delivery.DeliveryAddress;
            existingDelivery.Status = delivery.Status;

            await _context.SaveChangesAsync();

            return Ok(existingDelivery);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            _context.Deliveries.Remove(delivery);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
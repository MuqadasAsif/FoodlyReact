using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantService.Data;
using RestaurantService.Models;

namespace RestaurantService.Controllers
{

    [Route("api/Restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public RestaurantController(RestaurantDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await _context.Restaurants.ToListAsync();

            return Ok(restaurants);
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);

            await _context.SaveChangesAsync();

            return Ok(restaurant);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, Restaurant restaurant)
        {
            var existingRestaurant = await _context.Restaurants.FindAsync(id);

            if (existingRestaurant == null)
            {
                return NotFound();
            }

            existingRestaurant.Name = restaurant.Name;
            existingRestaurant.Address = restaurant.Address;
            existingRestaurant.IsOpen = restaurant.IsOpen;

            await _context.SaveChangesAsync();

            return Ok(existingRestaurant);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurant);

            await _context.SaveChangesAsync();

            return Ok("Restaurant deleted successfully.");
        }
    }
}

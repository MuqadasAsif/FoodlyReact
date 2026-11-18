using MenuService.Data;
using MenuService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MenuService.Controllers
{
    [ApiController]
    [Route("Menu")]
    public class MenuController : ControllerBase
    {
        private readonly MenuDbContext _context;

        public MenuController(MenuDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenus()
        {
            var menus = await _context.Menus.ToListAsync();

            return Ok(menus);
        }

        [HttpGet("Restaurant/{restaurantId}")]
        public async Task<IActionResult> GetRestaurantMenu(int restaurantId)
        {
            var menus = await _context.Menus
                .Where(m => m.RestaurantId == restaurantId)
                .ToListAsync();

            return Ok(menus);
        }
        [HttpPost]
        public async Task<IActionResult> AddMenu(Menu menu)
        {
            _context.Menus.Add(menu);

            await _context.SaveChangesAsync();

            return Ok(menu);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id, Menu menu)
        {
            var existingMenu = await _context.Menus.FindAsync(id);

            if (existingMenu == null)
            {
                return NotFound();
            }

            existingMenu.RestaurantId = menu.RestaurantId;
            existingMenu.Name = menu.Name;
            existingMenu.Description = menu.Description;
            existingMenu.Price = menu.Price;

            await _context.SaveChangesAsync();

            return Ok(existingMenu);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menu);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
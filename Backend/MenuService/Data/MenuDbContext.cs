using Microsoft.EntityFrameworkCore;
using MenuService.Models;

namespace MenuService.Data
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options)
            : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
    }
}
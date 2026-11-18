using FoodDeliveryWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryWeb.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RestaurantController(IHttpClientFactory httpClientFactory) //ihttpclient factory hamay httpclient create kar kai dai rahy hai  
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(string? search)
        {
            var client = _httpClientFactory.CreateClient("RestaurantApi"); //jo resturantapi kai name ka httpclient hum nai program.cs mai banaya tha ab usko yahan call kia hai 

            var restaurants = await client.GetFromJsonAsync<List<Restaurant>>(  //program.cs mai hum nai bas server ki information thi phr controller mai end point ki location di hai 
                "api/Restaurant");                                              //and idhar response jason mai aya hai jisko hum nai hamary model kai object mai change kar kai agai bheja hai
            if (!string.IsNullOrWhiteSpace(search))
            {
                restaurants = restaurants
                    .Where(r => r.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            ViewBag.Search = search;

            return View(restaurants);
        }
        public async Task<IActionResult> AllRestaurants()
        {
            var client = _httpClientFactory.CreateClient("RestaurantApi");

            var restaurants = await client.GetFromJsonAsync<List<Restaurant>>(
                "api/Restaurant");

            return View(restaurants);
        }
        public async Task<IActionResult> Menu(int id)
        {
            var restaurantClient = _httpClientFactory.CreateClient("RestaurantApi");

            var restaurant = await restaurantClient.GetFromJsonAsync<Restaurant>(
                $"api/Restaurant/{id}");

            var menuClient = _httpClientFactory.CreateClient("MenuApi");

            var menus = await menuClient.GetFromJsonAsync<List<Menu>>(
                $"Menu/Restaurant/{id}");

            var viewModel = new RestaurantMenuViewModel
            {
                Restaurant = restaurant,
                Menus = menus
            };

            return View(viewModel);
        }
    }
}
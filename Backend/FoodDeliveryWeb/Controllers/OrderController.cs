using FoodDeliveryWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace FoodDeliveryWeb.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var orderClient = _httpClientFactory.CreateClient("OrderApi");

            var orders = await orderClient.GetFromJsonAsync<List<Order>>("Order");

            var deliveryClient = _httpClientFactory.CreateClient("DeliveryApi");

            var deliveries = await deliveryClient.GetFromJsonAsync<List<Delivery>>("Delivery");

            var viewModel = orders.Select(order => //select har order ko check karay ga and order arrow sai phailai temporary name hai 
            {
                var delivery = deliveries
                    .FirstOrDefault(d => d.OrderId == order.Id);

                return new OrderWithDeliveryViewModel
                {
                    Order = order,
                    DeliveryStatus = delivery?.Status ?? "Pending",
                    DeliveryId = delivery?.Id ?? 0 //Jab user Order Received click karta hai, controller ko delivery ki ID chahiye hoti hai
                };
            }).ToList();

            return View(viewModel);
        }

        [HttpGet] //GET ka matlab data lena ya mangwana hota hai. Jab user ne Create page open kiya, to Create page ne OrderController ke Create action se
                  //data manga, aur controller ne usay Order object ki form mein data de diya.
        public IActionResult Create(int restaurantId, string itemName, decimal price)
        {
            var order = new Order
            {
                RestaurantId = restaurantId,
                ItemName = itemName,
                TotalAmount = price
            };

            ViewBag.Price = price;

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order, decimal price)
        {
            order.TotalAmount = price * order.Quantity;

            var client = _httpClientFactory.CreateClient("OrderApi");

            var response = await client.PostAsJsonAsync("Order", order);

            if (response.IsSuccessStatusCode)
            {
                var createdOrder = await response.Content.ReadFromJsonAsync<Order>(); //hum save kar kai waps lai rahy ta kai hamary pas order ki id a jai jo hm delievery mai save kar saky

                var deliveryClient = _httpClientFactory.CreateClient("DeliveryApi");

                var delivery = new Delivery
                {
                    OrderId = createdOrder.Id,
                    DeliveryAddress = "Lahore",
                    Status = "Pending"
                };

                await deliveryClient.PostAsJsonAsync("Delivery", delivery);

                return RedirectToAction("Index");
            }

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Complete(int deliveryId)
        {
            var deliveryClient = _httpClientFactory.CreateClient("DeliveryApi");

            var delivery = await deliveryClient.GetFromJsonAsync<Delivery>(
                $"Delivery/{deliveryId}");

            if (delivery != null)
            {
                delivery.Status = "Complete";

                await deliveryClient.PutAsJsonAsync(
                    $"Delivery/{deliveryId}",
                    delivery);
            }

            return RedirectToAction("Index");
        }

        [HttpPost] //Form data bhej raha hai, isliye form ka method post rakha hai. Aur kyunki form POST request bhej raha hai, is request ko receive karne wala controller action bhi [HttpPost] hota hai.
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("OrderApi");

            var response = await client.DeleteAsync($"Order/{id}"); //DeleteAsync() HttpClient ka method hai jo kisi API ko DELETE request bhejta hai.

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
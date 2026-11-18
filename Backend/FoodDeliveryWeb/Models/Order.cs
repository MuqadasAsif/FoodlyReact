namespace FoodDeliveryWeb.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public int RestaurantId { get; set; }

        public string ItemName { get; set; }

        public int Quantity { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
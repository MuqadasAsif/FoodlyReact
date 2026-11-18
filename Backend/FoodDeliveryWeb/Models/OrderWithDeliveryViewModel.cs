namespace FoodDeliveryWeb.Models
{
    public class OrderWithDeliveryViewModel
    {
        public Order Order { get; set; }

        public string DeliveryStatus { get; set; }
        public int DeliveryId { get; set; }
    }
}
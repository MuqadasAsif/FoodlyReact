
//FoodDeliveryWeb ke models humne isliye banaye hain taake frontend API ke data ko ek proper C# format mein send aur receive kar sake.
namespace FoodDeliveryWeb.Models
{
    public class Delivery
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string DeliveryAddress { get; set; }

        public string Status { get; set; }
    }
}
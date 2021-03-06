using System.ComponentModel.DataAnnotations;

namespace ArmenianChairDogsitting.API.Models
{
    public class OrderSittingForDayRequest : AbstractOrderRequest
    {
        [Range(1,24)]
        public int HourQuantity { get; set; }
        [Range(1,30)]
        public int WalkQuantity { get; set;}
        [Range(1,24)]
        public int VisitQuantity { get; set; }
    }
}

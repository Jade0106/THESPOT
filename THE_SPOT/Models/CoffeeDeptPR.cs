using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace THE_SPOT.Models
{
    public class CoffeeDeptPR
    {
        [Key]
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTime? date { get; set; }

        [Required(ErrorMessage = "Please provide the item quantity.")]
        [DisplayName("QTY")]
        public int qty { get; set; }

        [Required(ErrorMessage = "Please provide the item description.")]
        [DisplayName("Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "Please provide the item price.")]
        [DisplayName("Item Price")]
        public float itemPrice { get; set; }

        [Required(ErrorMessage = "Please select the purchase request status.")]
        [DisplayName("Status")]
        public string PRstatus { get; set; }

        public enum status
        {
            Pending
        }

    }
}

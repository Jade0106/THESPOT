using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace THE_SPOT.Models
{
    public class DeptEmployee
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please provide the item quantity.")]
        [DisplayName("QTY")]
        public int qty { get; set; }

        [Required(ErrorMessage = "Please provide the item description.")]
        [DisplayName("Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "Please provide the item price.")]
        [DisplayName("Item Price")]
        public float itemPrice { get; set; }

        [DisplayName("Total")]
        public float total { get; set; }
        
    }
}

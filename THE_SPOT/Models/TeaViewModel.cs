using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace THE_SPOT.Models
{
    
        public class TeaViewModel
        {
        [Key]
        public int TeaId { get; set; }

        [Required(ErrorMessage = "Please provide the product name.")]
            [DisplayName("Product Name")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Please provide the product description.")]
            [DisplayName("Description")]
            public string Description { get; set; }

            [Required(ErrorMessage = "Please provide the product price.")]
            [DisplayName("Price")]
            public decimal Price { get; set; }

            [Required(ErrorMessage = "Please provide the product image.")]
            [DisplayName("Image")]
            public IFormFile ImageFile { get; set; }

            [DataType(DataType.Date)]
            [DisplayName("Date")]
            public DateTime? Date { get; set; }
        }

    }


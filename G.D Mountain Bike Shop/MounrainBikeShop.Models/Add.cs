using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MounrainBikeShop.Models
{
    public class Add
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage ="Min leght is 2 symbols ")]
        public string  Brand { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Min leght is 4 symbols ")]
        public string Model { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Min leght is 10 symbols ")]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string UserId { get; set; }
        
        public virtual User User { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }


    }
}

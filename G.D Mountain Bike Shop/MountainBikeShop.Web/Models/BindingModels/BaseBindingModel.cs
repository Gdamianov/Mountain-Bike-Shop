using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MountainBikeShop.Web.Models.BindingModels
{
    public abstract class BaseBindingModel
    {
        [Required(ErrorMessage ="{0} is required")]
        [StringLength(8, ErrorMessage = "The {0} must be between {2} and 8 characters long.", MinimumLength = 4)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(8, ErrorMessage = "The {0} must be between {2} and 8 characters long.", MinimumLength = 4)]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "The {0} must be between {2} and 100 characters long.", MinimumLength = 4)]
        public string Model { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public decimal Price { get; set; }

    }
}
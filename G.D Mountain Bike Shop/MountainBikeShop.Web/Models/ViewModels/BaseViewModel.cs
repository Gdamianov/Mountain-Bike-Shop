using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MountainBikeShop.Web.Models.ViewModels
{
    public class BaseViewModel
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public DateTime PostedOn { get; set; }

        public string UserId { get; set; }

        public decimal Price { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
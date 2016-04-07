using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MountainBikeShop.Data.UnitOfWork;
using MountainBikeShop.Web.Models.BindingModels;
using MounrainBikeShop.Models;
using Microsoft.AspNet.Identity;
using AutoMapper;
using MountainBikeShop.Web.Models.ViewModels;
using PagedList;

namespace MountainBikeShop.Web.Controllers
{
    public class BikesController : BaseController
    {
        public BikesController(IData data) : base(data)
        {
        }

        // GET: Bikes
        public ActionResult Index()
        {
            var bikes = this.Data.MtbAdds.All().OrderBy(b => b.PostedOn);
            var mappedBikes = Mapper.Map<IEnumerable<BikeViewModel>>(bikes);
            
            return View(mappedBikes);
        }
        
        [HttpGet]
        [Authorize]
        public ActionResult NewAdd()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult NewAdd(BikeBindingModel mtb)
        {
            
            if (!this.ModelState.IsValid)
            {
                return this.View(mtb);
            }
            var bikeAdd = Mapper.Map<MountainBikeAdd>(mtb);
            
            bikeAdd.PostedOn = DateTime.Now;
            bikeAdd.UserId = this.User.Identity.GetUserId();
            this.Data.MtbAdds.Add(bikeAdd);
            this.Data.SaveChanges();
            
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            var bike = this.Data.MtbAdds.All().FirstOrDefault(b => b.Id == id);
            if(bike == null)
            {
                //TODO : make error view
                return this.View("Error");
            }
            var mapperBike = Mapper.Map<BikeViewModel>(bike);
            return this.View(mapperBike);
        }

        [HttpPost]
        public PartialViewResult Search(string query)
        {
            var bikes = this.Data.MtbAdds.All().Where(m => m.Brand.Contains(query) || m.Model.Contains(query));

            var mappedBikes = Mapper.Map<IEnumerable<BikeViewModel>>(bikes);
            return this.PartialView("_Search", mappedBikes);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var bike = this.Data.MtbAdds.Find(id);
            if(bike == null)
            {
                return this.View("Error");
            }
            this.Data.MtbAdds.Remove(bike);
            this.Data.SaveChanges();
            return this.RedirectToAction("Index", "MyAdds");
        }
    }
}
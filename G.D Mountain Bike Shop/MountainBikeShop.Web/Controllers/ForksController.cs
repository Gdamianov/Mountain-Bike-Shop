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

namespace MountainBikeShop.Web.Controllers
{
    public class ForksController : BaseController
    {
        public ForksController(IData data) : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AllForkAdds()
        {
            var forks = this.Data.ForkAdds.All().OrderBy(m => m.PostedOn);
            var mappedForkAdds = Mapper.Map<IEnumerable<ForkViewModel>>(forks);
            return this.Json(mappedForkAdds, JsonRequestBehavior.AllowGet);
        }
 
        [Authorize]
        [HttpGet]
        public ActionResult NewAdd()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewAdd(ForkBindingModel fork)
        {
            if (!this.ModelState.IsValid)
            {
                return null;
            }
            var newFork = Mapper.Map<ForkAdd>(fork);
            
            newFork.PostedOn = DateTime.Now;
            newFork.UserId = this.User.Identity.GetUserId();
            this.Data.ForkAdds.Add(newFork);
            this.Data.SaveChanges();
            return this.RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Add(int id)
        {
            var fork = this.Data.ForkAdds.All().FirstOrDefault(b => b.Id == id);
            if (fork == null)
            {
                //TODO : make error view
                return this.View("Error");
            }
            var mappedFork = Mapper.Map<ForkViewModel>(fork);
            return this.View(mappedFork);
        }

        [HttpPost]
        public PartialViewResult Search(string query)
        {
            var forks = this.Data.ForkAdds.All().Where(m => m.Brand.Contains(query)|| m.Model.Contains(query));

            var mappedForks = Mapper.Map<IEnumerable<ForkViewModel>>(forks);
            return this.PartialView("_Search", mappedForks);
        }
    }
}
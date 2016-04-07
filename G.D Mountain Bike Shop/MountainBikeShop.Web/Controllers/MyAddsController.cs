using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MountainBikeShop.Data.UnitOfWork;
using Microsoft.AspNet.Identity;
using AutoMapper;
using MountainBikeShop.Web.Models.ViewModels;

namespace MountainBikeShop.Web.Controllers
{
    public class MyAddsController : BaseController
    {
        public MyAddsController(IData data) : base(data)
        {
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var loggedUserUsername = this.User.Identity.GetUserId();
            var bikes = this.Data.MtbAdds.All().Where(u=>u.UserId==loggedUserUsername).OrderByDescending(m => m.PostedOn);
            var forks = this.Data.ForkAdds.All().Where(u => u.UserId == loggedUserUsername).OrderByDescending(m => m.PostedOn);
            var frames = this.Data.FrameAdds.All().Where(u => u.UserId == loggedUserUsername).OrderByDescending(m => m.PostedOn);

            var mappedBikes = Mapper.Map<IEnumerable<BikeViewModel>>(bikes);
            var mappedForks = Mapper.Map<IEnumerable<ForkViewModel>>(forks);
            var mappedFrames = Mapper.Map<IEnumerable<FrameViewModel>>(frames);
            var myAddsViewModel = new MyAddsViewModel(mappedBikes, mappedFrames, mappedForks);
            
            return View(myAddsViewModel);
        }
    }
}
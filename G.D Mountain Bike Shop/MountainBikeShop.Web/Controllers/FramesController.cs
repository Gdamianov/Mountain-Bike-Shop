using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MountainBikeShop.Data.UnitOfWork;
using MountainBikeShop.Web.Models.BindingModels;
using AutoMapper;
using MounrainBikeShop.Models;
using Microsoft.AspNet.Identity;
using MountainBikeShop.Web.Models.ViewModels;

namespace MountainBikeShop.Web.Controllers
{
    public class FramesController : BaseController
    {
        public FramesController(IData data) : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllFrameAdds()
        {
            var frames = this.Data.FrameAdds.All().OrderBy(m => m.PostedOn);
            var mappedFrames = Mapper.Map<IEnumerable<FrameViewModel>>(frames);
            return this.Json(mappedFrames, JsonRequestBehavior.AllowGet);
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
        public ActionResult NewAdd(FrameBindingModel frame)
        {
            if (!this.ModelState.IsValid)
            {
                return null;
            }
            var newFork = Mapper.Map<FrameAdd>(frame);

            newFork.PostedOn = DateTime.Now;
            newFork.UserId = this.User.Identity.GetUserId();
            this.Data.FrameAdds.Add(newFork);
            this.Data.SaveChanges();
            return this.RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Add(int id)
        {
            var frame = this.Data.FrameAdds.All().FirstOrDefault(b => b.Id == id);
            if (frame == null)
            {
                //TODO : make error view
                return this.View("Error");
            }
            var mappedFrame = Mapper.Map<FrameViewModel>(frame);
            return this.View(mappedFrame);
        }



        [HttpPost]
        public PartialViewResult Search(string query)
        {
            var frames = this.Data.FrameAdds.All().Where(m => m.Brand.Contains(query) || m.Model.Contains(query));

            var mappedFrames = Mapper.Map<IEnumerable<FrameViewModel>>(frames);
            return this.PartialView("_Search", mappedFrames);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var frame = this.Data.FrameAdds.Find(id);
            if (frame == null)
            {
                return this.View("Error");
            }
            this.Data.FrameAdds.Remove(frame);
            this.Data.SaveChanges();
            return this.RedirectToAction("Index", "MyAdds");
        }
    }
}

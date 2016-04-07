using MounrainBikeShop.Models;
using MountainBikeShop.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MountainBikeShop.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private IData data;

        protected BaseController(IData data)
        {
            this.Data = data;
        }

        protected IData Data { get; private set; }
    }
}
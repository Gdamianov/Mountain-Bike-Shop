using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MountainBikeShop.Web.Models.ViewModels
{
    public class MyAddsViewModel
    {
        public MyAddsViewModel(IEnumerable<BikeViewModel> myBikes=null, IEnumerable<FrameViewModel> myFrames=null, IEnumerable<ForkViewModel> myForks=null)
        {
            this.MyBikeAdds = myBikes;
            this.MyForkAdds = myForks;
            this.MyFrameAdds = myFrames;
        }

        public IEnumerable<BikeViewModel> MyBikeAdds { get; set; }

        public IEnumerable<ForkViewModel> MyForkAdds { get; set; }

        public IEnumerable<FrameViewModel> MyFrameAdds{ get; set; }

    }
}
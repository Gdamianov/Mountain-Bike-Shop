namespace MounrainBikeShop.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class User: IdentityUser
    {
        private ICollection<FrameAdd> frameAdds;

        private ICollection<ForkAdd> forkAdds;
        private ICollection<MountainBikeAdd> mtbAdds;

        public User()
        {
            this.forkAdds = new HashSet<ForkAdd>();
            this.frameAdds = new HashSet<FrameAdd>();
            this.mtbAdds = new HashSet<MountainBikeAdd>();
        }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string Phone { get; set; }

        public virtual ICollection<ForkAdd> ForkAdds
        {
            get { return this.forkAdds; }
            set { this.forkAdds = value; }
        }

        public virtual ICollection<FrameAdd> FrameAdds
        {
            get { return this.frameAdds; }
            set { this.frameAdds = value; }
        }

        public virtual ICollection<MountainBikeAdd> MountainBikeAdds
        {
            get { return this.mtbAdds; }
            set { this.mtbAdds = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    
    
}

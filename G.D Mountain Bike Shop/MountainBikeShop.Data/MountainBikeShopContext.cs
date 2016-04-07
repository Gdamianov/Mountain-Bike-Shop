namespace MountainBikeShop.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using MounrainBikeShop.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MountainBikeShopContext : IdentityDbContext<User>
    {
        public MountainBikeShopContext()
            : base("MountainBikeShop", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MountainBikeShopContext, Configuration>());
        }

        public IDbSet<ForkAdd> ForksAdds { get; set; }

        public IDbSet<FrameAdd> FrameAdds { get; set; }

        public IDbSet<MountainBikeAdd> MountainBikeAdds { get; set; }



        public static MountainBikeShopContext Create()
        {
            return new MountainBikeShopContext();
        }
    }
}
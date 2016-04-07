namespace MountainBikeShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MounrainBikeShop.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MountainBikeShop.Data.MountainBikeShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "MountainBikeShop.Data.MountainBikeShopContext";
        }

        protected override void Seed(MountainBikeShop.Data.MountainBikeShopContext context)
        {
            if (!context.Users.Any())
            {
                this.SeedDb(context);
            }
        }
        private void SeedDb(MountainBikeShopContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireDigit = false,
                RequireNonLetterOrDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };
            var userOne = new User()
            {
                UserName = "pesho",

                Email = "gogo@example.com",

                Phone = "088877676"

            };
            var userCreateResult1 = userManager.Create(userOne, "1234");
            var userTwo = new User()
            {
                UserName = "gogo",

                Email = "someUser@example.com",

                Phone = "08887767484"

            };
            var userCreateResult2 = userManager.Create(userTwo, "1234");
            var bikeAddOne = new MountainBikeAdd()
            {
                Brand = "Specialized",
                Model = "Demo 8",
                Description = "Like brand new !!!",
                PostedOn = DateTime.Now,
                Price = 3400,
                User = userOne
            };
            var bikeAddTwo = new MountainBikeAdd()
            {
                Brand = "Scott",
                Model = "Gambler",
                Description = "In very good condition!!!",
                PostedOn = DateTime.Now,
                Price = 3600,
                User = userTwo
            };
            var forkAddOne = new ForkAdd()
            {
                Brand = "Marzocchi",
                Model = "888 rc3",
                Description = "The fork works greak, like brand new.",
                PostedOn = DateTime.Now,
                Price = 800,
                User = userOne
            };
            var forkAddTwo = new ForkAdd()
            {
                Brand = "Rock Shox",
                Model = "Boxxer World cup",
                Description = "Brand New in box!!!!",
                PostedOn = DateTime.Now,
                Price = 1400,
                User = userOne
            };
            var frameAddOne = new FrameAdd()
            {
                Brand = "Commencal",
                Model = "Supreme dh",
                Description = "I used the frame 2 years it is in very good condition without damages.",
                PostedOn = DateTime.Now,
                Price = 1100,
                User = userOne
            };
            var frameAddTwo = new FrameAdd()
            {
                Brand = "Santa cruz",
                Model = "V10 Carbon",
                Description = "2014 model only for racers.",
                PostedOn = DateTime.Now,
                Price = 1900,
                User = userOne
            };
            context.ForksAdds.Add(forkAddOne);
            context.ForksAdds.Add(forkAddTwo);
            context.MountainBikeAdds.Add(bikeAddOne);
            context.MountainBikeAdds.Add(bikeAddTwo);
            context.FrameAdds.Add(frameAddOne);
            context.FrameAdds.Add(frameAddTwo);
            context.SaveChanges();

        }
    }
}

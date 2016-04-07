using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MounrainBikeShop.Models;
using MountainBikeShop.Data.Repositories;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MountainBikeShop.Data.UnitOfWork
{
    public class Data : IData
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        private IUserStore<User> userStore;

        public Data()
            : this(new MountainBikeShopContext())
        {
        }

        public Data(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericEfRepository<T>);
                this.repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public int SaveChanges()
        {
           return  this.dbContext.SaveChanges();
        }

        public IRepository<ForkAdd> ForkAdds
        {
            get { return this.GetRepository<ForkAdd>(); }
        }

        public IRepository<FrameAdd> FrameAdds
        {
            get
            {
                return this.GetRepository<FrameAdd>();
            }
        }

        public IRepository<MountainBikeAdd> MtbAdds
        {
            get
            {
                return this.GetRepository<MountainBikeAdd>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }
        public IUserStore<User> UserStore
        {
            get
            {
                if (this.userStore == null)
                {
                    this.userStore = new UserStore<User>(this.dbContext);
                }

                return this.userStore;
            }
        }


    }

}

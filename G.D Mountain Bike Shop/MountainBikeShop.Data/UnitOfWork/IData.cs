using MounrainBikeShop.Models;
using MountainBikeShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountainBikeShop.Data.UnitOfWork
{
    public interface IData
    {
        IRepository<User> Users { get; }

        IRepository<ForkAdd> ForkAdds { get; }

        IRepository<FrameAdd> FrameAdds { get; }

        IRepository<MountainBikeAdd> MtbAdds { get; }

        int SaveChanges();
    }
}

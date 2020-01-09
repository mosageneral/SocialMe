using BL.Infrastructure;
using Model.Models;
using Models.AppDBModel;

namespace BL.Repositories
{
    public interface IUserRepository
    { }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DBContext ctx) : base(ctx)
        { }


    }
}

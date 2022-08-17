using MyHardware.Infrastructure.Common.Interfaces;
using MyHardwareWeb.Application.Interfaces;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IApplicationDbContext context) : base(context) { }
    }
}

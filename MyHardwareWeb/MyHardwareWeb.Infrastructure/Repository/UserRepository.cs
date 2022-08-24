using Microsoft.EntityFrameworkCore;
using MyHardware.Infrastructure.Common.Interfaces;
using MyHardwareWeb.Application.Interfaces;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IApplicationDbContext context) : base(context) { }

        public async Task<bool> GetByEmailAndPassword(User userModel)
        {
            var currentUser = await _dbSet.AsNoTracking().Where(u => u.Email == userModel.Email && u.Password == userModel.Password).FirstOrDefaultAsync();
            return currentUser != null;
        }
    }
}

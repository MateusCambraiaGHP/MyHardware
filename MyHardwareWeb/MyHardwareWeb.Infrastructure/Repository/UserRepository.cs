using Microsoft.EntityFrameworkCore;
using MyHardware.Infrastructure.Common.Interfaces;
using MyHardwareWeb.Application.Interfaces;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IApplicationDbContext context) : base(context) { }
        
        public async Task<User> GetUserByEmailAndPassWord(User model)
        {
            var currentEntity = await _dbSet.AsNoTracking().Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefaultAsync();
            return currentEntity;
        }
    }
}

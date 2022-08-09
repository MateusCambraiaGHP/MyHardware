﻿using MyHardware.Interfaces;

namespace MyHardware.Repository
{
    public interface IUserRepository
    { 
        
    }
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly IProductExcelService _excelService;

        public UserRepository(
            IApplicationDbContext db,
            IProductExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }

    }
}

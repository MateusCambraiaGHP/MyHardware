﻿using MyHardware.Models;

namespace MyHardware.Interfaces
{
    public interface IProductExcelService
    {
        Task ExportToExcel(IEnumerable<Product> entityList, string path, string name);
    }
}
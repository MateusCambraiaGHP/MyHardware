﻿using MyHardware.Interfaces;
using MyHardwareWeb.Application.Interfaces;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Infrastructure.Services
{
    public class SupplierProductCustomerService : ExcelService<SupplierProductCustomer>, ISupplierProductCustomerExcelService { }
}

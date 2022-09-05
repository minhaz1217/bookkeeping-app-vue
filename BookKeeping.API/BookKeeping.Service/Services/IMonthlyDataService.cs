﻿using BookKeeping.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Service.Services
{
    public interface IMonthlyDataService
    {
        Task<MonthlyData> GetByIDAsync(int id);
    }
}
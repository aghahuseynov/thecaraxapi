using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Business
{
    public static class CityLogic
    {
        public static async Task<List<Models.Address.City>> GetByCode(string code)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Cities.Where(q => q.CountryCode == code).ToListAsync();
            }
        }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Business
{
    public static class CountriesLogic
    {
        public static async Task<List<Models.Address.Country>> Get()
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Countries.ToListAsync();
            }
        }
    }
}

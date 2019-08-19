using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Business
{
    public static class CountyLogic
    {
        public static async Task<IList<Models.Address.County>> Get()
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Counties.ToListAsync();
            }
        }
    }
}

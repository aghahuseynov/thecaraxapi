using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services.Business.BrandAndModel
{
    public static class BrandAndModelLogic
    {
        public static async Task<List<Models.Cars.Brand>> GetBrand()
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Brands.Where(q => !q.IsDeleted).ToListAsync();
            }
        }
        public static async Task<List<Models.Cars.BrandModel>> GetModels()
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.BrandModels.Where(q=> !q.IsDeleted).ToListAsync();
            }
        }

        public static async Task<List<Models.Cars.BrandModel>> GetModelByBrandId(int brandId)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.BrandModels.Where(q => q.BrandId == brandId && !q.IsDeleted).ToListAsync();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;

namespace Services.Business.Cars
{
    public static class CarInServiceLogic
    {

        public static async Task<bool> Create(Guid token, string departmentCode, Models.Cars.CarInService carInService)
        {
            AuthenticationLogic.CheckTokenInfo(token);
            using (var db = new DataAccess.CaraxEntitiy())
            {
                var find = db.CarInServices.First(q => q.CarId == carInService.CarId && q.CarServiceId == carInService.CarServiceId);
                await db.CarInServices.AddAsync(carInService);
                return await db.SaveChangesAsync() > 0;
            }
        }

        public static async Task<bool> Remove(Guid token, string departmentCode, int carId, int serviceId)
        {
            AuthenticationLogic.CheckTokenInfo(token);

            using (var db = new DataAccess.CaraxEntitiy())
            {
                var find = db.CarInServices.First(q => q.CarId == carId && q.CarServiceId == serviceId);
                db.CarInServices.Remove(find);
                return await db.SaveChangesAsync() > 0;
            }
        }

    }
}

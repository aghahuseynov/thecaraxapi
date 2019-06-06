using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.EntityFrameworkCore;

namespace Services.Business.Cars
{
    public static class CarPropertyLogic
    {
        public static async Task<List<Models.Cars.CarProperty>> Get(Guid token, int carId)
        {
            AuthenticationLogic.CheckTokenInfo(token);
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.CarProperties.Where(q => q.CarId == carId).ToListAsync();
            }
        }

        public static async Task<bool> Create(Guid token, Models.Cars.CarProperty carProperty)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);
            using (var db = new DataAccess.CaraxEntitiy())
            {
                carProperty.CreatedDateTime = DateTime.Now;
                carProperty.CreatedBy = userInfo.Username;

                await db.CarProperties.AddAsync(carProperty);

                return await db.SaveChangesAsync() > 0;
            }
        }

        public static async Task<bool> Update(Guid token, Models.Cars.CarProperty carProperty)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);
            using (var db = new DataAccess.CaraxEntitiy())
            {
                carProperty.UpdatedDateTime = DateTime.Now;
                carProperty.UpdatedBy = userInfo.Username;

                db.CarProperties.Update(carProperty);
                return await db.SaveChangesAsync() > 0;
            }
        }

        public static async Task<bool> Delete(Guid token, int propertyId)
        {
            AuthenticationLogic.CheckTokenInfo(token);

            using (var db = new DataAccess.CaraxEntitiy())
            {
                var finded = db.CarProperties.First(q => q.Id == propertyId);

                db.CarProperties.Remove(finded);
                return await db.SaveChangesAsync() > 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Business;
using Microsoft.EntityFrameworkCore;

namespace Services.Business.Cars
{
    public static class CarLogic
    {

        public static async Task<List<Models.Cars.Car>> GetList(Guid token, string departmentCode, bool isMaintenance = false)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Cars?.Where(q => !q.IsDeleted && q.DepartmentCode == departmentCode && q.Maintenance == isMaintenance)
                    ?.ToListAsync();
            }
        }

        public static async Task<bool> Add(Guid token, string departmentCode, Models.Cars.Car car)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);

            car.CreatedDateTime = DateTime.Now;
            car.CreatedBy = userInfo.Username;
            car.CompanyCode = departmentCode;
            car.DepartmentCode = departmentCode;

            using (var db = new DataAccess.CaraxEntitiy())
            {
                await db.Cars.AddAsync(car);
                return await db.SaveChangesAsync() > 0;
            }
        }

        public static async Task<bool> Update(Guid token, Models.Cars.Car car)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);

            using (var db = new DataAccess.CaraxEntitiy())
            {
                car.UpdatedDateTime = DateTime.Now;
                car.UpdatedBy = userInfo.Username;
                car.CompanyCode = userInfo.CompanyCode;
                car.DepartmentCode = userInfo.DepartmentCode;

                db.Cars.Update(car);
                return await db.SaveChangesAsync() > 0;
            }
        }

        public static async Task<bool> Delete(Guid token, int carId)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                var userInfo = AuthenticationLogic.CheckTokenInfo(token);

                var findedCar = db.Cars.FirstOrDefault(q => q.Id == carId);
                if (findedCar == null)
                {
                    return false;
                }

                findedCar.IsDeleted = true;
                findedCar.UpdatedDateTime = DateTime.Now;
                findedCar.UpdatedBy = userInfo.Username;
                db.Cars.Update(findedCar);
                return await db.SaveChangesAsync() > 0;
            }
        }

        public static async Task<bool> BeMaintenance(Guid token, int carId, bool maintenance)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);
            using (var db = new DataAccess.CaraxEntitiy())
            {
                var findedCar = db.Cars.FirstOrDefault(q => q.Id == carId);
                if (findedCar == null)
                {
                    return false;
                }
                findedCar.Maintenance = maintenance;
                findedCar.UpdatedDateTime = DateTime.Now;
                findedCar.UpdatedBy = userInfo.Username;
                db.Cars.Update(findedCar);
                return await db.SaveChangesAsync() > 0;
            }
        }

        public static async Task<bool> BeCrash(Guid token, int carId, bool crash=false)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                var findedCar = db.Cars.FirstOrDefault(q => q.Id == carId);
                if (findedCar == null)
                {
                    return false;
                }
                var userInfo = AuthenticationLogic.CheckTokenInfo(token);

                findedCar.Crash = crash;
                findedCar.UpdatedDateTime = DateTime.Now;
                findedCar.UpdatedBy = userInfo.Username;
                db.Cars.Update(findedCar);
                return await db.SaveChangesAsync() > 0;
            }
        }
    }
}

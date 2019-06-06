using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.EntityFrameworkCore;
using Models.Cars;

namespace Services.Business.Cars
{
    public static class CarServiceLogic
    {
        public static async Task<List<Models.Cars.CarService>> Get(Guid token, string departmentCode)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.CarServices.Where(q => q.DepartmentCode == departmentCode).ToListAsync();
            }
        }
        public static async Task<List<Models.Cars.CarService>> Get(Guid token, string departmentCode, int carId)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.CarInServices.
                    Include(q => q.CarService).
                    Where(q => q.CarId == carId && q.CarService.DepartmentCode == departmentCode).
                    Select(a => a.CarService).
                    ToListAsync();
            }
        }

        public static async Task<bool> Add(Guid token, string departmentCode, CarService carService)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);

            carService.DepartmentCode = departmentCode;
            carService.CreatedDateTime = DateTime.Now;
            carService.CreatedBy = userInfo.Username;
            carService.CompanyCode = userInfo.CompanyCode;

            using (var db = new DataAccess.CaraxEntitiy())
            {
                await db.CarServices.AddAsync(carService);

                return await db.SaveChangesAsync() > 0;
            }

        }

        public static async Task<bool> Update(Guid token, string departmentCode, CarService carService)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);

            using (var db = new DataAccess.CaraxEntitiy())
            {
                carService.DepartmentCode = departmentCode;
                carService.UpdatedDateTime = DateTime.Now;
                carService.UpdatedBy = userInfo.Username;

                db.CarServices.Update(carService);

                return await db.SaveChangesAsync() > 0;
            }
        }

        public static async Task<bool> Delete(Guid token, string departmentCode, int id)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);


            using (var db = new DataAccess.CaraxEntitiy())
            {
                var findCarService = db.CarServices.First(q => q.Id == id);

                db.CarServices.Remove(findCarService);

                return await db.SaveChangesAsync() > 0;
            }
        }
    }
}

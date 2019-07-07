using System;
using System.Collections.Generic;
using System.Linq;
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
                return await db.Cars.Include(a => a.Brand)
                             .Include(a => a.BrandModel)
                             ?.Where(q => !q.IsDeleted && q.DepartmentCode == departmentCode && q.Maintenance == isMaintenance).
                            Select(a => new Models.Cars.Car
                            {
                                DepartmentCode = a.DepartmentCode,
                                Id = a.Id,
                                Name = a.Name,
                                BrandId = a.BrandId,
                                BrandModelId = a.BrandModelId,
                                BrandName = a.Brand.Name,
                                ModelName = a.BrandModel.Name,
                                CaseType = a.CaseType,
                                Classes = a.Classes,
                                Color = a.Color,
                                CompanyCode = a.CompanyCode,
                                Crash = a.Crash,
                                CreatedBy = a.CreatedBy,
                                CreatedDateTime = a.CreatedDateTime,
                                Deposit = a.Deposit,
                                EngineCapacity = a.EngineCapacity,
                                FuelType = a.FuelType,
                                GearType = a.GearType,
                                IsDeleted = a.IsDeleted,
                                Km = a.Km,
                                Maintenance = a.Maintenance,
                                MinDriverLicense = a.MinDriverLicense,
                                NumberOfDoors = a.NumberOfDoors,
                                Plate = a.Plate,
                                Price = a.Price,
                                VisualId = a.VisualId,
                                UpdatedBy = a.UpdatedBy,
                                UpdatedDateTime = a.UpdatedDateTime,
                                Year = a.Year,
                            })
                    ?.ToListAsync();
            }
        }

        public static async Task<bool> Add(Guid token, string departmentCode, Models.Cars.Car car)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);

            car.CreatedDateTime = DateTime.Now;
            car.CreatedBy = userInfo.Username;
            car.CompanyCode = userInfo.CompanyCode;
            car.DepartmentCode = departmentCode;

            using (var db = new DataAccess.CaraxEntitiy())
            {
                db.Cars.Add(car);
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

        public static async Task<bool> BeCrash(Guid token, int carId, bool crash = false)
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


        public static Models.Cars.Car GetSingleCar(Guid token, string departmentCode, int carId)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return db.Cars.Include(a => a.Brand)
                             .Include(a => a.BrandModel)
                             ?.Where(q => !q.IsDeleted && q.DepartmentCode == departmentCode && q.Id == carId).
                            Select(a => new Models.Cars.Car
                            {
                                DepartmentCode = a.DepartmentCode,
                                Id = a.Id,
                                Name = a.Name,
                                BrandId = a.BrandId,
                                BrandModelId = a.BrandModelId,
                                BrandName = a.Brand.Name,
                                ModelName = a.BrandModel.Name,
                                CaseType = a.CaseType,
                                Classes = a.Classes,
                                Color = a.Color,
                                CompanyCode = a.CompanyCode,
                                Crash = a.Crash,
                                CreatedBy = a.CreatedBy,
                                CreatedDateTime = a.CreatedDateTime,
                                Deposit = a.Deposit,
                                EngineCapacity = a.EngineCapacity,
                                FuelType = a.FuelType,
                                GearType = a.GearType,
                                IsDeleted = a.IsDeleted,
                                Km = a.Km,
                                Maintenance = a.Maintenance,
                                MinDriverLicense = a.MinDriverLicense,
                                NumberOfDoors = a.NumberOfDoors,
                                Plate = a.Plate,
                                Price = a.Price,
                                VisualId = a.VisualId,
                                UpdatedBy = a.UpdatedBy,
                                UpdatedDateTime = a.UpdatedDateTime,
                                Year = a.Year
                            })
                    ?.FirstOrDefault();
            }
        }

        public static async Task<IList<Models.Cars.Car>> AvailableCar(string departmentCode, DateTime beginDate, DateTime endDate)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Cars.Include(q => q.Reservations)
                    .Where(q => q.DepartmentCode == departmentCode && !q.IsDeleted && !q.Crash && !q.Maintenance && !q.Reservations.
                        Any(a => ((a.BeginDateTime <= beginDate && a.EndDateTime >= beginDate) || (a.BeginDateTime <= endDate && a.EndDateTime >= endDate)) || beginDate <= a.BeginDateTime && endDate >= a.EndDateTime))
                    .Select(a => new Models.Cars.Car
                    {
                        DepartmentCode = a.DepartmentCode,
                        Id = a.Id,
                        Name = a.Name,
                        BrandId = a.BrandId,
                        BrandModelId = a.BrandModelId,
                        BrandName = a.Brand.Name,
                        ModelName = a.BrandModel.Name,
                        CaseType = a.CaseType,
                        Classes = a.Classes,
                        Color = a.Color,
                        CompanyCode = a.CompanyCode,
                        Crash = a.Crash,
                        CreatedBy = a.CreatedBy,
                        CreatedDateTime = a.CreatedDateTime,
                        Deposit = a.Deposit,
                        EngineCapacity = a.EngineCapacity,
                        FuelType = a.FuelType,
                        GearType = a.GearType,
                        IsDeleted = a.IsDeleted,
                        Km = a.Km,
                        Maintenance = a.Maintenance,
                        MinDriverLicense = a.MinDriverLicense,
                        NumberOfDoors = a.NumberOfDoors,
                        Plate = a.Plate,
                        Price = a.Price,
                        VisualId = a.VisualId,
                        UpdatedBy = a.UpdatedBy,
                        UpdatedDateTime = a.UpdatedDateTime,
                        Year = a.Year
                    })
                    .ToListAsync();
            }
        }

    }
}

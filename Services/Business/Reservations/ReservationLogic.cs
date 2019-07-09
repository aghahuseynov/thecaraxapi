using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.EntityFrameworkCore;
using Models.Reservations;

namespace Services.Business.Reservations
{
    public static class ReservationLogic
    {
        public static async Task<List<Models.Reservations.ReservationsCarsCustomer>> GetList(string departmentCode, bool isApproval = false)
        {
            try
            {
                using (var db = new DataAccess.CaraxEntitiy())
                {
                    return await db.Reservations.
                        Include(a => a.Car).
                        Include(a => a.Car.Brand).
                        Include(a => a.Car.BrandModel).
                        Include(a => a.Customer).
                        Where(q => !q.IsDeleted && q.DepartmentCode == departmentCode && q.IsApproval == isApproval)
                        .Select(a => new ReservationsCarsCustomer
                        {
                            ReservationStartDateTime = a.BeginDateTime,
                            ReservationEndDateTime = a.EndDateTime,
                            ReservationPrice = a.Price,
                            ReservationId = a.Id,
                            CarBrandName = a.Car.Brand.Name,
                            CarEngineCapacity = a.Car.EngineCapacity,
                            CarId = a.CarId,
                            CarModelName = a.Car.BrandModel.Name,
                            CarPlate = a.Car.Plate,
                            CarPrice = a.Car.Price,
                            CustomerFirstPhone = a.Customer.FirstPhone,
                            CustomerId = a.CustomerId,
                            CustomerName = a.Customer.Name,
                            CustomerSurname = a.Customer.Surname,
                            ReservationState = a.ReservationStatus,
                            CreatedDateTime = a.CreatedDateTime
                        }).
                        OrderByDescending(q => q.CreatedDateTime).
                        ToListAsync();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static async Task<List<Models.Reservations.Reservation>> GetByCarId(Guid token, string departmentCode, int carId)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Reservations.Where(q => !q.IsDeleted && q.DepartmentCode == departmentCode && q.CarId == carId).ToListAsync();
            }
        }

        public static async Task<List<Models.Reservations.Reservation>> GetByCustomerId(Guid token, string departmentCode, int customerId)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Reservations.Where(q => !q.IsDeleted && q.DepartmentCode == departmentCode && q.CustomerId == customerId).ToListAsync();
            }
        }

        public static async Task<List<Models.Reservations.Reservation>> GetByStatus(Guid token, string departmentCode, int statusId)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Reservations.Where(q => !q.IsDeleted && q.DepartmentCode == departmentCode && q.ReservationStatus == statusId).ToListAsync();
            }
        }

        public static async Task<bool> Create(Guid token, Models.Reservations.Reservation reservation)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);

            using (var db = new DataAccess.CaraxEntitiy())
            {
                reservation.CreatedDateTime = DateTime.Now;
                reservation.CreatedBy = userInfo.Username;
                reservation.DepartmentCode = userInfo.DepartmentCode;
                reservation.CompanyCode = userInfo.CompanyCode;

                await db.Reservations.AddAsync(reservation);

                return await db.SaveChangesAsync() > 0;
            }
        }

        public static async Task<bool> Update(Guid token, Models.Reservations.Reservation reservation)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);

            using (var db = new DataAccess.CaraxEntitiy())
            {
                reservation.UpdatedDateTime = DateTime.Now;
                reservation.UpdatedBy = userInfo.Username;
                db.Reservations.Update(reservation);
                return await db.SaveChangesAsync() > 0;
            }
        }

    }
}

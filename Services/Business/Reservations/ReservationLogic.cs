using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.EntityFrameworkCore;

namespace Services.Business.Reservations
{
    public static class ReservationLogic
    {
        public static async Task<List<Models.Reservations.Reservation>> GetList(Guid token, string departmentCode, bool isApproval=false)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Reservations.Where(q => !q.IsDeleted && q.DepartmentCode == departmentCode && q.IsApproval == isApproval).ToListAsync();
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

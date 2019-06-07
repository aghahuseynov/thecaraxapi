using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;

namespace Services.Business.Reservations
{
    public static class ServicesInReservationLogic
    {
        public static async Task<bool> Create(Guid token, string departmentCode,
            Models.Reservations.ServicesInReservation servicesInReservation)
        {

            var userinfo = AuthenticationLogic.CheckTokenInfo(token);

            servicesInReservation.DepartmentCode = departmentCode;
            servicesInReservation.CreatedDateTime = DateTime.Now;
            servicesInReservation.CreatedBy = userinfo.Username;

            using (var db = new DataAccess.CaraxEntitiy())
            {
                await db.ServicesInReservations.AddAsync(servicesInReservation);
                return await db.SaveChangesAsync() > 0;
            }
        }
    }
}

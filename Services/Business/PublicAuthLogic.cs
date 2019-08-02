using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.EntityFrameworkCore;
using Models.Reservations;

namespace Services.Business
{
    public static class PublicAuthLogic
    {
        public static async Task<bool> CheckAccessToken(string accessToken,  string departmentCode)
        {
            var validToken = Guid.TryParse(accessToken, out Guid result);

            if (!validToken)
            {
                return false;
            }

            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Departments.AnyAsync(q => q.AccessToken.Value == result && q.Code == departmentCode);
            }
        }
    }
}

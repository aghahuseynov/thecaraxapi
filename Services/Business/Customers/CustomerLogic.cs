using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.EntityFrameworkCore;

namespace Services.Business.Customers
{
    public static class CustomerLogic
    {
        public static async Task<List<Models.Customers.Customer>> GetList(Guid token, string departmentCode, bool isActive = true)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Customers
                    ?.Where(q => q.IsActive == isActive && q.DepartmentCode == departmentCode && !q.IsDeleted)
                    ?.ToListAsync();
            }
        }

        public static async Task<Models.Customers.Customer> Get(Guid token, string departmentCode, int customerId)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Customers
                    .FirstOrDefaultAsync(q => q.DepartmentCode == departmentCode && q.Id == customerId);
            }
        }

        public static async Task<bool> Add(Guid token, Models.Customers.Customer customer)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);

            customer.CreatedDateTime = DateTime.Now;
            customer.CreatedBy = userInfo.Username;
            customer.DepartmentCode = userInfo.DepartmentCode;

            using (var db = new DataAccess.CaraxEntitiy())
            {
                if (!await CheckCurrentCustomers(customer))
                {
                    await db.Customers.AddAsync(customer);
                    return await db.SaveChangesAsync() > 0;
                }

                return false;
            }
        }

        private static async Task<bool> CheckCurrentCustomers(Models.Customers.Customer customer)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
               return db.Customers.Any(q => q.Tc == customer.Tc || q.FirstPhone == customer.FirstPhone || q.EMail == customer.EMail);
            }
        }

        public static async Task<bool> Remove(Guid token, int customerId)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                var find = db.Customers.First(q => q.Id == customerId);
                db.Customers.Remove(find);
                return await db.SaveChangesAsync() > 0;
            }
        }

        public static async Task<bool> Update(Guid token, Models.Customers.Customer customer)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);
            using (var db = new DataAccess.CaraxEntitiy())
            {
                customer.UpdatedDateTime = DateTime.Now;
                customer.UpdatedBy = userInfo.Username;
                db.Customers.Update(customer);
                return await db.SaveChangesAsync() > 0;
            }
        }

    }
}

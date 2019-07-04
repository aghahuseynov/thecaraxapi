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

        public static async Task<Models.Customers.Customer> GetByCustomerTc(Guid token, string departmentCode, string tc)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Customers
                    .FirstOrDefaultAsync(q => q.DepartmentCode == departmentCode && q.Tc == tc);
            }
        }

        public static async Task<bool> Add(Guid token, Models.Customers.Customer customer)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);

            customer.CreatedDateTime = DateTime.Now;
            customer.CreatedBy = userInfo.Username;
            customer.DepartmentCode = userInfo.DepartmentCode;
            customer.CompanyCode = userInfo.CompanyCode;

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
               return db.Customers.Any(q => q.Tc == customer.Tc || q.FirstPhone == customer.FirstPhone);
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
                var cs = db.Customers.First(q => q.Id == customer.Id);
                cs.Tc = customer.Tc;
                cs.Address = customer.Address;
                cs.BirthOfDateTime = customer.BirthOfDateTime;
                cs.EMail = customer.EMail;
                cs.FirstPhone = customer.FirstPhone;
                cs.Gender = customer.Gender;
                cs.Name = customer.Name;
                cs.Nationality = customer.Nationality;
                cs.PassportSerialNumber = customer.PassportSerialNumber;
                cs.SecondPhone = customer.SecondPhone;
                cs.SerialNumberOfDrivingLicense = customer.SerialNumberOfDrivingLicense;
                cs.Surname = customer.Surname;
                cs.LicenseYear = cs.LicenseYear;
                cs.UpdatedDateTime = DateTime.Now;
                cs.UpdatedBy = userInfo.Username;
                cs.CompanyCode = userInfo.CompanyCode;
                cs.DepartmentCode = userInfo.DepartmentCode;


                db.Customers.Update(cs);
                return await db.SaveChangesAsync() > 0;
            }
        }

    }
}

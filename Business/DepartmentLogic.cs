using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using DataAccess;

namespace Business
{
    public static class DepartmentLogic
    {
        public static async Task<Models.Department> Get(string departmentCode)
        {
            using (var db = new Entities())
            {
                return await db.Departments.Where(q => q.Code == departmentCode).Select(q => new Models.Department
                {
                    Code = q.Code,
                    Address = q.Address,
                    CompanyCode = q.CompanyCode,
                    CreatedBy = q.CreatedBy,
                    CreatedDateTime = q.CreatedDateTime,
                    VisualId = q.VisualId,
                    UpdatedBy = q.UpdatedBy,
                    UpdatedDateTime = q.UpdatedDateTime,
                    Name = q.Name,
                    Email = q.Email
                }).FirstOrDefaultAsync();
            }
        }

        public static IList<Models.Department> GetAll()
        {
            using (var db = new Entities())
            {
                return db.Departments.Select(q => new Models.Department
                {
                    Code = q.Code,
                    Address = q.Address,
                    CompanyCode = q.CompanyCode,
                    CreatedBy = q.CreatedBy,
                    CreatedDateTime = q.CreatedDateTime,
                    VisualId = q.VisualId,
                    UpdatedBy = q.UpdatedBy,
                    UpdatedDateTime = q.UpdatedDateTime,
                    Name = q.Name,
                    Email = q.Email
                }).ToList();
            }
        }


    }
}

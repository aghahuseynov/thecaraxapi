using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public static class DepartmentLogic
    {
        public static async Task<Models.Department> Get(string departmentCode)
        {
            using (var db = new DataAccess.CaraxEntitiy())
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
                }).FirstOrDefaultAsync();
            }
        }

        public static IList<Models.Department> GetAll()
        {
            using (var db = new DataAccess.CaraxEntitiy())
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
                }).ToList();
            }
        }




        public async static Task<IList<Models.Department>> GetDepartments(Guid token)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);

            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Departments.Where(q => q.CompanyCode == userInfo.CompanyCode)?.ToListAsync();
            }
        }

        public async static Task<bool> Create(Guid token, Models.Department model)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);

            using (var db = new DataAccess.CaraxEntitiy())
            {
                model.CreatedDateTime = DateTime.Now;
                model.CreatedBy = userInfo.Username;
                model.CompanyCode = userInfo.CompanyCode;

                await db.Departments.AddAsync(model);
                return await db.SaveChangesAsync() > 0;
            }
        }


        public async static Task<bool> Update (Guid token , string departmentCode , Models.Department model)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(token);
            using (var db = new DataAccess.CaraxEntitiy())
            {
                model.UpdatedBy = userInfo.Username;
                model.UpdatedDateTime = DateTime.Now;
                model.CompanyCode = userInfo.CompanyCode;
                model.Code = departmentCode;

                db.Departments.Update(model);
                return await db.SaveChangesAsync() > 0;
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Models.Users;

namespace Business
{
    public static class UserLogic
    {
        public static async Task<List<Models.Users.User>> Get(string departmentCode)
        {
            using (var db = new DataAccess.Entities())
            {
                return await db.Users.Where(q => q.DepartmentCode == departmentCode && q.IsActive && !q.IsDeleted).Select(q => new Models.Users.User
                {
                     IsActive =  q.IsActive,
                     DepartmentCode =  q.DepartmentCode,
                     IsDeleted =  q.IsDeleted,
                     CompanyCode =  q.CompanyCode,
                     CreatedBy =  q.CreatedBy,
                     CreatedDateTime =  q.CreatedDateTime,
                     EMail =  q.EMail,
                     Id =  q.Id,
                     Name =  q.Name,
                     Surname = q.Surname,
                     UpdatedBy = q.UpdatedBy,
                     UpdatedDateTime = q.UpdatedDateTime,
                     UserLevel =  q.UserLevel,
                     Username = q.Username,
                     VisualId = q.VisualId
                    
                }) .ToListAsync();
            }
        }

        public static  Models.Users.User Get(int userId)
        {
            using (var db = new DataAccess.Entities())
            {
                return  db.Users.Where(q => q.IsActive && !q.IsDeleted && q.Id == userId).Select(q => new Models.Users.User
                {
                    IsActive = q.IsActive,
                    DepartmentCode = q.DepartmentCode,
                    IsDeleted = q.IsDeleted,
                    CompanyCode = q.CompanyCode,
                    CreatedBy = q.CreatedBy,
                    CreatedDateTime = q.CreatedDateTime,
                    EMail = q.EMail,
                    Id = q.Id,
                    Name = q.Name,
                    Surname = q.Surname,
                    UpdatedBy = q.UpdatedBy,
                    UpdatedDateTime = q.UpdatedDateTime,
                    UserLevel = q.UserLevel,
                    Username = q.Username,
                    VisualId = q.VisualId

                }).FirstOrDefault();
            }
        }

    }
}

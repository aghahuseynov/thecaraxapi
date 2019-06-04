using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using UserDepartment = Models.Users.UserDepartment;

namespace Business
{
    public static class UserDepartmentLogic
    {
        public static List<Models.Users.UserDepartment> GetListByUser(int userId)
        {
            using (var db = new Entities())
            {
                return db.UserDepartments.Where(q => q.UserId == userId)?.Select(q => new UserDepartment
                {
                    DepartmentCode = q.DepartmentCode,
                    Id = q.Id,
                    Username = q.Username,
                    CompanyCode = q.CompanyCode,
                    UserId = q.UserId
                }).ToList();
            }
        }
    }
}

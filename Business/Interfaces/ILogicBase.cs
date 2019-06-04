using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILogicBase<T>
    {
       Task<List<T>> Get(Guid token, string departmentCode);

       Task<T> Get(Guid token, string departmentCode, int id);
    }
}

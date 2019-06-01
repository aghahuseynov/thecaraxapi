using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Services
{
    public class Attributes : AuthorizeAttribute
    {
        public Attributes()
        {
            Roles = "";
        }

    }
}

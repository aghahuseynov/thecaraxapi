using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Interfaces
{
    public interface ISoftDelete
    {
        [Column(TypeName = "bit")]
        bool IsDeleted { get; set; }
    }
}

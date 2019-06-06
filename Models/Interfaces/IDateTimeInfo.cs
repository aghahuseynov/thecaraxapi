using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Interfaces
{
    public interface IDateTimeInfo
    {
        [Column(TypeName = "datetime")]
        DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime")]
        DateTime? UpdatedDateTime { get; set; }
    }
}

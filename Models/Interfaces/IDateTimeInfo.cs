using System;

namespace Models.Interfaces
{
    public interface IDateTimeInfo
    {
        DateTime CreatedDateTime { get; set; }
        DateTime? UpdatedDateTime { get; set; }
    }
}

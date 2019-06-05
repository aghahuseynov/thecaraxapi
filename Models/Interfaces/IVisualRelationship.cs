using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Interfaces
{
    public interface IVisualRelationship
    {
        [ForeignKey("Visual")]
        int? VisualId { get; set; }
        Visual Visual { get; set; }
    }
}

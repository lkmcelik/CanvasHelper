using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CanvasHelperServerApp.Models
{
    public partial class Criterion : DatabaseObject
    {

        [Column("idAssignment")]
        public int? IdAssignment { get; set; }
        [Column(TypeName = "text")]
        public string Name { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        public int? MaxMark { get; set; }

        [ForeignKey(nameof(IdAssignment))]
        [InverseProperty(nameof(Assignment.Criteria))]
        public virtual Assignment IdAssignmentNavigation { get; set; }

        [InverseProperty(nameof(UsersCriteriaFeedback.IdCriteriaNavigation))] //TODO: why doesn't this work?
        public virtual ICollection<UsersCriteriaFeedback> UsersCriteriaFeedbacks { get; set; } = new HashSet<UsersCriteriaFeedback>();
    }
}

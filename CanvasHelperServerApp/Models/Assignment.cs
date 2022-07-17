using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CanvasHelperServerApp.Models
{
    public partial class Assignment: DatabaseObject
    { 
 
        [Column("idCourse")]
        public int? IdCourse { get; set; }
        [Column("idAssignmentType")]
        public int? IdAssignmentType { get; set; }
        [Column(TypeName = "text")]
        public string Name { get; set; }

        [ForeignKey(nameof(IdAssignmentType))]
        [InverseProperty(nameof(AssignmentsType.Assignments))]
        public virtual AssignmentsType IdAssignmentTypeNavigation { get; set; }
        [ForeignKey(nameof(IdCourse))]
        [InverseProperty(nameof(Course.Assignments))]
        public virtual Course IdCourseNavigation { get; set; }
        public string CourseName => IdCourseNavigation?.Name;
        [InverseProperty(nameof(Criterion.IdAssignmentNavigation))]
        public virtual ICollection<Criterion> Criteria { get; set; } = new HashSet<Criterion>();
    }
}

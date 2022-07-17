using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CanvasHelperServerApp.Models
{
    public partial class UsersCriteriaFeedback : DatabaseObject
    {
        [Column("idUser")]
        public int? IdUser { get; set; }
        [Column("idCriteria")]
        public int? IdCriteria { get; set; }
        [Column("idFeedback")]
        public int? IdFeedback { get; set; }

        [ForeignKey(nameof(IdCriteria))]
        [InverseProperty(nameof(Criterion.UsersCriteriaFeedbacks))] 
        public virtual Criterion IdCriteriaNavigation { get; set; }
        [ForeignKey(nameof(IdFeedback))]
        public virtual Feedback IdFeedbackNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        public virtual User IdUserNavigation { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; } // for UI
    }
}

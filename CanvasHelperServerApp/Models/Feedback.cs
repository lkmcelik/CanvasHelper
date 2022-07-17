using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CanvasHelperServerApp.Models
{
    public partial class Feedback : IFeedback
    {
         
        [Column("idUser")]
        public int? IdUser { get; set; }

        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.Feedbacks))]
        public virtual User IdUserNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CanvasHelperServerApp.Models
{
    [Keyless]
    public partial class UsersFavoriteFeedback  
    {
        [Column("idUser")]
        public int? IdUser { get; set; }
        [Column("idFavoriteFeedback")]
        public int? IdFavoriteFeedback { get; set; }

        [ForeignKey(nameof(IdFavoriteFeedback))]
        public virtual FavoriteFeedback IdFavoriteFeedbackNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        public virtual User IdUserNavigation { get; set; }
    }
}

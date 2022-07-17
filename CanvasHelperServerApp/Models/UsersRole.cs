using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CanvasHelperServerApp.Models
{
    [Keyless]
    public partial class UsersRole
    {
        [Column("idUser")]
        public int? IdUser { get; set; }
        [Column("idRole")]
        public int? IdRole { get; set; }
        [ForeignKey(nameof(IdRole))]
        public virtual Role IdRoleNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        public virtual User IdUserNavigation { get; set; }
    }
}

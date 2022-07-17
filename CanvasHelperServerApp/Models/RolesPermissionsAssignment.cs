using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CanvasHelperServerApp.Models
{
    [Keyless]
    public partial class RolesPermissionsAssignment
    {
        [Column("idRole")]
        public int? IdRole { get; set; }
        [Column("idPermission")]
        public int? IdPermission { get; set; }
        [Column("idAssignment")]
        public int? IdAssignment { get; set; }

        [ForeignKey(nameof(IdAssignment))]
        public virtual Assignment IdAssignmentNavigation { get; set; }
        [ForeignKey(nameof(IdPermission))]
        public virtual Permission IdPermissionNavigation { get; set; }
        [ForeignKey(nameof(IdRole))]
        public virtual Role IdRoleNavigation { get; set; }
    }
}

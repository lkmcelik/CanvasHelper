using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CanvasHelperServerApp.Models
{
    public enum UserType
    {
        student = 1,
        teacher = 2
    }
    public partial class User : DatabaseObject
    {
        //[DataType(DataType.Text)]
        //[Column(TypeName ="text")]
        public UserType UserType { get; set; }
        [Column("idRole")]
        public int? IdRole { get; set; }
        [Column(TypeName = "text")]
        public string LastName { get; set; }
        [Column(TypeName = "text")]
        public string FirstName { get; set; }
        [Column(TypeName = "text")]
        public string? MiddleName { get; set; }
        [Column(TypeName = "text")]
        public string Password { get; set; }
        [Column(TypeName = "text")]
        public string PasswordHash { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }

        [InverseProperty(nameof(Feedback.IdUserNavigation))]
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();

        [NotMapped]
        public string FirstNameLastName { get; set; }

    }
}

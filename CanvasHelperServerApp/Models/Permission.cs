using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CanvasHelperServerApp.Models
{
    public partial class Permission : DatabaseObject
    {
        
        [Column(TypeName = "text")]
        public string Name { get; set; }
    }
}

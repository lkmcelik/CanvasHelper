using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanvasHelperServerApp.Models
{
    public abstract class DatabaseObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public virtual int ID { get; set; }

    }
}
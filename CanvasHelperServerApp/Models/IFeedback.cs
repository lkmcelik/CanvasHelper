using System.ComponentModel.DataAnnotations.Schema;

namespace CanvasHelperServerApp.Models
{
    public class IFeedback : DatabaseObject
    {
        [Column(TypeName = "text")]
        public string Name { get; set; }
        [Column(TypeName = "text")]
        public string Text { get; set; }
        public int? Mark { get; set; }
    }
}

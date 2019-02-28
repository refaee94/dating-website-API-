using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dating_app.models {
    public class value {
        [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long Id {get; set;}
        public string name {get; set;}

    }
}
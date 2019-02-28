using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dating_app.models  {
    public class user {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductId {get; set;}
        public string Name {get; set;}
        public byte[] hash {get; set;}
        public byte[] salt {get; set;}
       
    }
}

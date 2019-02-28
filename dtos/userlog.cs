using System.ComponentModel.DataAnnotations;

namespace dating_app.dtos
{
    public class userlog
    
    { [Required]
        public string uname { get; set; }
        [Required]
        [StringLength(8,MinimumLength=4,ErrorMessage="nust be betweem 4 and 8")]
        public string  pass { get; set; }

    }
}
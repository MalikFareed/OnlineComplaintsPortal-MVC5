using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Post
    {
        [Required]
        [Display(Name = "Post ID")]
        public int PostID { get; set; }

        [Required]
        [Display(Name = "Post Title")]
        public string PostTitle { get; set; }
    }
}

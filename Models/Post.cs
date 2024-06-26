using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public string? PosType { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

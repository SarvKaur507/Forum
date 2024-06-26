namespace Forum.Models.Dtos
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string? Content { get; set; }
        public string? PosType { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

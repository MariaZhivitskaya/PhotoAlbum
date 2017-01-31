using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public byte[] Picture { get; set; }

        [Required]
        public int NumberOfLikes { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}

namespace BLL.Interface.Entities
{
    public class ImageEntity
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int NumberOfLikes { get; set; }
        public int UserId { get; set; }
    }
}

namespace WebApplication.ViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int NumberOfLikes { get; set; }
        public int UserId { get; set; }
        public bool HasEstimateOfCurUsr { get; set; }
    }
}
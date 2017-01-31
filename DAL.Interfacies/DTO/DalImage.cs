using DAL.Interface.DTO;

namespace DAL.Interfacies.DTO
{
    public class DalImage : IEntity
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int NumberOfLikes { get; set; }
        public int UserId { get; set; }
    }
}

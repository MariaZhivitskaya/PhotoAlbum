using DAL.Interface.DTO;

namespace DAL.Interfacies.DTO
{
    public class DalLike: IEntity
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int UserId { get; set; }
    }
}

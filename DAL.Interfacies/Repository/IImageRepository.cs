using DAL.Interface.Repository;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IImageRepository : IRepository<DalImage>
    {
        void Update(int imageId);
    }
}

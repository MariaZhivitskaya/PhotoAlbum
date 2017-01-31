using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interfacies.Services
{
    public interface IImageService
    {
        void CreateImage(ImageEntity image);
        IEnumerable<ImageEntity> GetAllImageEntities();
        IEnumerable<ImageEntity> GetByUserId(int userId);
        ImageEntity GetImageEntity(int id);
        void ChangeNumberOfLikes(int imageId);
    }
}

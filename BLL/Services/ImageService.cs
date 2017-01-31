using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _uow;
        private readonly IImageRepository _imageRepository;

        public ImageService(IUnitOfWork uow, IImageRepository repository)
        {
            _imageRepository = repository;
            _uow = uow;
        }

        public void CreateImage(ImageEntity image)
        {
            _imageRepository.Create(image.ToDalImage());
            _uow.Commit();
        }

        public IEnumerable<ImageEntity> GetAllImageEntities() => 
            _imageRepository.GetAll().Select(img => img.ToBllImage());

        public IEnumerable<ImageEntity> GetByUserId(int userId) => 
            _imageRepository.GetAll().Where(img => img.UserId == userId).Select(img => img.ToBllImage());

        public ImageEntity GetImageEntity(int id) => 
            _imageRepository.GetById(id).ToBllImage();

        public void ChangeNumberOfLikes(int imageId) => 
            _imageRepository.Update(imageId);
    }
}

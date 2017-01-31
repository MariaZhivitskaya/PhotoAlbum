using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILikeRepository _likeRepository;

        public LikeService(IUnitOfWork uow, ILikeRepository repository)
        {
            _likeRepository = repository;
            _uow = uow;
        }

        public void CreateLike(LikeEntity like)
        {
            _likeRepository.Create(like.ToDalLike());
            _uow.Commit();
        }

        public IEnumerable<LikeEntity> GetAllLikeEntities() => 
            _likeRepository.GetAll().Select(like => like.ToBllLike());

        public bool IsInDb(int imageId, int userId)
        {
            var elem = _likeRepository.GetAll().Where(like => like.ImageId == imageId && like.UserId == userId);
            return elem.Any();
        }
    }
}

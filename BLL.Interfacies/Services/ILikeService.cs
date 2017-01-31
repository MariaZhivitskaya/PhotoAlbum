using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface ILikeService
    {
        void CreateLike(LikeEntity like);
        IEnumerable<LikeEntity> GetAllLikeEntities();
        bool IsInDb(int imageId, int userId);
    }
}

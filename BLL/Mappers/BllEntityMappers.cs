using BLL.Interface.Entities;
using DAL.Interface.DTO;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser()
            {
                Id = userEntity.Id,
                Email = userEntity.Email,
                Password = userEntity.Password,
                Surname = userEntity.Surname,
                Name = userEntity.Name,
                DateOfBirth = userEntity.DateOfBirth,
                RoleId = userEntity.RoleId,
                Banned = userEntity.Banned
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            if (dalUser == null)
                return null;

            return new UserEntity()
            {
                Id = dalUser.Id,
                Email = dalUser.Email,
                Password = dalUser.Password,
                Surname = dalUser.Surname,
                Name = dalUser.Name,
                DateOfBirth = dalUser.DateOfBirth,
                RoleId = dalUser.RoleId,
                Banned = dalUser.Banned
            };
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            return new RoleEntity()
            {
                Id = dalRole.Id,
                Description = dalRole.Description
            };
        }

        public static DalImage ToDalImage(this ImageEntity imageEntity)
        {
            return new DalImage()
            {
                Id = imageEntity.Id,
                Image = imageEntity.Image,
                NumberOfLikes = imageEntity.NumberOfLikes,
                UserId = imageEntity.UserId
            };
        }

        public static ImageEntity ToBllImage(this DalImage dalImage)
        {
            return new ImageEntity()
            {
                Id = dalImage.Id,
                NumberOfLikes = dalImage.NumberOfLikes,
                Image = dalImage.Image,
                UserId = dalImage.UserId
            };
        }

        public static DalLike ToDalLike(this LikeEntity likeEntity)
        {
            return new DalLike()
            {
                Id = likeEntity.Id,
                ImageId = likeEntity.ImageId,
                UserId = likeEntity.UserId};
        }

        public static LikeEntity ToBllLike(this DalLike dalLike)
        {
            return new LikeEntity()
            {
                Id = dalLike.Id,
                ImageId = dalLike.ImageId,
                UserId = dalLike.UserId
            };
        }
    }
}

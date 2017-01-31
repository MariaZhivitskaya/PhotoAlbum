using System.Drawing;
using BLL.Interface.Entities;
using WebApplication.ViewModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class WebApplicationMapper
    {
        public static UserEntity ToBllUser(this UserViewModel userViewModel) => 
            new UserEntity()
            {
                Id = userViewModel.Id,
                Email = userViewModel.Email,
                Password = userViewModel.Password,
                Surname = userViewModel.Surname,
                Name = userViewModel.Name,
                DateOfBirth = userViewModel.DateOfBirth,
                RoleId = userViewModel.RoleId
            };

        public static ImageEntity ToBllImage(this ImageViewModel imageViewModel) => 
            new ImageEntity()
            {
                Id = imageViewModel.Id,
                NumberOfLikes = imageViewModel.NumberOfLikes,
                Image = imageViewModel.Image,
                UserId = imageViewModel.UserId
            };

        public static LikeEntity ToBllLike(this LikeViewModel likeViewModel) => 
            new LikeEntity()
            {
                Id = likeViewModel.Id,
                ImageId = likeViewModel.ImageId,
                UserId = likeViewModel.UserId
            };
    }
}
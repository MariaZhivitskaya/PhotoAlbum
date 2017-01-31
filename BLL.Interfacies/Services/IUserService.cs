using System.Collections.Generic;
using BLL.Interface.Entities;


namespace BLL.Interface.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntity(int id);
        IEnumerable<UserEntity> GetAllUserEntities();
        void CreateUser(UserEntity user);
        UserEntity GetUserByEmail(string email);
        IEnumerable<UserEntity> GetUsersExceptCurrent(string currentUserEmail);
        IEnumerable<UserEntity> GetUnbannedUsersExceptCurrent(string currentUserEmail);
        void BanUnbanUser(string email);
    }
}
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext uow)
        {
            _context = uow;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return _context.Set<User>().Select(user => new DalUser()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Surname = user.Surname,
                Name = user.Name,
                DateOfBirth = user.DateOfBirth,
                RoleId = user.RoleId,
                Banned = user.Banned,            
            });
        }

        public DalUser GetById(int key)
        {
            var ormuser = _context.Set<User>().FirstOrDefault(user => user.Id == key);
            return new DalUser()
            {
                Id = ormuser.Id,
                Email = ormuser.Email,
                Password = ormuser.Password,
                Surname = ormuser.Surname,
                Name = ormuser.Name,
                DateOfBirth = ormuser.DateOfBirth,
                RoleId = ormuser.RoleId,
                Banned = ormuser.Banned
            };
        }

        public void Create(DalUser e)
        {
            var user = new User()
            {
                Email = e.Email,
                Password = e.Password,
                Surname = e.Surname,
                Name = e.Name,
                DateOfBirth = e.DateOfBirth,
                RoleId = e.RoleId,
                Banned = e.Banned
            };
            _context.Set<User>().Add(user);
        }

        public DalUser GetByEmail(string email)
        {
            var ormuser = _context.Set<User>().FirstOrDefault(user => user.Email == email);
            if (ormuser == null)
                return null;

            return new DalUser()
            {
                Id = ormuser.Id,
                Email = ormuser.Email,
                Password = ormuser.Password,
                Surname = ormuser.Surname,
                Name = ormuser.Name,
                DateOfBirth = ormuser.DateOfBirth,
                RoleId = ormuser.RoleId,
                Banned = ormuser.Banned
            };
        }

        public void BanUnbanUser(string email)
        {
            var ormUsr = _context.Set<User>().FirstOrDefault(user => user.Email == email);
            ormUsr.Banned = !ormUsr.Banned;
            _context.SaveChanges();
        }
    }
}
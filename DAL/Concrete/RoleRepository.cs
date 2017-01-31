using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext _context;

        public RoleRepository(DbContext uow)
        {
            _context = uow;
        }

        public IEnumerable<DalRole> GetAllRoles() => 
            _context.Set<Role>().Select(role => new DalRole()
            {
                Id = role.Id,
                Description = role.Description
            });

        public DalRole GetById(int? roleId)
        {
            var getRole = _context.Set<Role>().FirstOrDefault(role => role.Id == roleId);
            return new DalRole()
            {
                Id = getRole.Id,
                Description = getRole.Description
            };
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository repository)
        {
            _roleRepository = repository;
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities() => 
            _roleRepository.GetAllRoles().Select(role => role.ToBllRole());
    }
}

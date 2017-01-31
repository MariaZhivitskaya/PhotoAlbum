using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IRoleRepository
    {
        IEnumerable<DalRole> GetAllRoles();
        DalRole GetById(int? roleId);
    }
}

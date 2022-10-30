using FileDoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDoc.Interfaces
{
    public interface IRoleModel
    {
        Task<List<RoleModel>> GetRole();
        Task<int> EditRole(RoleModel roleModel);
        Task<int> AddRole(RoleModel roleModel);
        Task<int> DeleteRole(int id);
    }
}

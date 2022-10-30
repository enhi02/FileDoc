using FileDoc.Model;
using FileDoc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDoc.Interfaces
{
    public interface IGroupPermission
    {
        Task<bool> AddGroupPermission(GroupPermission GroupPermissions);
        Task<bool> EditGroupPermission(int id, GroupPermission GroupPermissions);
        Task<List<GroupPermission>> GetGroupPermissionAll();
        Task<GroupPermission> GetGroupPermission(int? id);
    }
}

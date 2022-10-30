using FileDoc.Interfaces;
using FileDoc.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDoc.Services
{
    public class GroupPermissionSvc : IGroupPermission
    {
        protected DataContext _context;
        public GroupPermissionSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddGroupPermission(GroupPermission GroupPermissions)
        {
            _context.Add(GroupPermissions);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditGroupPermission(int id, GroupPermission GroupPermissions)
        {
            _context.groupPermissions.Update(GroupPermissions);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GroupPermission>> GetGroupPermissionAll()
        {
            var dataContext = _context.groupPermissions;
            return await dataContext.ToListAsync();
        }

        public async Task<GroupPermission> GetGroupPermission(int? id)
        {
            var GroupPermissions = await _context.groupPermissions
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (GroupPermissions == null)
            {
                return null;
            }

            return GroupPermissions;
        }
    }
}

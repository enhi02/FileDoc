using FileDoc.Interfaces;
using FileDoc.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDoc.Services
{
    public class RoleModelSvc : IRoleModel
    {
        protected DataContext _context;

        public async Task<List<RoleModel>> GetRole()
        {
            var role = await _context.roles.ToListAsync();
            return role;
        }
        public async Task<RoleModel> roleId(int id)
        {

            var role = await _context.roles.FindAsync(id);
            return role;
        }
        public async Task<int> EditRole(RoleModel roleModel)
        {
            int ret = 0;
            try
            {
                RoleModel role = null;
                role = await roleId(roleModel.RoleId);
                role.RoleName = roleModel.RoleName;

                _context.Update(role);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> AddRole(RoleModel roleModel)
        {
            int ret = 0;
            try
            {
                _context.Add(roleModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }// thêm role

        public async Task<int> DeleteRole(int id)
        {
            int ret = 0;
            try
            {
                var role = await roleId(id);
                _context.Remove(role);
                await _context.SaveChangesAsync();
                ret = role.RoleId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }//xóa role
    }
}

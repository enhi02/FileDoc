using FileDoc.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileDoc.Models;
using FileDoc.Models.ViewModel;
//using FileDoc.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using FileDoc.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FileDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class GroupPermissionController : ControllerBase
    {
        private readonly IGroupPermission _groupPermission;
        private readonly DataContext _context;
        public GroupPermissionController(DataContext context, IGroupPermission groupPermission)
        {
            _context = context;
            _groupPermission = groupPermission;
        }
        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<int>> AddGroup(GroupPermission group)
        {
            try
            {
                await _groupPermission.AddGroupPermission(group);
            }
            catch (Exception ex)
            {

            }
            return Ok(new
            {
                retCode = 1,
                retText = "Thêm thành công"
            });
        }
        [HttpGet]
        [Route("ListGroup")]
        public async Task<ActionResult<IEnumerable<GroupPermission>>> GetGroupAllAsync()
        {
            return await _groupPermission.GetGroupPermissionAll();

        }
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> PutGroup(int id, GroupPermission group)
        {
            if (id != group.GroupId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _groupPermission.EditGroupPermission(id, group);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(
                 new
                 {
                     retCode = 1,
                     retText = "Sửa thành công"
                 });
        }
        private bool GroupExists(int id)
        {
            return _context.groupPermissions.Any(e => e.GroupId == id);

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var Group = await _context.groupPermissions.FindAsync(id);
            if (Group == null)
            {
                return NotFound();
            }

            _context.groupPermissions.Remove(Group);
            await _context.SaveChangesAsync();

            return Ok(
                 new
                 {
                     retCode = 1,
                     retText = "Xóa thành công"
                 });
        }
    }
}

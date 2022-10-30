using FileDoc.Interfaces;
using FileDoc.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoleModelController : ControllerBase
    {
        private readonly IRoleModel _role;
        private readonly DataContext _context;
        public RoleModelController(DataContext context, IRoleModel role)
        {
            _context = context;
            _role = role;
        }
        [HttpGet]
        [Route("GetRole")]
        public async Task<ActionResult<IEnumerable<RoleModel>>> GetRole()
        {
            var role = await _role.GetRole();
            return role;
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<ActionResult<int>> AddRole(RoleModel roleModel)
        {
            try
            {
                var id = await _role.AddRole(roleModel);
                roleModel.RoleId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditRole")]
        public async Task<ActionResult<int>> EditRole(RoleModel roleModel)
        {
            try
            {
                var id = await _role.EditRole(roleModel);
                roleModel.RoleId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteRole/{id}")]
        public async Task<ActionResult<int>> DeleteRole(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _role.DeleteRole(id);

            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }
    }
}

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

    public class UserModelController : ControllerBase
    {
        private readonly IUserModel _user;
        private readonly DataContext _context;
        public UserModelController(DataContext context, IUserModel user)
        {
            _context = context;
            _user = user;
        }
        [HttpPost, ActionName("user")]
        public async Task<IActionResult> PostAsync(UserModel users)
        {
            if (ModelState.IsValid)
            {
                if (await _user.isEmail(users.Email))
                {
                    return Ok(new
                    {
                        retCode = 0,
                        retText = "Email đã tồn tại",
                        data = ""
                    });
                }
                else
                {
                    if (await _user.AddUserAsync(users))
                    {
                        return Ok(new
                        {
                            retCode = 1,
                            retText = "Thành công",
                            data = await _user.GetUserAsync(users.UserId)
                        });
                    }
                }

            }
            return Ok(new
            {
                retCode = 0,
                retText = "Thất bại"
            });
        }
        [HttpGet]
        [Route("ListUser")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUserAllAsync()
        {

            return await _user.GetUserAllAsync(); ;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserModel User)
        {
            if (id != User.UserId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);




            try
            {
                await _user.EditUserAsync(id, User);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new
            {
                //_NguoiDung.GetNguoidungAsync(id),
                retCode = 0,
                retText = "Update thành công"
            });

        }
        private bool UserExists(int id)
        {
            return _context.users.Any(e => e.UserId == id);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();

            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

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

namespace FileDoc.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class TokenController : ControllerBase
    {
        protected readonly IUserModel _user;
        public IConfiguration _confi;
        public TokenController(IUserModel userSvc, IConfiguration confi)
        {
            _user = userSvc;
            _confi = confi;
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] ViewLogin viewLogin)
        {
            if (ModelState.IsValid)
            {
                var stu = await _user.LoginAsync(viewLogin);
                if (stu != null)
                {
                    var token = CreateToken(stu);
                    ViewToken viewToken = new ViewToken() { Token = token, User = stu };
                    return Ok(new
                    {
                        retCode = 1,
                        retText = "Đăng nhập thành công",
                        data = viewToken
                    });
                }
                else
                {
                    return Ok(new
                    {
                        retCode = 0,
                        retText = "Tài khoản hoặc mật khẩu không chính xác",
                        data = ""
                    });
                }
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Dữ liệu không hợp lệ",
                data = ""
            });
        }
        [HttpPut("{email}")]
        [ActionName("ChangePassAdmin")]
        public async Task<IActionResult> ChangePassWord(string email, UserModel user)
        {
            if (email != user.Email)
            {
                return BadRequest();
            }
            try
            {
                await _user.ChangePasswordCode(email, user);
                user.Email = email;
            }
            catch (Exception ex)
            {
                return BadRequest(1);
            }
            return Ok(
                new
                {
                    retCode = 1,
                    retText = "Thành công"
                });
        }
        private string CreateToken(UserModel user)
        {
            try
            {
                var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.Sub, _confi["Token:JwtSubject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Aud, _confi["Token:JwtAudience"]),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confi["Token:JwtSecurityKey"]));
                var expiry = DateTime.Now.AddDays(Convert.ToInt32(_confi["Token:JwtExpiryInDays"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _confi["Token:JwtIssuer"],
                    _confi["Token:JwtAudience"],
                    claims,
                    expires: expiry,
                    signingCredentials: creds
                );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return jwt;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}

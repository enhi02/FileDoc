using FileDoc.Interfaces;
using FileDoc.Model;
using FileDoc.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDoc.Services
{
    public class UserModelSvc : IUserModel
    {
        protected DataContext _context;
        public UserModelSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUserAsync(UserModel users)
        {
            _context.Add(users);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditUserAsync(int id, UserModel users)
        {
            _context.users.Update(users);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserModel>> GetUserAllAsync()
        {
            var dataContext = _context.users;
            return await dataContext.ToListAsync();
        }

        public async Task<UserModel> GetUserAsync(int? id)
        {
            var users = await _context.users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (users == null)
            {
                return null;
            }

            return users;
        }
        public async Task<UserModel> GetUserEmail(string email)
        {
            UserModel users = null;
            users = await _context.users.FirstOrDefaultAsync(u => u.Email == email);
            return users;
        }
        public async Task<bool> isEmail(string email)
        {
            bool ret = false;
            try
            {
                UserModel user = await _context.users.Where(x => x.Email == email).FirstOrDefaultAsync();
                if (user != null)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        public async Task<UserModel> LoginAsync(ViewLogin login)
        {
            UserModel user = await _context.users.Where(x => x.Email == login.Email
                  && x.Password == (login.Password)).FirstOrDefaultAsync();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        public async Task<int> ChangePasswordCode(string email, UserModel user)
        {
            int ret = 0;
            try
            {

                UserModel _user = null;
                _user = await GetUserEmail(email);


                _user.Password = user.Password;
                _context.Update(_user);
                await _context.SaveChangesAsync();

                ret = user.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
    }
}

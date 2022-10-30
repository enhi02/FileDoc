using FileDoc.Model;
using FileDoc.Models.ViewModel;
using FileDoc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDoc.Interfaces
{
    public interface IUserModel
    {
        Task<List<UserModel>> GetUserAllAsync();
        Task<bool> EditUserAsync(int id, UserModel users);
        Task<bool> AddUserAsync(UserModel users);
        Task<UserModel> GetUserAsync(int? id);
        Task<bool> isEmail(string email);//kiem tra ton tai cua email

        //Task<bool> DeleteUserAsync(int id, UserModel User);
        //Task<UserModel> Login(ViewLogin viewLogin);

        Task<UserModel> LoginAsync(ViewLogin login);
        Task<int> ChangePasswordCode(string email, UserModel user);
    }
}

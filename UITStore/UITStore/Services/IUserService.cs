using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;

namespace UITStore.Services
{
    public interface IUserService
    {
        Task<UserModel> AddUser(RequestUser user);
        Task<UserModel> Login(LoginModel login);
        Task<UserModel> UpdateUser(User user);
        Task<UserModel> ChangePassword(Guid id, string password);
        Task<UserModel> GetUserById(Guid id);
        Task<ListUserModel> GetListUser();
    }
}

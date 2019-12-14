using ErrorCenter.Application.ViewModels;
using ErrorCenter.Domain.Models;
using System.Collections.Generic;

namespace ErrorCenter.Application.Interfaces
{
    public interface IUserService
    {
        bool RegisterUser(string email, string password, string name);

        public List<User> ConsultAllUsers();
        public User ValidateUserToken(string usertToken);
    }
}

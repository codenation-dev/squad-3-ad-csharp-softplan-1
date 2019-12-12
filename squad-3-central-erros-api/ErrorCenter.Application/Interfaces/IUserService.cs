using ErrorCenter.Domain.Models;
using System.Collections.Generic;

namespace ErrorCenter.Application.Interfaces
{
    public interface IUserService
    {
        bool RegisterUser(string email, string password, string name);

        public List<User> ConsultAllUsers();
        bool Login(string email, string password);
    }
}

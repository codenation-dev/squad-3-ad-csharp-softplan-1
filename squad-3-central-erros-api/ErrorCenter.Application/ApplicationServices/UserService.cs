using AceleraDev.CrossCutting.Utils;
using ErrorCenter.Application.Interfaces;
using ErrorCenter.Application.ViewModels;
using ErrorCenter.Data.Context;
using ErrorCenter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErrorCenter.Application.ApplicationServices
{
    public class UserService : IUserService
    {
        private ErrorCenterContext _context;

        public UserService(ErrorCenterContext context)
        {
            this._context = context;
        }

        public bool RegisterUser(string email, string password, string name)
        {
            //passa passwd para md5
            _context.Users.Add(new User { Email = email, Password = password.ToHashMD5(), Name = name });

            if (_context.Users.FirstOrDefault(u => u.Email == email && u.Password == password.ToHashMD5() && u.Name == name) != null)
            {
                return true;
            }

            return false;
        }

        public List<User> ConsultAllUsers()
        {
            return _context.Users.Select(l => l).ToList();
        }

        public User ValidateUserToken(string usertToken)
        {
            var user = _context.Users.Where(l => (!string.IsNullOrEmpty(usertToken) && l.Token == usertToken))
                .FirstOrDefault();

            return user;
        }

    }
}

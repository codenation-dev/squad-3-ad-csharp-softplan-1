using AceleraDev.CrossCutting.Utils;
using ErrorCenter.Application.Interfaces;
using ErrorCenter.Application.ViewModels;
using ErrorCenter.Data.Context;
using ErrorCenter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorCenter.Application.ApplicationServices
{
	public class SystemAuthenticationService : ISystemAuthenticationService
	{
		public ErrorCenterContext _context;

		public SystemAuthenticationService(ErrorCenterContext context)
		{
			this._context = context;
		}

		public User Authenticate(LoginViewModel login)
		{
			var user = _context.Users.Where(p => p.Email == login.Login &&
											p.Password == login.Password.ToHashMD5())
				.FirstOrDefault();
													  
			return user;
		}
	}
}


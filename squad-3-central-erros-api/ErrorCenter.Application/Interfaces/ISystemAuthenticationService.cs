using ErrorCenter.Application.ViewModels;
using ErrorCenter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCenter.Application.Interfaces
{
	public interface ISystemAuthenticationService
	{
		public User Authenticate(LoginViewModel login);
	}
}

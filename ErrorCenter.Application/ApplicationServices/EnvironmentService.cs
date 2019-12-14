using ErrorCenter.Application.Interfaces;
using ErrorCenter.Data.Context;
using ErrorCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ErrorCenter.Application.ApplicationServices
{
    public class EnvironmentService : IEnvironmentService
    {
        public ErrorCenterContext _context;

        public EnvironmentService(ErrorCenterContext context)
        {
            this._context = context;
        }

        public Environment RegisterEnvironment(Environment environment)
        {
            //_context.Environments.Add(new Models.Environment { EnvironmentName = name });

            //if (_context.Environments.FirstOrDefault(e => e.EnvironmentName == name) != null)
            //{
            //    return true;
            //}

            //return false;

            var state = environment.Id == 0 ? EntityState.Added : EntityState.Modified;
            _context.Entry(environment).State = state;
            _context.SaveChanges();
            return environment;
        }

        public Environment ConsultEnvironment(int id)
        {
            return _context.Environments.Find(id);
        }

        public List<Environment> ConsultAllEnvironments()
        {
            return _context.Environments.ToList();
        }
    }
}

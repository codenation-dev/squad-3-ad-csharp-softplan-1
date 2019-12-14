using ErrorCenter.Application.Interfaces;
using ErrorCenter.Data.Context;
using ErrorCenter.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ErrorCenter.Application.ApplicationServices
{
    public class ErrorService : IErrorService
    {

        private ErrorCenterContext _context;

        public ErrorService(ErrorCenterContext context)
        {
            this._context = context;
        }

        public bool RegisterError(int environmentId, int levelId, int situationId, string title)
        {
            _context.Errors.Add(new Error { EnvironmentId = environmentId, LevelId = levelId, SituationId = situationId, Title = title });

            if (_context.Errors.FirstOrDefault(e => e.EnvironmentId == environmentId && e.LevelId == levelId && e.SituationId == situationId && e.Title == title) != null)
            {
                return true;
            }

            return false;
        }

        public List<Error> GetAllErros()
        {
            return _context.Errors.Select(l => l).ToList();
        }

        public Error ConsultError(int id)
        {
            return _context.Errors.Find(id);
        }

    }

}

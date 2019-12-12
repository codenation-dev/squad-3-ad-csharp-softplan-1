using ErrorCenter.Application.Interfaces;
using ErrorCenter.Data.Context;
using ErrorCenter.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ErrorCenter.Application.ApplicationServices
{
    public class SituationService : ISituationService
    {
        public ErrorCenterContext _context;

        public SituationService(ErrorCenterContext context)
        {
            this._context = context;
        }

        public bool RegisterSituation(string name)
        {
            _context.Situations.Add(new Situation { SituationName = name });

            if (_context.Situations.FirstOrDefault(s => s.SituationName == name) != null)
            {
                return true;
            }

            return false;
        }

        public Situation ConsultSituation(int id)
        {
            return _context.Situations.Find(id);
        }

        public List<Situation> ConsultAllSituations()
        {
            return _context.Situations.Select(s => s).ToList();
        }
    }
}

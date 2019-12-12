using ErrorCenter.Application.Interfaces;
using ErrorCenter.Data.Context;
using ErrorCenter.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ErrorCenter.Application.ApplicationServices
{
    public class LevelService : ILevelService
    {
        public ErrorCenterContext _context;

        public LevelService(ErrorCenterContext context)
        {
            this._context = context;
        }

        public bool RegisterLevel(string name)
        {
            _context.Levels.Add(new Level { LevelName = name });

            if (_context.Levels.FirstOrDefault(l => l.LevelName == name) != null)
            {
                return true;
            }

            return false;
        }

        public Level ConsultLevel(int id)
        {
            return _context.Levels.Find(id);
        }

        public List<Level> ConsultAllLevels()
        {
            return _context.Levels.Select(l => l).ToList();
        }
    }
}

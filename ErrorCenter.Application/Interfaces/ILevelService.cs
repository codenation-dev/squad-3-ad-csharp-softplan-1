using ErrorCenter.Domain.Models;
using System.Collections.Generic;

namespace ErrorCenter.Application.Interfaces
{
    public interface ILevelService
    {
        bool RegisterLevel(string name);

        Level ConsultLevel(int id);

        List<Level> ConsultAllLevels();
    }
}

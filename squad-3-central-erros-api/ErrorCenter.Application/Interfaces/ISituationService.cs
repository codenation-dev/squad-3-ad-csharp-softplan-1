using ErrorCenter.Domain.Models;
using System.Collections.Generic;

namespace ErrorCenter.Application.Interfaces
{
    public interface ISituationService
    {
        bool RegisterSituation(string name);

        Situation ConsultSituation(int id);

        List<Situation> ConsultAllSituations();
    }
}

using ErrorCenter.Domain.Models;
using System.Collections.Generic;

namespace ErrorCenter.Application.Interfaces
{
    public interface IErrorService
    {
        bool RegisterError(int environmentId, int levelId, int situationId, string title);

        public List<Error> GetAllErros();
        Error ConsultError(int id);
    }
}

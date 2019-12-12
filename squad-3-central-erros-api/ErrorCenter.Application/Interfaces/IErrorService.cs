using ErrorCenter.Domain.Models;

namespace ErrorCenter.Application.Interfaces
{
    public interface IErrorService
    {
        bool RegisterError(int environmentId, int levelId, int situationId, string title);
        Error ConsultError(int id);
    }
}

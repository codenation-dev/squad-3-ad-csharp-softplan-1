using ErrorCenter.Domain.Models;
using System.Collections.Generic;

namespace ErrorCenter.Application.Interfaces
{
    public interface IEnvironmentService
    {

        Environment RegisterEnvironment(Environment environment);

        Environment ConsultEnvironment(int id);

        List<Environment> ConsultAllEnvironments();
    }
}

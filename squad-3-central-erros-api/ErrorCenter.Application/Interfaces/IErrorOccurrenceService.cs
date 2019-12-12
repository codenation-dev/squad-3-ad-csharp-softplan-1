using ErrorCenter.Domain.Models;
using System;
using System.Collections.Generic;

namespace ErrorCenter.Application.Interfaces
{
    public interface IErrorOccurrenceService
    {
        // cadastra e retorna sucesso ou falha
        bool RegisterError(Error error, User user, string origin, string details, DateTime dateTime, string userToken);

        // retorna a lista (detalhada) de todos os erros de um tipo de level individualmente
        List<ErrorOccurrence> ListOccurencesByLevel(int level);

        public List<ErrorOccurrence> GetAllErrorOccurrences();

        // retorna 
        List<ErrorOccurrence> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado);

    }
}

using ErrorCenter.Application.ViewModels;
using ErrorCenter.Domain.Models;
using System;
using System.Collections.Generic;

namespace ErrorCenter.Application.Interfaces
{
    public interface IErrorOccurrenceService
    {
        // cadastra erro com base em objeto com dadso complatos
        public void RegisterError(CompleteDataErrorViewModel errorData);

        // retorna a lista (detalhada) de todos os erros de um tipo de level individualmente
        List<ErrorOccurrence> ListOccurencesByLevel(int level);

        public List<ErrorOccurrence> GetAllErrorOccurrences();

        // retorna 
        public ErrorOccurrencesResultPageViewModel GetErrorOccurrencesParams(int idAmbiente,
            int tamanhoPagina, int pagina, string tipoOrdenacao, string tipoFiltro, string valorFiltro);

    }
}

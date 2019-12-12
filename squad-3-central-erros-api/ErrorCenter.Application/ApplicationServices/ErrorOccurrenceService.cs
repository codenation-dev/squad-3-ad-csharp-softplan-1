using ErrorCenter.Application.Interfaces;
using ErrorCenter.Data.Context;
using ErrorCenter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErrorCenter.Application.ApplicationServices
{
    public class ErrorOccurrenceService : IErrorOccurrenceService
    {

        private ErrorCenterContext _context;

        public ErrorOccurrenceService(ErrorCenterContext context)
        {
            this._context = context;
        }

        public bool RegisterError(Error error, User user, string origin, string details, DateTime dateTime, string userToken)
        {
            _context.ErrorOccurrences.Add(new ErrorOccurrence { Error = error, User = user, Origin = origin, Details = details, DateTime = dateTime });

            if (_context.ErrorOccurrences.FirstOrDefault(e => e.Error == error && e.User == user && e.Origin == origin && e.Details == details && e.DateTime == dateTime) != null)
            {
                return true;
            }

            return false;
        }

        public List<ErrorOccurrence> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado)
        {
            // dado vem do frontEnd

            // Campo ordenação
            // 1 - Level
            // 2 - Frequência

            // Campo buscado
            // 1 - Level
            // 2 - Descrição
            // 3 - Origem

            //TODO

            //Func<OcorrenciaErro, Object> orderByFunc = null;
            //if (sortOrder == SortOrder.SortByName)
            //    orderByFunc = item => item.Error.Level;
            //else if (sortOrder == SortOrder.SortByRank)
            //    orderByFunc = item => item.Rank;

            string ordenacao = null;

            if (campoOrdenacao == 1)
            {
                ordenacao = "Error.Level";

            }
            else if (campoOrdenacao == 2)
            {
                ordenacao = "Error.Frequencia";
            }

            return _context.ErrorOccurrences.Where(o => o.Error.EnvironmentId == ambiente).ToList();
        }

        public List<ErrorOccurrence> ListOccurencesByLevel(int level)
        {
            return _context.ErrorOccurrences.Where(o => o.Error.LevelId == level).ToList();
        }
    }
}

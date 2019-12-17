using AutoMapper;
using ErrorCenter.Application.Interfaces;
using ErrorCenter.Application.ViewModels;
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
        private readonly IMapper _mapper;

        public ErrorOccurrenceService(IMapper mapper, ErrorCenterContext context)
        {
            this._context = context;
            this._mapper = mapper;
        }

    
            // cadastra erro com base em objeto com dadso complatos
        public void RegisterError(CompleteDataErrorViewModel errorData)
        {
            DefinirValoresPadrao(errorData);

            var error = new Error()
            {
                Code = errorData.ErrorCode,
                Description = errorData.ErrorDescription,
                EnvironmentId = errorData.EnvironmentId,
                LevelId = errorData.LevelId,
                Title = errorData.ErrorTitle,
                SituationId = errorData.SituationId,
            };

            var errorSaved = _context.Errors.Add(error);


            _context.ErrorOccurrences.Add(new ErrorOccurrence
            {
                Error = error,
                //ErrorId = errorSaved.Entity.Id,
                DateTime = DateTime.Parse(errorData.DateTime),
                Details = errorData.ErrorDetails,
                EventCount = errorData.ErrorEventCount,
                Origin = errorData.ErrorOrigin,
                UserId = errorData.UserId,
            });


            _context.SaveChanges();
        }

        private static void DefinirValoresPadrao(CompleteDataErrorViewModel errorData)
        {
            if (errorData.EnvironmentId < 1)
                errorData.EnvironmentId = 1;

            if (errorData.LevelId < 1)
                errorData.LevelId = 1;

            if (errorData.SituationId < 1)
                errorData.SituationId = 1;

            if (errorData.ErrorEventCount < 1)
                errorData.ErrorEventCount = 1;

            if (string.IsNullOrEmpty(errorData.ErrorTitle))
                errorData.ErrorTitle = "ErrorTitle omitido";

            if (string.IsNullOrEmpty(errorData.ErrorDescription))
                errorData.ErrorDescription = "ErrorDescription omitido";

            if (string.IsNullOrEmpty(errorData.ErrorDetails))
                errorData.ErrorDetails = "ErrorDetails omitido";

            if (string.IsNullOrEmpty(errorData.ErrorOrigin))
                errorData.ErrorOrigin = "ErrorOrigin omitido";

            if (string.IsNullOrEmpty(errorData.DateTime))
                errorData.DateTime = DateTime.Now.ToString();
        }

        private bool testarItemCorrespondeFiltro(ErrorOccurrence erro, string tipoFiltro, string valorFiltro)
        {
            if (tipoFiltro == "T")
                return true;

            if (valorFiltro == "none")
                return true;


            if (string.IsNullOrEmpty(valorFiltro))
                return true;


            if (tipoFiltro == "L")
                return erro.Error.Level.Id.ToString().Contains(valorFiltro.ToUpper()) ||
                    erro.Error.Level.Name.ToUpper().Contains(valorFiltro.ToUpper());


            if (tipoFiltro == "D")
                return erro.Details.ToUpper().Contains(valorFiltro.ToUpper()) ||
                    erro.Error.Title.ToUpper().Contains(valorFiltro.ToUpper());

            if (tipoFiltro == "O")
                return erro.Origin.Contains(valorFiltro);

            return true;
        }


        public ErrorOccurrencesResultPageViewModel GetErrorOccurrencesParams(int idAmbiente,
            int tamanhoPagina, int pagina, string tipoOrdenacao, string tipoFiltro, string valorFiltro)

        {

            int skip = (pagina - 1) * tamanhoPagina;


            var res = new ErrorOccurrencesResultPageViewModel()
            {
                IdAmbiente = idAmbiente,
                PaginaAtual = pagina,
                TamanhoPagina = tamanhoPagina,
                TipoFiltro = tipoFiltro,
                TipoOrdenacao = tipoOrdenacao,
                ValorFiltro = valorFiltro
            };

            res.QuantidadeTotal = 0;

            var bSemFiltro = false; 
            if ( (tipoFiltro == "T") || (valorFiltro == "none") ||  (string.IsNullOrEmpty(valorFiltro)) )
            {
                bSemFiltro = true;
            }
            else
            if (tipoFiltro == "L")
            {
                res.QuantidadeTotal = _context.ErrorOccurrences.Where(
                        errorOcor => errorOcor.Error.EnvironmentId == idAmbiente && (errorOcor.Error.Level.Id.ToString().Contains(valorFiltro.ToUpper()) ||
                                     errorOcor.Error.Level.Name.ToUpper().Contains(valorFiltro.ToUpper()))).Count();

                res.ErrorOccurrences = _mapper.Map<List<ErrorOccurrenceViewModel>>(
                        _context.ErrorOccurrences.Where(
                        errorOcor => errorOcor.Error.EnvironmentId == idAmbiente && (errorOcor.Error.Level.Id.ToString().Contains(valorFiltro.ToUpper()) ||
                                     errorOcor.Error.Level.Name.ToUpper().Contains(valorFiltro.ToUpper())))
                        .OrderByDescending(p => p.DateTime)
                        .Skip(skip)
                        .Take(tamanhoPagina)
                        .ToList()
                    );
            }
            else
            if (tipoFiltro == "D")
            {
                res.QuantidadeTotal = _context.ErrorOccurrences.Where(
                        errorOcor => errorOcor.Error.EnvironmentId == idAmbiente && (errorOcor.Details.ToUpper().Contains(valorFiltro.ToUpper()) ||
                                     errorOcor.Error.Title.ToUpper().Contains(valorFiltro.ToUpper()))).Count();

                res.ErrorOccurrences = _mapper.Map<List<ErrorOccurrenceViewModel>>(
                        _context.ErrorOccurrences.Where(
                        errorOcor => errorOcor.Error.EnvironmentId == idAmbiente && (errorOcor.Details.ToUpper().Contains(valorFiltro.ToUpper()) ||
                                     errorOcor.Error.Title.ToUpper().Contains(valorFiltro.ToUpper())))
                        .OrderByDescending(p => p.DateTime)
                        .Skip(skip)
                        .Take(tamanhoPagina)
                        .ToList()
                    );
            }
            else
            if (tipoFiltro == "O")
            {
                res.QuantidadeTotal =   _context.ErrorOccurrences.Where(
                                        errorOcor => errorOcor.Error.EnvironmentId == idAmbiente && 
                                        errorOcor.Origin.Contains(valorFiltro)).Count();

                res.ErrorOccurrences = _mapper.Map<List<ErrorOccurrenceViewModel>>(
                        _context.ErrorOccurrences.Where(
                        errorOcor => errorOcor.Error.EnvironmentId == idAmbiente && 
                        errorOcor.Origin.Contains(valorFiltro))
                        .OrderByDescending(p => p.DateTime)
                        .Skip(skip)
                        .Take(tamanhoPagina)
                        .ToList()
                    );
            }
            else
            {
                bSemFiltro = true;
            }


            if(bSemFiltro)
            {
                res.QuantidadeTotal = _context.ErrorOccurrences.Where(
                        errorOcor => errorOcor.Error.EnvironmentId == idAmbiente && errorOcor.Id > 0).Count();

                res.ErrorOccurrences = _mapper.Map<List<ErrorOccurrenceViewModel>>(
                        _context.ErrorOccurrences.Where(
                        errorOcor => errorOcor.Error.EnvironmentId == idAmbiente && 
                        errorOcor.Id > 0)
                        .OrderByDescending(p => p.DateTime)
                        .Skip(skip)
                        .Take(tamanhoPagina)
                        .ToList()
                    );
            }

            if ((tipoOrdenacao != "") && (tipoOrdenacao != "none"))
                res.ErrorOccurrences = res.ErrorOccurrences.OrderBy(p => tipoOrdenacao == "L" ? p.Error.LevelId : 
                p.EventCount).ToList();


            
            res.QuantidadePaginas = res.QuantidadeTotal / tamanhoPagina;
            if ((res.QuantidadeTotal % tamanhoPagina) > 0)
                res.QuantidadePaginas++;

            return res;
        }

        public List<ErrorOccurrence> GetAllErrorOccurrences()
        {
            return _context.ErrorOccurrences.Select(l => l).ToList();
        }

        public List<ErrorOccurrence> ListOccurencesByLevel(int level)
        {
            return _context.ErrorOccurrences.Where(o => o.Error.LevelId == level).ToList();
        }
    }
}

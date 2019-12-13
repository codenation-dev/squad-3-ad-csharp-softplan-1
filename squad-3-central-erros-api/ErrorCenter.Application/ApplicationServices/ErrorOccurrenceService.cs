﻿using AutoMapper;
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

        public bool RegisterError(Error error, User user, string origin, string details, DateTime dateTime, string userToken)
        {
            _context.ErrorOccurrences.Add(new ErrorOccurrence { Error = error, User = user, Origin = origin, Details = details, DateTime = dateTime });

            if (_context.ErrorOccurrences.FirstOrDefault(e => e.Error == error && e.User == user && e.Origin == origin && e.Details == details && e.DateTime == dateTime) != null)
            {
                return true;
            }

            return false;
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


            res.QuantidadeTotal = _context.ErrorOccurrencesCount();
            res.QuantidadePaginas = res.QuantidadeTotal / tamanhoPagina;
            if ((res.QuantidadeTotal % tamanhoPagina) > 0)
                res.QuantidadePaginas++;

            var bSemFiltro = false; 
            if ( (tipoFiltro == "T") || (valorFiltro == "none") ||  (string.IsNullOrEmpty(valorFiltro)) )
            {
                bSemFiltro = true;
            }
            else
            if (tipoFiltro == "L")
            {
                res.ErrorOccurrences = _mapper.Map<List<ErrorOccurrenceViewModel>>(
                        _context.ErrorOccurrences.Where(
                        errorOcor => errorOcor.Error.Level.Id.ToString().Contains(valorFiltro.ToUpper()) ||
                                     errorOcor.Error.Level.Name.ToUpper().Contains(valorFiltro.ToUpper()))
                        .OrderByDescending(p => p.DateTime)
                        .Skip(skip)
                        .Take(tamanhoPagina)
                        .ToList()
                    );
            }
            else
            if (tipoFiltro == "D")
            {
                res.ErrorOccurrences = _mapper.Map<List<ErrorOccurrenceViewModel>>(
                        _context.ErrorOccurrences.Where(
                        errorOcor => errorOcor.Details.ToUpper().Contains(valorFiltro.ToUpper()) ||
                                     errorOcor.Error.Title.ToUpper().Contains(valorFiltro.ToUpper()))
                        .OrderByDescending(p => p.DateTime)
                        .Skip(skip)
                        .Take(tamanhoPagina)
                        .ToList()
                    );
            }
            else
            if (tipoFiltro == "O")
            {
                res.ErrorOccurrences = _mapper.Map<List<ErrorOccurrenceViewModel>>(
                        _context.ErrorOccurrences.Where(
                        errorOcor => errorOcor.Origin.Contains(valorFiltro))
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
                res.ErrorOccurrences = _mapper.Map<List<ErrorOccurrenceViewModel>>(
                        _context.ErrorOccurrences.Where(
                        errorOcor => errorOcor.Id > 0)
                        .OrderByDescending(p => p.DateTime)
                        .Skip(skip)
                        .Take(tamanhoPagina)
                        .ToList()
                    );
            }

            if ((tipoOrdenacao != "") && (tipoOrdenacao != "none"))
                res.ErrorOccurrences = res.ErrorOccurrences.OrderBy(p => tipoOrdenacao == "L" ? p.Error.LevelId : 
                p.EventCount).ToList();

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

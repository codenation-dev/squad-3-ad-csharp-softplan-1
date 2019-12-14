using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCenter.Application.ViewModels
{
	public class ErrorOccurrencesResultPageViewModel
	{
        /*
         * Lista com os erros da consulta.
         */
        public List<ErrorOccurrenceViewModel> ErrorOccurrences = new List<ErrorOccurrenceViewModel>();


        /**
         * Filtro do ambiente dso logs (Sempre deve ser definido pelo cliente)
         **/
        public int IdAmbiente { get; set; }

        /**
         * Tipo do filtro: 'T' - Todos (sem filtro), 'L' - Level', 'D' - Descrição, 'O' - IP de Origem
         * */
        public string TipoFiltro { get; set; }

        /**
         * Valor do tipo de ordenação usado nmos resultados, se "" ou "none" orde natural,
         * senão, se "L" por nível senão (ou == "F") por frequencia
         * */
        public string TipoOrdenacao { get; set; }

        /**
         * Valor do filtro aplciado nos resultados, se TipoFiltro != 'T'
         * */
        public string ValorFiltro { get; set; }

        /**
         * Quantidade total de registros do resultado
         **/
        public int QuantidadeTotal { get; set; }

        /**
         * Quantidade máxima de registros por página (definido pelo cliente ao chamar a consulta)
        **/
        public int TamanhoPagina { get; set; }

        /**
         * Pagina atual (1..) (definido pelo cliente ao chamar a consulta)
         **/
        public int PaginaAtual { get; set; }

        /**
         * Quantidae de páginas (definido por esta API ao retornar a consulta)
         **/
        public int QuantidadePaginas { get; set; }


    }
}

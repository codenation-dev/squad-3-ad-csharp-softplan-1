import React, { Component } from 'react';
import api from '../../services/api';
import Dados from '../../comps/dados';
import DataCombo from '../../comps/DataCombo';
import DataFilter from '../../comps/DataFilter';


import './styles.css';

const ordenacoes = ([{id: "", nome: "Ordenar por"}, {id: "L", nome: "Level"}, {id: "F", nome: "Frequência"}]);
const tiposFiltro = ([{id: "T", nome: "Buscar por"}, {id: "L", nome: "Level"}, {id: "D", nome: "Descrição"},
{id: "O", nome: "Origem"}]);


export default class Main extends Component {
   
    state = {
        erros: [],
        info: {},
        idAmbiente: 1, 
        tamanhoPagina: 5,
        tipoFiltro: "T",
        valorFiltro: "",
        paginaAtual: 1,
        qtdItensSelecionados: 0,
        tipoOrdenacao: "",

        serverError: "",

        selecionados: [],
    };

    componentDidMount() {
        const {idAmbiente, tipoOrdenacao, tipoFiltro, valorFiltro, paginaAtual} = this.state;
        this.loadErros("componentDidMount", idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro);
    }

    strParam = (param, def) => {
        let val = def;
        if((param !== undefined) && (param !== "") )
        {
            val = param;
        }
        return val;
    }

    apiExecute = async (query, verbo = "get", obj) => {

        let serverError = "";
        this.setState({serverError});

        let response;
        let ok = true;
        let solicitacao = " query (" + verbo +")-> " + query;
        try
        {
            console.log(solicitacao)

            if(verbo === "get")
                response = await api.get(query);
            if(verbo === "delete")
                response = await api.delete(query);
            if(verbo === "put")
                response = await api.put(query, obj);
            return response;
        } catch(ex) {
            serverError = "Erro ao executar solicitação ao servidor ( " + solicitacao + " ):" +
            ex;
            ok = false;
        }
        if(ok && ( (response.status < 200) || (response.status >= 300) ) )
        {
            ok = false;   
            serverError =  `status ${response.status} - ${response.statusText}`;
            return null;
        }
        if(!ok){
            this.setState({serverError});
            return null;
        } 


    }

    loadErros = async (sender, idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro) => {
        const {tamanhoPagina} = this.state;

        console.log("antes de chamar cons (" + sender+ ") para pag " + paginaAtual);
        
        //const response = await api.get(`/erros/pag=${paginaAtual}`);
        let valfiltro = this.strParam(valorFiltro, "none");
        let tipofiltro = this.strParam(tipoFiltro, "T");
        let tipoOrd = this.strParam(tipoOrdenacao, "none");

        if((valorFiltro !== undefined) && (valorFiltro !== "") )
        {
            valfiltro = valorFiltro;
        }
        const query = `/erros/${idAmbiente}/${tamanhoPagina}/${paginaAtual}/${tipoOrd}/${tipofiltro}/${valfiltro}`;
        console.log(`cons  -> idAmbiente:${idAmbiente}/tamanhoPagina:${tamanhoPagina}/paginaAtual:${paginaAtual}/tipoOrd:${tipoOrd}/tipofiltro:${tipofiltro}/valfiltro:${valfiltro}`);

        let response = await this.apiExecute(query);

        if(response === null)
            return;

        //console.log('depois de chamar');

        //console.log(response.data);
        const {erros, ...info} = response.data;

        this.setState({selecionados: [], qtdItensSelecionados: 0, idAmbiente, paginaAtual, 
            tipoOrdenacao: tipoOrd, tipoFiltro: tipofiltro, valorFiltro: valfiltro, erros, info});
    };

    prevPage = () => {
        const {idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro} = this.state;

        if(paginaAtual === 1) return;

        const pageNumber = paginaAtual - 1;

        //this.setState({paginaAtual: pageNumber});
        this.loadErros("prevPage", idAmbiente, pageNumber, tipoOrdenacao, tipoFiltro, valorFiltro);
    };

    nextPage = () => {
        const {idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro, info} = this.state;

        if(paginaAtual === info.quantidadePaginas) return;

        const pageNumber = paginaAtual + 1;

        //this.setState({paginaAtual: pageNumber});
        this.loadErros("nextPage", idAmbiente, pageNumber, tipoOrdenacao, tipoFiltro, valorFiltro);
    };

    arquivarItem = () => {
        const {selecionados, idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro, info} = this.state;

        if(selecionados.length < 1)
        {
            console.log("Sem seleção");
            return;
        }
        selecionados.map(id => {

            let query = "/erro/" + id;

            let obj = {
                id: id,
                arquivado: this.deveArquivar()
            }
            let response = this.apiExecute(query, "put", obj);
    
            if(response === null)
                return;        
    
        })

        this.loadErros("arquivarItem", idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro);
    };
    apagarItem = () => {
        const {selecionados, idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro, info} = this.state;

        if(selecionados.length < 1)
        {
            console.log("Sem seleção");
            return;
        }
        selecionados.map(id => {

            let query = "/erro/" + id;

            let response = this.apiExecute(query, "delete");
    
            if(response === null)
                return;        
    
        })

        this.loadErros("apagarItem", idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro);
    };

    handleDataComboAmbienteChanged = (dadosEvento) => {
        console.log("evento handleDataComboAmbienteChanged");
        
        const {paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro} = this.state;

        if(dadosEvento.id === "ambiente") 
        {
            console.log(`Mudando state para setar idAmbiente = ${dadosEvento.value}`);
            this.loadErros("handleDataComboAmbienteChanged:ambiente", dadosEvento.value, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro);
        }
    }

    handleDataComboChanged = (dadosEvento) => {
        console.log(`evento handleDataComboChanged( ${dadosEvento.id}, ${dadosEvento.value} )`);
        if(dadosEvento.id === "ordenacao") 
        {
            const {idAmbiente, paginaAtual, valorFiltro, tipoFiltro} = this.state;

            this.loadErros("handleDataComboChanged:ordenacao", idAmbiente, paginaAtual, dadosEvento.value, tipoFiltro, valorFiltro);
        }
        if(dadosEvento.id === "tipo-filtro") 
        {
            const {idAmbiente, paginaAtual, valorFiltro, tipoOrdenacao} = this.state;

            this.loadErros("handleDataComboChanged:tipo-filtro", idAmbiente, paginaAtual, tipoOrdenacao, dadosEvento.value, valorFiltro);
        }
    }

    handleDataFilterChanged = (dadosEvento) => {
        const {idAmbiente, tipoFiltro, tipoOrdenacao, paginaAtual} = this.state;

        console.log(`evento handleDataFilterChanged( ${dadosEvento.id}, ${dadosEvento.value} )`);
        if(dadosEvento.id === "filtro") 
            this.loadErros("handleDataFilterChanged:filtro", idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, dadosEvento.value);
    }

    handleDataChanged = (dadosEvento) => {
        console.log(dadosEvento);
        if(dadosEvento.type !== "sel")
            return;
          
        const {selecionados} = this.state;

        let sel = [];

        if(dadosEvento.value)
        {
            console.log("Adicionando " + dadosEvento.id);
            sel = selecionados;
            sel.push(dadosEvento.id);
        } else {
            selecionados.forEach( (ele, index, arr) => {
                if(ele !== dadosEvento.id)
                    sel.push(ele);
            });
            console.log(sel);
        }

        this.setState({selecionados: sel, qtdItensSelecionados: sel.length});

    };

    deveArquivar = () => {
        const {selecionados, qtdItensSelecionados, erros} = this.state;
        if (qtdItensSelecionados !== 1)
            return true;

        let id = selecionados[0];
        console.log(id);
        const erroEncontrado = erros.find(erro => erro.id == id);

        console.log("erroEncontrado:");
        console.log(erroEncontrado);
        let arquivado = false;
        if(erroEncontrado !== undefined)
        {
          arquivado = erroEncontrado.arquivado;
        }

        if(arquivado === true)
            return false;

        return true;
    }

    calcTextArquivar = () => {
        if(this.deveArquivar())
            return "Arquivar";

        return "Desarquivar";
    }

    render() {
        //para facilitar o acesso
        const { selecionados, serverError, tipoFiltro, valorFiltro, tipoOrdenacao, erros, paginaAtual,
              qtdItensSelecionados, idAmbiente, info} = this.state;

        return (
            <div className="erro-list">

                <div className="actions">
                    <button disabled={paginaAtual === 1} onClick={this.prevPage}>Anterior</button>
                    <div className="article">{paginaAtual}/{info.quantidadePaginas}</div>
                    <button disabled={paginaAtual === info.quantidadePaginas} onClick={this.nextPage}>Próxima</button>
                </div>

                <div className="options">

                    <DataCombo id="ambiente" nomeEndPoint="/ambiente" value={idAmbiente} onChange={this.handleDataComboAmbienteChanged} />
                    <DataCombo id="ordenacao" nomeEndPoint="" options={ordenacoes} value={tipoOrdenacao} onChange={this.handleDataComboChanged} />
                    <DataCombo id="tipo-filtro" nomeEndPoint="" options={tiposFiltro} value={tipoFiltro} onChange={this.handleDataComboChanged} />

                    <DataFilter id="filtro" disabled={tipoFiltro === "T"} 
                        value={valorFiltro} onChange={this.handleDataFilterChanged} />
                </div>


                <div className="actions">
                    <button disabled={qtdItensSelecionados !== 1} onClick={this.arquivarItem}>{this.calcTextArquivar()}</button>
                    <button disabled={qtdItensSelecionados === 0} onClick={this.apagarItem}>Apagar</button>
                </div>

                <Dados erros={erros} selecionados={selecionados} onChange={this.handleDataChanged} />

                
                <div className="msg-erro"> {serverError}</div>

            </div>

        )
    }
}
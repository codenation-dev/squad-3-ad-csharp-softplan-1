import React, { Component } from 'react';
import api from '../../services/api';
import Dados from '../../comps/dados';
import DataCombo from '../../comps/DataCombo';
import DataFilter from '../../comps/DataFilter';
import Header from '../../comps/Header';
import {getIdUsuario, logout} from '../../services/auth.js';


import './styles.css';

const ordenacoes = ([{id: "", name: "Ordenar por"}, {id: "L", name: "Level"}, {id: "F", name: "Frequência"}]);
const tiposFiltro = ([{id: "T", name: "Buscar por"}, {id: "L", name: "Level"}, {id: "D", name: "Descrição"},
{id: "O", nome: "Origem"}]);

const logAtivo = true;

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
            if(logAtivo) console.log(solicitacao)

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

        if(logAtivo) console.log("antes de chamar cons (" + sender+ ") para pag " + paginaAtual);
        
        //const response = await api.get(`/erros/pag=${paginaAtual}`);
        let valfiltro = this.strParam(valorFiltro, "none");
        let tipofiltro = this.strParam(tipoFiltro, "T");
        let tipoOrd = this.strParam(tipoOrdenacao, "none");

        if((valorFiltro !== undefined) && (valorFiltro !== "") )
        {
            valfiltro = valorFiltro;
        }
        //const query = `/erros/${idAmbiente}/${tamanhoPagina}/${paginaAtual}/${tipoOrd}/${tipofiltro}/${valfiltro}`;
        const query = `/erroroccurrences/${idAmbiente}/${tamanhoPagina}/${paginaAtual}/${tipoOrd}/${tipofiltro}/${valfiltro}`;

        if(logAtivo) console.log(`cons  -> idAmbiente:${idAmbiente}/tamanhoPagina:${tamanhoPagina}/paginaAtual:${paginaAtual}/tipoOrd:${tipoOrd}/tipofiltro:${tipofiltro}/valfiltro:${valfiltro}`);

        let response = await this.apiExecute(query);

        if(response === null)
            return;

        //console.log('depois de chamar');

        console.log(response.data);
        //const {erros, ...info} = response.data;
        const {errorOccurrences, ...info} = response.data;

        this.setState({selecionados: [], qtdItensSelecionados: 0, idAmbiente, paginaAtual, 
            tipoOrdenacao: tipoOrd, tipoFiltro: tipofiltro, valorFiltro: valfiltro, erros: errorOccurrences, info});
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
        const {selecionados, idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro} = this.state;

        if(selecionados.length < 1)
        {
            if(logAtivo) console.log("Sem seleção");
            return;
        }
        selecionados.map(id => {
            /*
            this.apiExecute(`/erro/{id}`, "put", {
                id: id,
                arquivado: this.deveArquivar()
            });
            */
           let situacao = this.deveArquivar() ? 2 : 1;
           this.apiExecute(`/erroroccurrences/{id}`, "put", {
            id: id,
            error: {
                SituationId: situacao
            }
        });
        return id;
        })

        this.loadErros("arquivarItem", idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro);
    };
    apagarItem = () => {
        const {selecionados, idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro} = this.state;

        if(selecionados.length < 1)
        {
            if(logAtivo) console.log("Sem seleção");
            return;
        }

        selecionados.map(id => {
            //this.apiExecute(`/erro/{id}`, "delete");
            this.apiExecute(`/erroroccurrences/{id}`, "delete");
            
            return id;
        });

        this.loadErros("apagarItem", idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro);
    };

    handleDataComboAmbienteChanged = (dadosEvento) => {
        if(logAtivo)  console.log("evento handleDataComboAmbienteChanged");
        
        const {paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro} = this.state;

        if(dadosEvento.id === "ambiente") 
        {
            if(logAtivo) console.log(`Mudando state para setar idAmbiente = ${dadosEvento.value}`);
            this.loadErros("handleDataComboAmbienteChanged:ambiente", dadosEvento.value, paginaAtual, tipoOrdenacao, tipoFiltro, valorFiltro);
        }
    }

    handleDataComboChanged = (dadosEvento) => {
        if(logAtivo) console.log(`evento handleDataComboChanged( ${dadosEvento.id}, ${dadosEvento.value} )`);
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

        if(logAtivo) console.log(`evento handleDataFilterChanged( ${dadosEvento.id}, ${dadosEvento.value} )`);
        if(dadosEvento.id === "filtro") 
        {
            if(dadosEvento.value.substring(0, 2) === "p:")
            {
                let tamanhoPagina = dadosEvento.value.substring(2);
                if(logAtivo) console.log(`Alterando tam. página para  ${tamanhoPagina}`);
                this.setState({tamanhoPagina});
            }
            else
            {
                this.loadErros("handleDataFilterChanged:filtro", idAmbiente, paginaAtual, tipoOrdenacao, tipoFiltro, dadosEvento.value);
            }
        }
    }

    handleDataChanged = (dadosEvento) => {
        if(logAtivo) console.log(dadosEvento);
        if(dadosEvento.type !== "sel")
            return;
          
        const {selecionados} = this.state;

        let sel = [];

        if(dadosEvento.value)
        {
            if(logAtivo)  console.log("Adicionando " + dadosEvento.id);
            sel = selecionados;
            sel.push(dadosEvento.id);
        } else {
            selecionados.forEach( (ele, index, arr) => {
                if(ele !== dadosEvento.id)
                    sel.push(ele);
            });
            if(logAtivo) console.log(sel);
        }

        this.setState({selecionados: sel, qtdItensSelecionados: sel.length});

    };

    deveArquivar = () => {
        const {selecionados, qtdItensSelecionados, erros} = this.state;
        if (qtdItensSelecionados !== 1)
            return true;

        let id = selecionados[0];
        if(logAtivo) console.log(id);
        const erroEncontrado = erros.find(erro => erro.id === id);

        if(logAtivo) console.log("erroEncontrado:");
        if(logAtivo) console.log(erroEncontrado);
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

    handleLogoutQuery = (dadosEvento) => {
        if(logAtivo) console.log(dadosEvento);
        //alert("pedido de logout ");
        logout();
        this.props.history.push('/');
        
    }

    render() {
        //para facilitar o acesso
        const { selecionados, serverError, tipoFiltro, valorFiltro, tipoOrdenacao, erros, paginaAtual,
              qtdItensSelecionados, idAmbiente, info} = this.state;

        return (
                        
            <div className="erro-list">
                <Header log={logAtivo} idUsuario={getIdUsuario()} msgUsuario="Bem vindo usuário. Seu token é: " 
                onLogoutQuery={this.handleLogoutQuery}/>

                {this.serverError !== "" && <p>{serverError}</p>}

                <div className="actions">
                    <button disabled={paginaAtual === 1} onClick={this.prevPage}>Anterior</button>
                    <div className="article">{paginaAtual}/{info.quantidadePaginas}</div>
                    <button disabled={paginaAtual === info.quantidadePaginas} onClick={this.nextPage}>Próxima</button>
                </div>

                <div className="options">

                    <DataCombo id="ambiente" nomeEndPoint="/environments" value={idAmbiente} onChange={this.handleDataComboAmbienteChanged} log={logAtivo} />
                    <DataCombo id="ordenacao" nomeEndPoint="" options={ordenacoes} value={tipoOrdenacao} onChange={this.handleDataComboChanged} />
                    <DataCombo id="tipo-filtro" nomeEndPoint="" options={tiposFiltro} value={tipoFiltro} onChange={this.handleDataComboChanged} />

                    <DataFilter id="filtro" disabled={tipoFiltro === "T"} 
                        value={valorFiltro} onChange={this.handleDataFilterChanged} />
                </div>


                <div className="actions">
                    <button disabled={qtdItensSelecionados !== 1} onClick={this.arquivarItem}>{this.calcTextArquivar()}</button>
                    <button disabled={qtdItensSelecionados === 0} onClick={this.apagarItem}>Apagar</button>
                </div>

                <Dados log={logAtivo} erros={erros} selecionados={selecionados} onChange={this.handleDataChanged} />

                <div className="msg-erro"> {serverError}</div>

            </div>

        )
    }
}
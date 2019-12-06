import React, { Component } from 'react';
import api from '../../services/api';
import Dados from '../../comps/dados';
import { Link } from 'react-router-dom';


import './styles.css';

export default class Main extends Component {

    state = {
        erros: [],
        info: {},
        paginaAtual: 1,

    };

    componentDidMount() {
        this.loadErros();
    }

    loadErros = async (paginaAtual = 1) => {
        console.log('antes de chamar cons para pag ' + paginaAtual);
        const response = await api.get(`/erros/pag=${paginaAtual}`);

        console.log('depois de chamar');

        console.log(response.data);
        const {erros, ...info} = response.data;
        console.log(erros);
        console.log(info);

        this.setState({ erros, info, paginaAtual});

        console.log(response.data.erros);
    };

    prevPage = () => {
        const {paginaAtual, info} = this.state;

        if(paginaAtual === 1) return;

        const pageNumber = paginaAtual - 1;

        this.loadErros(pageNumber);
    };

    nextPage = () => {
        const {paginaAtual, info} = this.state;

        if(paginaAtual === info.quantidadePaginas) return;

        const pageNumber = paginaAtual + 1;

        this.loadErros(pageNumber);
    };

    render() {
        //para facilitar o acesso
        const { erros, paginaAtual, info} = this.state;
        return (
            <div>

                <Dados erros={erros} />


            <div className="erro-list">


                <div className="actions">
                    <button disabled={paginaAtual === 1} onClick={this.prevPage}>Anterior</button>
                    <button disabled={paginaAtual === info.quantidadePaginas} onClick={this.nextPage}>Próxima</button>
                </div>
            </div>
            </div>
        )
    }
}
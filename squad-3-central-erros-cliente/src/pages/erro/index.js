import React, { Component } from 'react';
import api from '../../services/api';

import './styles.css';

export default class Erro extends Component {
    state = {
        erro: {},
    }

    async componentDidMount() {
        const { id } = this.props.match.params;
        console.log("vai ler o erro id " + id);
        const response = await api.get(`/erro/${id}`);

        console.log(response.data);

        this.setState({erro: response.data});
    }
    render() {
        const { erro } = this.state;


        return (
            <div className="erro-info">
                <a href="javascript: history.go(-1)">Voltar</a>
                <div id="erro-grande" >Erro no {erro.origem} em {erro.dataHora}</div>
                <table id="detalhe-erro">
                    <tr>
                        <td>
                            <div className="label-titulo">Título</div>
                        </td>
                        <td>
                            <div className="nivel-erro">{erro.idNivel} - nivel.nome</div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <div className="label-titulo">{erro.titulo}</div>
                        </td>
                        <td>
                            <div className="label-eventos">Eventos</div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                        </td>
                        <td>
                            <div className="valor-medio">{erro.eventos}</div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <div className="label-detalhe">Detalhes</div>
                        </td>
                        <td>
                            <div className="label-coletadopor">Coletado por</div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <div className="detalhes">{erro.detalhe}</div>
                        </td>
                        <td>
                            <div className="valor-medio">Token do usuário erro.usuario.nome</div>
                        </td>
                    </tr>
                </table>
            </div>
        )
    }
}
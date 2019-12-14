import React, { Component } from 'react';
import api from '../../services/api';

import './styles.css';
import { supportsCssVariables } from '@material/ripple/util';

export default class Erro extends Component {


    constructor(props)
    {
        super(props);

        console.log(props);

        this.state = {
            erro: {},
            id: this.props.match.params.id
        }

    }

    consDados = async (id) => {
        console.log("vai consultar ")
        try {
            //const response = await api.get(`/erro/${id}`);
            const response = await  api.get(`/errorOccurrences/${id}`);

            console.log(response);
            console.log(response.data);
    
            this.setState({erro: response.data});
    
        } catch (error) {
            console.log("Erro!!");
            console.log(error);
        }
        return {};

    };

    
    componentDidMount() {
        const { id } = this.props.match.params;
        console.log("vai ler o erro id " + id);
        console.log(this.consDados(id));
    }
    

    render() {
        console.log("***************** erro -> render()");

        const { erro } = this.state;
        console.log(erro);
        const { error } = this.state.erro;
        console.log(error);


        return (
            <div className="erro-info">
                <a href="javascript: history.go(-1)">Voltar</a>
                <div id="erro-grande" >Erro no {erro.origin} em {erro.datetime}</div>
                <table id="detalhe-erro">
                    <tr>
                        <td>
                            <div className="label-titulo">Título</div>
                        </td>
                        <td>
        <div className="nivel-erro">erro.error.level.id - erro.error.level.name</div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <div className="label-titulo">erro.error.title</div>
                        </td>
                        <td>
                            <div className="label-eventos">Eventos</div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                        </td>
                        <td>
                            <div className="valor-medio">{1}</div>
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
                            <div className="detalhes">{erro.details}</div>
                        </td>
                        <td>
                            <div className="valor-medio">Token do usuário erro.user.token</div>
                        </td>
                    </tr>
                </table>
            </div>
        )
    }
}
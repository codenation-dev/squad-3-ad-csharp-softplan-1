import React, { Component } from 'react';
import api from '../../services/api';

import './styles.css';

export default class Erro extends Component {
    state = {
        erro: {},
    }

    async componentDidMount() {
        const { id } = this.props.match.params;
        const response = await api.get(`/erros/${id}`);

        this.setState({erro: response.data});
    }
    render() {
        const { erro } = this.state;

        return (
            <div className="erro-info">
                <h1>{erro.title}</h1>
                <p>{erro.description}</p>

                <p>
                    URL: <a href={erro.url}>{erro.url}</a>
                </p>
            </div>
        )
    }
}
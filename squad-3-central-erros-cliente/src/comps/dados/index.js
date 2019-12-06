import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import './styles.css';


export default class Dados extends Component {

    constructor (props)
    {
        super(props);
        console.log(props);

        this.state = {
                erros: props.erros,
        };
    }

    atualizarSelecaoNovoItem = (id, selelcted) => {
        const {erros} = this.state;
        return erros.map(item => {
            if(item.id == id) {
                return {
                    ...item,
                    sel: selelcted
                };
            }
            else
            {
                return item;
            }
        });
    }

    handleChecked = event => {
        console.log("mudou id " + event.target.id);

        const novoArray = atualizarSelecaoNovoItem(event.target.id,
            event.target.value);

        this.setState({ erros: novoArray});

    };

    render() {
        const {erros} = this.props;

        return (
            <div className="dados-list">
                <table id="customers">
                    <th>check</th>
                    <th>Level</th>
                    <th>Log</th>
                    <th>Eventos</th>
                    <th>Detalhes</th>
                    {erros.map( erro => (
                        <tr>
                            <td><input
                                id={erro.id}
                                type="checkbox"
                                checked={erro.sel}
                                onChange={this.handleChecked} />
                         </td>
                            <td>{erro.nivel.nome}</td>
                            <td>
                                <p>{erro.titulo}</p>
                                <p>{erro.detalhe}</p>
                                <p>{erro.origem}</p>
                                <p>{erro.dataHora}</p>
                            </td>
                            <td>{erro.eventos}</td>
                            <td><Link id="linkDetalhes" to={`/erros/${erro.id}`}>...</Link></td>
                        </tr>
                    ))}
                </table>
            </div>
        )
    }

}


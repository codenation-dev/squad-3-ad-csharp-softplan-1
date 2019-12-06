import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import './styles.css';


export default class Dados extends Component {

    constructor (props)
    {
        super(props);
        console.log("--- ctor ---------");
        console.log(props);

        this.state = {
                erros: props.erros,
        };
    }

    handleChecked = event => {
        const {erros} = this.state;

        console.log("mudou id " + event.target.id);

        var i = 0;
        /*
        while(i < erros.length())
        {
            console.log("id " + erros[i].id);
            if(erros[i].id == event.target.id)
            {
                erros[i].sel = event.target.value;
            }
            i++;
        }
*/
        //console.log(erros.findIndex( item => item.id == event.target.id));

        this.setState({ erros});

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
                            <td><Link to={`/erros/${erro.id}`}>Acessar</Link></td>
                        </tr>
                    ))}
                </table>
            </div>
        )
    }

}


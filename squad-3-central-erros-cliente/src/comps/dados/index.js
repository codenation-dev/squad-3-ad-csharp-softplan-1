import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import ImagemArquivado from '../ImagemArquivado/index.js';

import './styles.css';


export default class Dados extends Component {

    constructor (props)
    {
        super(props);

        const {erros} = this.props;

        if(this.props.log) console.log("criando com props:");
        if(this.props.log) console.log(erros);

        this.state = {
                erros: [],
                selected: [],
        };

        erros.forEach((element, index, arr) => {
            this.state.selected.push(false);
        });

        


    }


    handleChecked = event => {

        if(event.target.id > 0)
        {
            this.props.onChange({id: event.target.id, type:"sel", value: event.target.checked});
        }
           };

    render() {
        const {erros} = this.props;

        return (
            <div className="dados-list">
                <table id="customers">
                    <thead> 
                    <tr> 
                    <th>
                        Sel.
                    </th>
                    <th>Level</th>
                    <th>Log</th>
                    <th>Eventos</th>
                    <th></th>
                    </tr>
                    </thead> 
                    <tbody>
                    {erros.map( erro => (
                        <tr>
                            <td><input
                                key={erro.id}
                                id={erro.id}
                                type="checkbox"
                                onChange={this.handleChecked} />
                            </td>
                            <td>
                                <ImagemArquivado  width="45" height="28" value={erro.error.SituationId === 2} />
                                <p>{erro.error.level.name}</p>
                            </td>
                            <td>
                                <p>{erro.error.title}</p>
                                <p>{erro.error.details}</p>
                                <p>{erro.error.origin}</p>
                                <p>{erro.error.datetime}</p>
                            </td>
                            <td>{erro.eventCount}</td>
                            <td><Link id="linkDetalhes" key={erro.id} to={`/erroroccurrences/${erro.id}`}>...</Link></td>
                        </tr>
                    ))}
                    </tbody>
                </table>
            </div>
        )
    }

}


import React, { Component } from 'react';
import api from '../../services/api';

import './styles.css';

export default class DataCombo extends Component {

    constructor (props)
    {
        super(props);

        if(this.props.log) console.log("Ccriando DataCombo com props:");
        if(this.props.log) console.log(this.props);

        this.state = {
                items: [],
                value: this.props.value,
        };
        if(this.props.nomeEndPoint === "")
        {
            if(this.props.log) console.log("recebendo opções por array");
            this.state.items = this.props.options;
        }


    }

    componentDidMount() {
        this.loadData();
     }
 
     loadData = async () => {
         const {nomeEndPoint} = this.props;

         if(this.props.nomeEndPoint === "")
         {
            if(this.props.log) console.log("não vai consultar pois não sua endPoint (" + this.props.id + ")");
            return;
         }

         if(this.props.log) console.log('antes de chamar cons para data combo ' + nomeEndPoint);
         const response = await api.get(nomeEndPoint);
 
         if(this.props.log) console.log('depois de chamar cons data combo ' + nomeEndPoint);
         if(this.props.log) console.log(response.data);

         this.setState({ items: response.data});

     };


handleChanged = event => {
        //const {items} = this.state;
        const newValue = event.target.value;

        if(this.props.log) console.log("mudou selecao " + newValue + "(" + this.props.id + ")");

        if(this.props.log) console.log("state.id: " + newValue);

        this.setState({ value: newValue});
        
        this.props.onChange({id: this.props.id, value: newValue});
    };


    render() {
        const {items} = this.state;
        if(this.props.log) console.log(`Data combo ${this.props.id} Renderezando com os items: `);
        if(this.props.log) console.log(items);
        return (
            <div>
                <select className="data-combo" onChange={this.handleChanged} value={this.state.value}>
                    {items.map( item => (
                        <option value={item.id}>{item.name}</option>
                    ))}
                </select>
            </div>
        )
    }

}


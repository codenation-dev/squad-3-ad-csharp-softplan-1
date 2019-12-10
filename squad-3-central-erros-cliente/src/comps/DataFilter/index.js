import React, { Component } from 'react';

import './styles.css';


export default class DataFilter extends Component {

    constructor (props)
    {
        super(props);

        if(this.props.log) console.log("criando DataFilter com props:");
        if(this.props.log) console.log(this.props);

        this.state = {
                value: this.props.value,
                disabled: this.props.disabled,
        };
    }

    hadleSubmit = event => {
        event.preventDefault()
        this.props.onChange({id: this.props.id, value: this.state.value})
    }    

    hadleTextChange = event => {
        event.preventDefault()
        this.setState({ value: event.target.value })
      } 
      
      
    render() {
        const {disabled} = this.props;
        if(this.props.log) console.log(`Data filter ${this.props.id} Renderezando`);
        return (
            <div>
                <form onSubmit={this.hadleSubmit} className="ui form">
                    <div className="data-filter">  
                        <input className="filter-edit" disabled={disabled} type="search" value={this.state.value} onChange={this.hadleTextChange}></input>
                        <button disabled={disabled} type="submit">OK</button>
                    </div>
                </form>
            </div>
        )
    }

}


import React from 'react'
import doc from './doc.png';
import arq from './arq.png';


export default class ImagemArquivado extends React.Component {

    render () {
        return (
            <div>
                <img src={arq} width={this.props.width} height={this.props.height} alt="Arquivado" hidden={!this.props.value} />
                <img src={doc} width={this.props.width} height={this.props.height} alt="Normal" hidden={this.props.value} />
            </div>
        );
    }
}
import React from 'react';
import api from '../../services/api';
import Banner from '../../comps/banner_user';


import './styles.css';


export default class Header extends React.Component {
      

      constructor (props)
      {
          super(props);
          console.log(props);
  
          this.state = {
            msgUsuario : props.msgUsuario,
            idUsuario: props.idUsuario,
            usuario: {id : -1, token : "???"}
          };
      }

      componentDidMount() {
           this.loadUser(this.state.idUsuario);
        }
    
        loadUser = async (id) => {
            console.log('antes de chamar cons para id ' + id);
            const response = await api.get(`/usuario/${id}`);
    
            console.log('depois de chamar cons usuario');
            console.log(response.data);
    
            this.setState({ usuario: response.data});
            console.log(this.state.usuario);
    
            
        };
    
      render () {
            const msg = this.state.usuario.id < 1 ? 
                  "Falta login" :
                  this.state.msgUsuario + this.state.usuario.token;
            return (
                  <div>
                        <header id="main-header">
                              AceleraDev - squad 3 - Central de erros
                        </header> 
                        
                        <Banner msgUsuario={msg} />
                  </div>  
            );
      }

}


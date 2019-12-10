import React from 'react';
import api from '../../services/api';
import Banner from '../../comps/banner_user';

import {isAutenticated, logout} from  '../../services/auth.js';

import './styles.css';


export default class Header extends React.Component {
      

      constructor (props)
      {
          super(props);
          if(this.props.log) console.log(props);
  
          this.state = {
            msgUsuario : props.msgUsuario,
            idUsuario: props.idUsuario,
            usuario: {id : -1, token : "???"}
          };
      }

      componentDidMount() {
            if(isAutenticated())
            {
                  this.loadUser(this.state.idUsuario);
            }
            else
            {
                  if(this.props.log) console.log("******** não está logado!");
                  this.setState({ usuario: {id: -1, token: ""}});
                  if(this.props.log) console.log(this.state.usuario);                  
            }
        }    

        loadUser = async (id) => {
            if(this.props.log) console.log('antes de chamar cons para id ' + id);
            const response = await api.get(`/usuario/${id}`);
    
            if(this.props.log) console.log('depois de chamar cons usuario');
            if(this.props.log) console.log(response.data);
    
            this.setState({ usuario: response.data});
            if(this.props.log) console.log(this.state.usuario);
    
            
        };

        handleLogout = () => {
            logout();  
        }
    
      render () {
            const msg = this.state.usuario.id < 1 ? 
                  "Falta login" :
                  this.state.msgUsuario + this.state.usuario.token;
            return (
                  <div>
                        <header id="main-header">
                              AceleraDev - squad 3 - Central de erros
                              <div hidden={!isAutenticated()}>
                                    <button onClick={this.handleLogout}>Logout</button>
                              </div>
                        </header> 
                        
                        
                        <Banner msgUsuario={msg} />
                  </div>  
            );
      }

}


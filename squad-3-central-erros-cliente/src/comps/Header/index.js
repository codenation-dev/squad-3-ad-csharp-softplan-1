import React from 'react';
import api from '../../services/api';
import Banner from '../../comps/banner_user';

import {isAutenticated} from  '../../services/auth.js';

import './styles.css';


export default class Header extends React.Component {
      

      constructor (props)
      {
          super(props);
          if(this.props.log) console.log(props);
  
          this.state = {
            msgUsuario : props.msgUsuario,
            idUsuario: props.idUsuario,
            autenticado: isAutenticated(),
            usuario: {id : -1, token : "???"}
          };
      }

      atualizarDadosSobreUsuario = () => {
            if(this.props.log) {
                  console.log("header: atualizarDadosSobreUsuario()");
                  console.log(this.state);

            }
            if(isAutenticated())
            {
                  if(this.props.log) { 
                        console.log("header: auth -> esta autenticado");
                        console.log(this.state.autenticado);
                  }

                  if(this.props.log) console.log("header: Carregando dados do usuário apra mostrar");
                  this.loadUser(this.props.idUsuario);
            }
            else
            {
                  if(this.props.log) console.log("header: ******** não está autenticado (auth)!");

                  this.setState({ usuario: {id: -1, token: "", autenticado: false}});
                  if(this.props.log) console.log(this.state.usuario);                  
            }
      }
      componentDidMount() {
            if(this.props.log) console.log("header: componentDidMount()");
            this.atualizarDadosSobreUsuario();
        }    

        loadUser = async (id) => {
            if(this.props.log) console.log('header: antes de chamar cons para id ' + id);
            //const response = await api.get(`/usuario/${id}`);
            const response = await api.get(`/users/${id}`);
    
            if(this.props.log) console.log('header: depois de chamar cons usuario');
            if(this.props.log) console.log(response.data);
    
            this.setState({ usuario: response.data, autenticado: true, idUsuario: id});
            if(this.props.log) console.log(this.state.usuario);
    
            
        };

        handleLogout = () => {
            this.props.onLogoutQuery({id: this.state.idUsuario, evento: "logout"});
              //this.props.onChange(
        }
        //onClick={this.handleLogout()}
      render () {
            if(this.props.log) {
                  console.log("header: render()");
                  console.log(this.state.autenticado);
            }
            const msg = this.state.autenticado === true ? 
            this.state.msgUsuario + this.state.usuario.token : "Falta login";
                  
            return (
                  <div>
                        <header id="main-header">
                              AceleraDev - squad 3 - Central de erros
                              <div hidden={this.state.autenticado !== true}>
                              <button onClick={this.handleLogout}> Logout</button>
                              </div>
                        </header> 
                        
                        
                        <Banner msgUsuario={msg} />
                  </div>  
            );
      }

}


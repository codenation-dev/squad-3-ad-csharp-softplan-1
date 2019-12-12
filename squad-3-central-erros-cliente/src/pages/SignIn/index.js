import React, { Component } from "react";
import { Link } from "react-router-dom";

import api from '../../services/api.js';
import {setIdUsuario, login} from  '../../services/auth.js';

import Logo from "./logosp1.png";


import './styles.css';

class SignUp extends Component {
  state = {
    email: "",
    password: "",
    error: ""
  };

  handleSignIn = async e => {
    e.preventDefault();
    const { email, password } = this.state;
    if (!email || !password) {
      this.setState({ error: "e-mail e password são obrigatórios" });
    } 
    else 
    {
      try {
        let response = await api.post("/auth", { login: email, password });
        console.log(response);
        //const {access_token, usuario} = response.data;
        const {access_token, user} = response.data;
        login(access_token);
        setIdUsuario(user.id);
        this.props.history.push("/app");
      } catch (err) {
        console.log(err);
        this.setState({ error: "Ocorreu um erro ao realizar login." });
      }
    }
  };

  render() {
    return (
      <div className="Container">
        <form onSubmit={this.handleSignIn}>
          <img src={Logo} alt="Logo Softplan" />
          {this.state.error && <p>{this.state.error}</p>}
          <input
            type="email"
            placeholder="e-mail"
            onChange={e => this.setState({ email: e.target.value })}
          />
          <input
            type="password"
            placeholder="password"
            onChange={e => this.setState({ password: e.target.value })}
          />
          <button type="submit">Login</button>
          <hr />
          <Link to="/signup">Não possuo cadastro</Link>
        </form>
      </div>
    );
  }
}

export default SignUp;
import React, { Component } from "react";
import { Link } from "react-router-dom";

import api from '../../services/api.js';
import Logo from "./logosp1.png";

import './styles.css';

class SignUp extends Component {
  state = {
    username: "",
    email: "",
    password: "",
    error: ""
  };

  handleSignUp = async e => {
    e.preventDefault();
    const { username, email, password } = this.state;
    if (!username || !email || !password) {
      this.setState({ error: "Nome, e-mail e password são obrigatórios" });
    } 
    else 
    {
      try {
        //await api.post("/usuario", { nome: username, email, senha: password });
        await api.post("/users", { name: username, email, password });
        this.props.history.push("/");
      } catch (err) {
        console.log(err);
        this.setState({ error: "Ocorreu um erro ao registrar sua conta." });
      }
    }
  };

  render() {
    return (
      <div className="Container">
        <form onSubmit={this.handleSignUp}>
          <img src={Logo} alt="Logo Softplan" />
          {this.state.error && <p>{this.state.error}</p>}
          <input
            type="text"
            placeholder="Nome"
            onChange={e => this.setState({ username: e.target.value })}
          />
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
          <button type="submit">Cadastrar</button>
          <hr />
          <Link to="/">Login</Link>
        </form>
      </div>
    );
  }
}

export default SignUp;
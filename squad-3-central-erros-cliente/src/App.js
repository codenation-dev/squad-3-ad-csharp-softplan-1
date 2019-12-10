import React from 'react';
import Routes from './routes';
import Header from './comps/Header';
import {getIdUsuario} from './services/auth.js';
import './styles.css';

const App = () => (
    <div className="App">
      <Header idUsuario={getIdUsuario()} msgUsuario="Bem vindo usuário. Seu token é: " />
      <Routes />
    </div>
  );

export default App;

import React from 'react';
import Routes from './routes';
import Header from './comps/Header';
import api from './services/api.js';
import Main from './pages/main';

import './styles.css';

const App = () => (
    <div className="App">
      <Header />
      <Routes />
    </div>
  );

export default App;

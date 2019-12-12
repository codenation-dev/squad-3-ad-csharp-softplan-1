import React from 'react'; 

import {BrowserRouter, Switch, Route, Redirect } from 'react-router-dom';

import Main from './pages/main';
import Erro from './pages/erro';
import SignUp from "./pages/SignUp";
import SignIn from "./pages/SignIn";
import { isAutenticated } from './services/auth';

//baseado em https://blog.rocketseat.com.br/reactjs-autenticacao/

const PrivateRoute = ({ component: Component, ...rest}) => (
    <Route
        {...rest}
        render = { props =>
            isAutenticated() ? (
                <Component {...props} />
            ) : (
                <Redirect to={{ pathname: "/", state: { from : props.location} }}  />
            
            )
        }
    />
)

const Routes = () => (
    <BrowserRouter>
        <Switch>
            <Route exact path="/" component={SignIn}  />
            <Route path="/signup" component={SignUp}  />
            <PrivateRoute path="/app" component={Main}  />
            <PrivateRoute path="/erroroccurrences/:id" component={Erro}  />
            <Route path="*" component={() => <h1>Página não encontrada</h1>}  />
        </Switch>
    </BrowserRouter>
);

export default Routes;
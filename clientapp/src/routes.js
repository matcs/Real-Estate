import React from 'react';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom';
import { RegisterImovel } from './components/RegisterImovel';
import { FormImovelCasa } from './components/FormImovelCasa'
import { FormImovelApartamento } from './components/FormImovelApart'
import { LoginForm } from './components/Login'
import { isAuthenticated } from './auth'

const PrivateRoute = ({component: Component, ...rest}) => (
    <Route
    {...rest}
    render={props =>
        isAuthenticated() ? (
            <Component {...props}/>
        ) : (
            <Redirect to={{ pathname:'/', state:{from:props.location} }}/>
        )
        }
    />
);

export default function Routes(){
    return (
        <BrowserRouter>
            <Switch>
                <Route path='/public' component={()=> <h1>Public</h1>}/>
                <PrivateRoute path='/app' component={()=><h1>Private</h1>}/>
                <Route exact path='/' component={LoginForm}/>
                <Route exact path='/register-imovel' component={RegisterImovel}/>
                <PrivateRoute exact path='/register-imovel-casa' component={FormImovelCasa} />
                <PrivateRoute exact path='/register-imovel-apartamento' component={FormImovelApartamento} />
            </Switch>
        </BrowserRouter>

    );
}

/*  
     */

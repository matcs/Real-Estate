import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import './style.css';
import { Card, CardTitle, Button, CardText } from 'reactstrap';

export class RegisterImovel extends Component {
    
    handleChange = input => e => {
        this.setState({ [input]: e.target.value });
    }

    lougout = () =>{
        localStorage.clear();
        return this.props.history.push('/');
    }

    render() {
       
        return (
            <dir>
                <Button type="button" onClick={this.lougout}>Logout</Button>
                <div className="cards-route" style={{ display: 'flex', flexDirection: 'row', margin: 200 + 'px' }}>
                    <Card body className="card-body" style={{ width: 55 + "vh", padding: 50 + "px", marginRight: 50 + 'px' }}>
                        <CardTitle>Cadastrar Casa</CardTitle>
                        <CardText>Cadastre seu casa para venda.</CardText>
                        <Button tag={Link} to="/register-imovel-casa">Cadastrar</Button>
                    </Card>

                    <Card body className="card-body" style={{ width: 55 + "vh", padding: 50 + "px" }}>
                        <CardTitle>Cadastrar Apartamento</CardTitle>
                        <CardText>Cadastre seu apartamento para venda.</CardText>
                        <Button tag={Link} to="/register-imovel-apartamento">Cadastrar</Button>
                    </Card>
                </div>
            </dir>
          );
        

    }
}
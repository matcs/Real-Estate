import React, { Component } from 'react';
import { isAuthenticated } from '../../auth';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import './style.css'
export class LoginForm extends Component {
    constructor (props) {
        super(props);
        this.state={
            email:'',
            senha:''
        }
    }

    handleChange = input => e => {
        this.setState({ [input]: e.target.value });
    }

    postLogin = ()=>{
        localStorage.setItem('email',this.state.email);
        localStorage.setItem('senha',this.state.senha);

        if(isAuthenticated){
            return this.props.history.push('/register-imovel');
        }
    }

    render(){
        const { email, senha } = this.state;

        const values = { email, senha };

        return (
            <div className='form-div'>
                <Form style={{textAlign:'center'}}>
                <FormGroup style={{fontSize: '32px'}}>
                    <Label for="exampleEmail" className="mr-sm-2">Email</Label>
                    <Input type="email" name="email" id="email" placeholder="something@idk.cool" 
                        style={{height:'60px', width:'50%', margin:'auto'}}
                        onChange={this.handleChange('email')}
                        defaultValue={values.email}
                    />
                </FormGroup>
                <FormGroup style={{fontSize: '32px'}}>
                    <Label for="examplePassword" className="mr-sm-2">Senha</Label>
                    <Input type="password" name="password" id="password"
                        style={{height:'60px', width:'50%', margin:'auto'}}
                        onChange={this.handleChange('senha')}
                        defaultValue={values.senha}
                    />
                </FormGroup>
                <Button onClick={this.postLogin} outline color ="success" size="lg">Login</Button>{' '}
                </Form>
            </div>
        );
    }

}

/**WebkitBoxShadow: 0px 0px 12px 2px rgba(112,112,112,1);
    MozBoxShadow: 0px 0px 12px 2px rgba(112,112,112,1); */
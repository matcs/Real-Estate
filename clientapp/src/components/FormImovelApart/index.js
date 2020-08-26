import React, { Component } from 'react';
import ApiService from '../../services/ApiService'
import { Form, FormGroup, Label, Input, Col, Row, Button } from 'reactstrap';
import { Link } from 'react-router-dom';

export class FormImovelApartamento extends Component {
    constructor(props) {
        super(props);
        this.state = {
            logradouro:'',
            rua: '',
            bairro: '',
            numero: '',
            municipio: '',
            estado: '',
            cep: '',
            metro_quadrado: 0,
            descricao: '',
            numero_quartos: 1,
            numero_banheiros: 1,
            nome_bloco:'',
            numero_bloco:0
        }
    }

    handleChange = input => e => {
        this.setState({ [input]: e.target.value });
    }


    render() {
        const { logradouro, rua, bairro, numero, estado, municipio, cep, metro_quadrado, descricao, numero_quartos, numero_banheiros, 
        nome_bloco, numero_bloco
        } = this.state;

        const values = {
            logradouro, rua, bairro, numero, estado, municipio, cep, metro_quadrado, descricao, numero_quartos, numero_banheiros,
        nome_bloco, numero_bloco
        };

        function postForm(){
            const endereco = {
                logradouro, rua, bairro, numero, municipio, estado, cep
            };
            ApiService.post('Enderecos',endereco)
                .then((data) =>{
                    const enderecoRefId = data.data.cod_endereco;
                    postImovel(enderecoRefId);
            })
        }

        function postImovel(enderecoRefId){
            const proprietario = localStorage.getItem('proprietario');
            console.log(proprietario);
            const proprietarioRefId = Number(proprietario);
            const imovel = {
                metro_quadrado, descricao, numero_quartos, numero_banheiros, proprietarioRefId, enderecoRefId
            }

            console.log(imovel);
            ApiService.post('Imoveis',imovel)
                .then((data) =>{
                    postApartamento(data.data.cod_imovel);
            })
        }

        function postApartamento(imovelRefId){
            const apartamento = {
                nome_bloco, numero_bloco        
            }

            console.log(apartamento);
            ApiService.post('Apartamentos',apartamento)
                .then((data) => {
                    console.log(data);
                    alert('Imovel cadastrado com sucesso!');
                });
        }

        return (
            <div>
                <Button tag={Link} to="/register-imovel">Voltar</Button>
                <h2>Sobre o endereço</h2>
                <Form>
                <Row form>
                    <Col md={3}>
                    <FormGroup>
                        <Label for="logradouro">Logradouro</Label>
                        <Input type="select" name="logradouro" id="logradouro"
                            onChange={this.handleChange('logradouro')}
                            defaultValue={values.logradouro}
                        >
                            <option value=''>...</option>
                            <option value='rua'>Rua</option>
                            <option value='avenida'>Avenida</option>
                            <option value='alameda'>Alameda</option>
                            <option value='conjunto'>Conjunto</option>
                            <option value='estrada'>Estrada</option>  
                        </Input>
                    </FormGroup>
                    </Col>
                    <Col md={5}>
                    <FormGroup>
                        <Label for="rua">Rua</Label>
                        <Input type="text" name="rua" id="rua" placeholder="Ex: Gonçalo de Carvalho"
                            onChange={this.handleChange('rua')}
                            defaultValue={values.rua}
                        />
                    </FormGroup>
                    </Col>
                    <Col md={2}>
                    <FormGroup>
                        <Label for="numero">Numero</Label>
                        <Input type="text" name="numero" id="numero" placeholder="Ex: 1234A"
                            onChange={this.handleChange('numero')}
                            defaultValue={values.numero}
                        />
                    </FormGroup>
                    </Col>
                </Row>
                <Row form>
                    <Col md={3}>
                    <FormGroup>
                        <Label for="municipio">Municipio</Label>
                        <Input type="text" name="municipio" id="municipio"
                            onChange={this.handleChange('municipio')}
                            defaultValue={values.municipio}
                        />
                    </FormGroup>
                    </Col>
                    <Col md={3}>
                    <FormGroup>
                        <Label for="bairro">Bairro</Label>
                        <Input type="text" name="bairro" id="bairro" placeholder="ex: Pirituba"
                            onChange={this.handleChange('bairro')}
                            defaultValue={values.bairro}
                        />
                    </FormGroup>  
                    </Col>
                    <Col md={3}>
                    <FormGroup>
                        <Label for="cep">CEP</Label>
                        <Input type="text" name="cep" id="CEP" placeholder="ex: xxxxx-xxx"
                            onChange={this.handleChange('cep')}
                            defaultValue={values.cep}
                        />
                    </FormGroup>  
                    </Col>
                    <Col md={2} >
                    <FormGroup>
                        <Label for="estado">Estado</Label>
                        <Input type="select" name="estado" id="estado" placeholder="escolha..."
                             onChange={this.handleChange('estado')}
                             defaultValue={values.estado}
                        >
                            <option value=''>...</option>
                            <option value='AC'>AC</option>
                            <option value='AL'>AL</option>
                            <option value='AP'>AP</option>
                            <option value='AM'>AM</option>
                            <option value='BA'>BA</option>
                            <option value='CE'>CE</option>             
                            <option value='ES'>ES</option>
                            <option value='GO'>GO</option>
                            <option value='MA'>MA</option>
                            <option value='MT'>MT</option>             
                            <option value='MS'>MS</option>
                            <option value='MG'>MG</option>
                            <option value='PA'>PA</option>
                            <option value='PB'>PB</option>             
                            <option value='PR'>PR</option>
                            <option value='PE'>PE</option>
                            <option value='PI'>PI</option>
                            <option value='RJ'>RJ</option>             
                            <option value='RN'>RN</option>
                            <option value='RS'>RS</option>
                            <option value='RO'>RO</option>
                            <option value='SC'>SC</option>             
                            <option value='SP'>SP</option>
                            <option value='SE'>SE</option>
                            <option value='TO'>TO</option>
                            <option value='DF'>DF</option>                            
                        </Input>
                    </FormGroup>
                    </Col>
                </Row>
                </Form>
                <br/>
                <h2>Sobre o imovel</h2>
                <Form>
                    <Row form>
                    <Col md={3}>
                    <FormGroup>
                        <Label for="metro_quadrado">Insira o tamanho em m<sup>2</sup></Label>
                        <Input type="number" name="metro_quadrado" id="metro_quadrado" placeholder="Metro quadrado" min="0"
                            onChange={this.handleChange('metro_quadrado')}
                            defaultValue={values.metro_quadrado}
                        />
                    </FormGroup>
                    </Col>
                    <Col md={3}>
                    <FormGroup>
                        <Label for="numero_quartos">Numero de quartos</Label>
                        <Input type="select" name="numero_quartos" id="numero_quartos"
                             onChange={this.handleChange('numero_quartos')}
                             defaultValue={values.numero_quartos}
                        >
                            <option value={1}>1</option>
                            <option value={2}>2</option>
                            <option value={3}>3</option>
                            <option value={4}>4</option>
                            <option value={5}>5+</option>
                        </Input>
                    </FormGroup>
                    </Col>
                    <Col md={3}>
                    <FormGroup>
                        <Label for="numero_banheiros">Numero de banheiros</Label>
                        <Input type="select" name="numero_banheiros" id="numero_banheiros"
                            onChange={this.handleChange('numero_banheiros')}
                            defaultValue={values.numero_banheiros}
                        >
                            <option value={1}>1</option>
                            <option value={2}>2</option>
                            <option value={3}>3</option>
                            <option value={4}>4</option>
                            <option value={5}>5+</option>
                        </Input>
                    </FormGroup>
                    </Col>
                    <Col md={2}>
                        <FormGroup>
                            <Label for="">Valor por m<sup>2</sup></Label>
                            <Input type="number" name="valor_por_m2" id="valor_por_m2" placeholder="Metro quadrado" min="0"/>
                        </FormGroup>
                    </Col>
                    </Row>
                    <Row form>
                    <Col md={2}>
                        <FormGroup>
                            <Label for="">Nome do bloco</Label>
                            <Input type="text" name="nome_bloco" id="nome_bloco" placeholder="nome do bloco"
                                onChange={this.handleChange('nome_bloco')}
                                defaultValue={values.nome_bloco}
                            />
                        </FormGroup>
                    </Col>
                    <Col md={2}>
                        <FormGroup>
                            <Label for="">Numero do bloco</Label>
                            <Input type="number" name="numero_bloco" id="numero_bloco" min="0"
                                onChange={this.handleChange('numero_bloco')}
                                defaultValue={values.numero_bloco}
                            />
                        </FormGroup>
                    </Col>
                    </Row>
                    
                    <br/>             
                    <FormGroup>
                        <Label for="descricao">Descrição</Label>
                        <Input type="textarea" name="descricao" id="descricao" className="formDescricao"
                            onChange={this.handleChange('descricao')}
                            defaultValue={values.descricao}
                        />
                    </FormGroup>
                </Form>
                <Button onClick={postForm}>Mostrar</Button>
            </div>
        );
    }
}
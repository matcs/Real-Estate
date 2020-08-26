import React, { Component } from 'react';
import ApiService from '../../services/ApiService'
import { Link } from 'react-router-dom';
import { Button, Form, Row, Col, FormGroup, Label, Input } from 'reactstrap';

export class FormImovelCasa extends Component {
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
            tipo: '',
            quintal: false,
            garagem: false,
            numero_de_vagas: 0,
            valor_por_m2: 0,
            redirect: false
        }
    }

    handleChange = input => e => {
        this.setState({ [input]: e.target.value });
    }

    setRedirect = () => {
        this.setState({
          redirect: true
        })
        console.log(this.state.redirect)
      }
    
      renderRedirect = () => {
        if (this.state.redirect) {
            console.log(this.state.redirect);

        }
      }

      
    render() {
        const { logradouro, rua, bairro, numero, estado, municipio, cep, metro_quadrado, descricao, numero_quartos, numero_banheiros,
            tipo, quintal, garagem, numero_de_vagas, valor_por_m2
        } = this.state;

        const values = {
            logradouro, rua, bairro, numero, estado, municipio, cep, metro_quadrado, descricao, numero_quartos, numero_banheiros,
            tipo, quintal, garagem, numero_de_vagas, valor_por_m2
        };

        function postForm(){
            const endereco = {
                logradouro, rua, bairro, numero, municipio, estado, cep
            };
            ApiService.post('Enderecos',endereco)
                .then((data) =>{
                    console.log(data);
                    postImovel(data.data.cod_endereco);
            })
            
        }

        function postImovel(enderecoRefId){
            const proprietario = localStorage.getItem('proprietario');
            console.log(proprietario);
            const proprietarioRefId = Number(proprietario);
            const _tipoImovel = 0;
            const imovel = {
                metro_quadrado, descricao, numero_quartos, numero_banheiros, _tipoImovel, proprietarioRefId, enderecoRefId
            }

            ApiService.post('Imoveis',imovel)
                .then((data) =>{
                    console.log(data);
                    postCasa(data.data.cod_imovel);
            })
        }

        function postCasa(imovelRefId){
            const casa = {
                tipo, quintal, garagem, numero_de_vagas, valor_por_m2, imovelRefId
            }
            ApiService.post('Casas',casa)
                .then((data) =>{
                    console.log(data);
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
                    </Row>
                    
                    <br/>
                    <Row form>
                    <Col md={3}>
                    <FormGroup>
                        <Label for="tipo">Tipo</Label>
                        <Input type="select" name="tipo" id="tipo"
                            onChange={this.handleChange('tipo')}
                            defaultValue={values.tipo}
                        >
                            <option value=''>...</option>
                            <option value='casa'>Casa</option>
                            <option value='condo'>Condo/Co-op</option>
                            <option value='townhome'>Townhome</option>
                            <option value='manufractured'>Manufractured</option>
                            <option value='multi-family'>Multi-family</option>
                        </Input>
                    </FormGroup>
                    </Col>
                    <Col md={3}>
                    <FormGroup>
                        <Label for="quintal">Quintal</Label>
                        <Input type="select" name="quintal" id="quintal"
                            onChange={this.handleChange('quintal')}
                            defaultValue={values.quintal}
                        >
                            <option value={null}>...</option>
                            <option value={false}>Não</option>
                            <option value={true}>Sim</option>
                        </Input>
                    </FormGroup>
                    </Col>
                    <Col md={3}>
                    <FormGroup>
                        <Label for="garagem">Garagem</Label>
                        <Input type="select" name="garagem" id="garagem"
                            onChange={this.handleChange('garagem')}
                            defaultValue={values.garagem}
                        >
                            <option value={null}>...</option>
                            <option value={false}>Não</option>
                            <option value={true}>Sim</option>                  
                        </Input>
                    </FormGroup>
                    </Col>
                    <Col md={2}>
                    <FormGroup>
                        <Label for="numero_vagas">Nº de vagas</Label>
                        <Input type="select" name="numero_vagas" id="numero_vagas"
                            onChange={this.handleChange('numero_vagas')}
                            defaultValue={values.numero_vagas}
                        >
                            <option value={0}>...</option>
                            <option value={1}>1</option>
                            <option value={2}>2</option>
                            <option value={3}>3</option>
                            <option value={4}>4</option>
                            <option value={5}>5+</option>
                        </Input>
                    </FormGroup>
                    </Col>
                    </Row>
                    <br/> 
                    <Row>
                        <Col md={2}>
                        <FormGroup>
                            <Label for="">Valor por metro quadrado</Label>
                            <Input type="number" name="valor_por_m2" id="valor_por_m2" placeholder="Metro quadrado" min="0"
                            onChange={this.handleChange('valor_por_m2')}
                            defaultValue={values.valor_por_m2}
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
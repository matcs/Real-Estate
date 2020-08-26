import ApiService from './services/ApiService';

export const isAuthenticated = () => {
    
    const email = localStorage.getItem('email');
    const senha = localStorage.getItem('senha');

    const proprietario = { email:email, senha:senha};

    let isAuthOK = true;
    console.log('post')
    ApiService.post('Proprietarios/Login',proprietario)
        .then((response)=>{
            console.log(response);
            localStorage.setItem('proprietario',response.data.cod_proprietario);
        })
        .catch((error)=>{
            if(error.response){
                console.log(error.response.data);
                console.log(error.response.status);
                console.log(error.response.headers);
            } else if(error.request){
                console.log(error.request);
            } else {
                console.log('Error', error.message);
            }           
        });

    return isAuthOK;
}


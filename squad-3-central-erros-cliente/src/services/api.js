import axios from 'axios';

const api = axios.create({ 
    //baseURL: 'https://rocketseat-node.herokuapp.com/api'
    baseURL: 'http://localhost:3000/'
    //tive que colcoar um proxi no arquivo package.json e deixei de chamar  https://localhost:5001/api
    //para chamar http://localhost:3000/
    //como sugerido em https://pt.stackoverflow.com/questions/349565/requisi%C3%A7%C3%A3o-com-axios-e-react-bloqueada-por-pol%C3%ADtica-cors
});

export default api;
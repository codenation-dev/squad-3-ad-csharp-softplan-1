export const TOKEN_LOGIN_CENTRAL_ERROS = "@centralerros-Token";
export  const TOKEN_LOGIN_ID_USUARIO = "@centralerros-IdUsuario";

export  const isAutenticated = () => localStorage.getItem(TOKEN_LOGIN_CENTRAL_ERROS) != null;
export  const getToken = () => localStorage.getItem(TOKEN_LOGIN_CENTRAL_ERROS);
export  const getIdUsuario = () => isAutenticated() ?localStorage.getItem(TOKEN_LOGIN_ID_USUARIO) : -1;
export  const setIdUsuario = id => localStorage.setItem(TOKEN_LOGIN_ID_USUARIO, id);
export  const login = token => {
    localStorage.setItem(TOKEN_LOGIN_CENTRAL_ERROS, token);
};

export  const logout = () => {
    localStorage.removeItem(TOKEN_LOGIN_ID_USUARIO);
    localStorage.removeItem(TOKEN_LOGIN_CENTRAL_ERROS);
}

//baseado em https://blog.rocketseat.com.br/reactjs-autenticacao/
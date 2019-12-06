import React from 'react';

import Banner from '../../comps/banner_user';


import './styles.css';


const Header = () => (
   <header id="main-header">
         AceleraDev - squad 3 - Central de erros
   </header> 
   <Banner text={props.msgUsuario} />
);

export default Header;
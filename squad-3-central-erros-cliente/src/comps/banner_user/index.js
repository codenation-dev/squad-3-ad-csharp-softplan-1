import React from 'react';
import './styles.css';


export default class Banner extends React.Component {

   

    constructor (props)
   {
       super(props);

       console.log("Banner props:");
       console.log(props);

       this.state = {
         msgUsuario : props.msgUsuario
       };
   }

   render () {
         return (
               <div id="banner"> {this.props.msgUsuario}
               </div>  
         );
   }

}


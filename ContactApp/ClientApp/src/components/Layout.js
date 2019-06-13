import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
//import 'primereact/resources/themes/nova-light/theme.css';
//import 'primereact/resources/primereact.min.css';
//import 'primeicons/primeicons.css';

import 'primereact/resources/primereact.css'
import 'primereact/resources/themes/nova-dark/theme.css'

export default props => (
  <div>
    <NavMenu />
    <Container>
      {props.children}
    </Container>
  </div>
);

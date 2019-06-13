import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import About from './components/About';
import ContactList from './components/ContactList';


export default () => (
    <Layout>
        <Route exact path='/home' component={Home} />
        <Route path='/contactList' component={ContactList} />
        <Route path='/about' component={About} />
      
     
  </Layout>
);

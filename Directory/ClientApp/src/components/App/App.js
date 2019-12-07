import React, { Component } from 'react';
import { Route } from 'react-router';
import Layout from '../Layout';
import Home from '../../routes/Home';
import FetchData from '../../routes/FetchData';
import Counter from '../../routes/Counter';

import './App.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
}

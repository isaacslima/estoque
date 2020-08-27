import React from 'react';
import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import ListProducts from './pages/ListProduct';
import AddEditProduct from './pages/AddEditProduct';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <p>
          Estoque
        </p>
      </header>
      <Router>
        <div>
          <Link to="/">Lista Produtos</Link>
          <hr />
          <Switch>
            <Route exact path="/">
              <ListProducts />
            </Route>
            <Route path="/AddEditProduct/:id">
              <AddEditProduct />
            </Route>
            <Route path="/AddEditProduct">
              <AddEditProduct />
            </Route>
          </Switch>
        </div>
      </Router>
    </div>
  );
}

export default App;

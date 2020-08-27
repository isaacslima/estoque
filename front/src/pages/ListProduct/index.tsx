import React, { useState, useEffect  } from 'react';
import { Link } from "react-router-dom";
import api from '../../services/api';

const ListProducts = () => {
  const [products, setProducts] = useState([]);
  const [message, setMessage] = useState("");

  useEffect(() => {
    retrieveProducts();
  }, []);

  const retrieveProducts = () => {
    api.get('product')
      .then(response => {
        setProducts(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  const removeProduct = (product, index) => {
    api.delete(`product/${product.id}`)
      .then(response => {
        setMessage("Produto removido com sucesso");
        retrieveProducts();
      })
      .catch(e => {
        console.log(e);
      });
  }

  return (
    <div>
      <button>
        <Link to="/AddEditProduct">Incluir Produto</Link>
      </button>
      <p>{message}</p>

      <table>
        <tr>
          <th>Id</th>
          <th>Nome</th>
          <th>Quantidade</th>
          <th>Valor</th>
          <th></th>
        </tr>
        {products &&
        products.map((product, index) => (
        <tr>
          <td>{product.id}</td>
          <td>{product.name}</td>
          <td>{product.quantity}</td>
          <td>{product.unitValue}</td>
          <td>
            <button>
              <Link to={"/AddEditProduct/" + product.id}> Editar </Link>
            </button>
            <button onClick={()=> removeProduct(product, index)}>Remover</button>
          </td>
        </tr>
        ))}
      </table>
    </div>
  );
};

export default ListProducts;
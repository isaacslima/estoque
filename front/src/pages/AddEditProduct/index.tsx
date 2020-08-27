import React, { useState, useEffect } from 'react';
import { useParams, Link, useHistory } from "react-router-dom";
import api from '../../services/api'

const AddEditProduct = props => {

  const { id } = useParams();

  const initialProductState = {
    id: 0,
    name: '',
    quantity: 0,
    unitValue: 0
  };
  const history = useHistory();

  const [currentProduct, setCurrentProduct] = useState(initialProductState);

  const getProduct = id => {
    api.get(`product/${id}`)
      .then(response => {
        setCurrentProduct(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };
  
  useEffect(() => {
    if(!id){
      setCurrentProduct(initialProductState)
      return;
    }
    getProduct(id);
  }, []);

  const handleInputChange = event => {
    const { name, value } = event.target;
    setCurrentProduct({ ...currentProduct, [name]: value });
  };

  const saveProduct = () => {
    let data = {
      id: currentProduct.id,
      name: currentProduct.name,
      quantity: parseInt(currentProduct.quantity),
      unitValue: parseFloat(currentProduct.unitValue)
    }
    if(!id) {
      api.post(`product`, data)
      .then(response => {
        alert("Produto inserido com sucesso");
        history.push('/');
      })
      .catch(e => {
        console.log(e);
      });
      return;
    }
    api.put(`product/${currentProduct.id}`, data)
      .then(response => {
        alert("Produto atualizado com sucesso");
        history.push('/');
      })
      .catch(e => {
        console.log(e);
      });
  };

  return (
    <div>
      {currentProduct ? (
      <div>
        <form>
          <div>
            <label htmlFor="name">Nome do Produto</label>
            <input type="text" id="name" name="name" value={currentProduct.name} onChange={handleInputChange} />
          </div>
          <div>
            <label htmlFor="quantity">Quantidade</label>
            <input type="number" id="quantity" name="quantity" value={currentProduct.quantity}
              onChange={handleInputChange} />
          </div>
          <div>
            <label htmlFor="unitValue">Valor</label>
            <input type="number" id="unitValue" name="unitValue" value={currentProduct.unitValue}
              onChange={handleInputChange} />
          </div>
        </form>
        <button>
          <Link to={"/"}>
          Voltar
          </Link>
        </button>
        <button type="submit" onClick={saveProduct}>
          Salvar
        </button>
      </div>
      ) : (
      <div>
        <br />
        <p>Nenhum Produto Selecionado </p>
      </div>
      )}
    </div>
  )
}

export default AddEditProduct;
import React from 'react';

const ProductCard = ({ Nombre, description, imageUrl}) => {
  return (
    <div style={styles.card}>
         <img src={imageUrl} alt={Nombre} style={styles.image} />
      <h3>{Nombre}</h3>
      <p>Tipo de Animal</p>
      <p>Edad</p>
      <p>Sexo</p>
      <p>Raza</p>
      <p>Tamaño</p>
      <p>{description}</p>
    </div>
  );
};

const styles = {
    image: {
        width: '100%',
        height: '150px', // Ajusta la altura de la imagen
        objectFit: 'cover', // Ajusta la imagen para que cubra el área sin distorsión
        borderRadius: '8px',
      },
  card: {
    backgroundColor: '#fff',
    border: '1px solid #ccc',
    borderRadius: '10px',
    padding: '1rem',
    margin: '1rem',
    maxWidth: '80%',
    textAlign: 'center',
    boxShadow: '1px 1px 10px #ccc',
    boxSizing: 'border-box',
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'center',
    height: '80%',
   },
  
};

export default ProductCard;

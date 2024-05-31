import React from 'react';

const WelcomeSection = () => {
  return (
    <div style={styles.welcomeSection}>
      <div style={styles.overlay}>
        <h2 style={styles.welcomeText}>¡El amor no se compra, se adopta!</h2>
        <p style={styles.description}>
          Encontra tu compañero ideal!
        </p>
      </div>
    </div>
  );
};
const styles = {
    welcomeSection: {
      position: 'relative',
      textAlign: 'center',
      padding: '2rem 0',
      backgroundImage: 'url("https://st4.depositphotos.com/1606449/20290/i/450/depositphotos_202902672-stock-photo-cute-dogs-cats-together-hanging.jpg")', // Reemplaza con la URL de tu imagen
      backgroundSize: 'cover',
      backgroundPosition: 'center',
      color: '#fff',
      display: 'flex',
      justifyContent: 'center',
      alignItems: 'center',
    },
    overlay: {
      position: 'relative',
      backgroundColor: 'rgba(0, 0, 0, 0.5)', // Fondo oscuro semitransparente
      padding: '2rem',
      width: '100%',
      maxWidth: '800px',
      borderRadius: '0.5rem',
    },
    welcomeText: {
      marginTop: '3rem',
      fontSize: '3rem',
      color: '#fff',
    },
    description: {
      fontSize: '2rem',
      color: '#fff',
      marginBottom: '3rem',
    },
  };
// const styles = {
//   welcomeSection: {
//     position: 'relative',
//     textAlign: 'center',
//     padding: '2rem 0',
//     backgroundImage: 'url("https://st4.depositphotos.com/1606449/20290/i/450/depositphotos_202902672-stock-photo-cute-dogs-cats-together-hanging.jpg")', 
//     backgroundSize: 'cover',
//     backgroundPosition: 'center',
//     color: '#fff',
//   },
//   overlay: {
//     position: 'relative',
//     backgroundColor: 'rgba(0, 0, 0, 0.5)', 
//     padding: '2rem',
//   },
//   welcomeText: {
//     marginTop: '1rem',
//     fontSize: '2rem',
//     color: '#fff',
//   },
//   description: {
//     fontSize: '1rem',
//     color: '#fff',
//   },
// };

export default WelcomeSection;


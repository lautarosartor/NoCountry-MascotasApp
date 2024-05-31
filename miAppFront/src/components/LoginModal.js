import React from 'react';

const LoginModal = ({ show, onClose }) => {
  if (!show) {
    return null;
  }

  return (
    <div style={styles.overlay}>
      <div style={styles.modal}>
        <h2>Iniciar Sesión</h2>
        <form>
          <div style={styles.formGroup}>
            <label htmlFor="username">Usuario </label>
            <input type="text" id="username" name="username" />
          </div>
          <div style={styles.formGroup}>
            <label htmlFor="password">Contraseña  </label>
            <input type="password" id="password" name="password" />
          </div>
          <button type="submit" style={styles.button}>Iniciar Sesión</button>
          <button type="button" style={styles.button} onClick={onClose}>Cerrar</button>
        </form>
      </div>
    </div>
  );
};

const styles = {
  overlay: {
    color: "black",
    position: 'fixed',
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    backgroundColor: 'rgba(0, 0, 0, 0.5)',
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
    zIndex: 1000,  
  },
  modal: {
    backgroundColor: 'white',
    padding: '2rem',
    borderRadius: '8px',
    width: '300px',
    maxWidth: '80%',
    zIndex: 1001,
  },
  formGroup: {
    marginBottom: '1rem',
    color: 'black',
  },
  button: {
    padding: '0.5rem 1rem',
    margin: '0.5rem 0.25rem',
    cursor: 'pointer',
    backgroundColor: 'black',
    border: '1px solid #ccc',
    borderRadius: '8px',
    color: '',
    fontWeight: 'bold',
  },
};

export default LoginModal;

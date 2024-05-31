import React from 'react';

const RegisterModal = ({ show, onClose }) => {
  if (!show) {
    return null;
  }

  return (
    <div style={styles.overlay}>
      <div style={styles.modal}>
        <h2>Registrarse</h2>
        <form>
          <div style={styles.formGroup}>
            <label htmlFor="firstName">Nombre </label>
            <input type="text" id="firstName" name="firstName" />
          </div>
          <div style={styles.formGroup}>
            <label htmlFor="lastName">Apellido </label>
            <input type="text" id="lastName" name="lastName" />
          </div>
          <div style={styles.formGroup}>
            <label htmlFor="email">Email </label>
            <input type="email" id="email" name="email" />
          </div>
          <div style={styles.formGroup}>
            <label htmlFor="description">Descripción </label>
            <textarea id="description" name="description" />
          </div>
          <div style={styles.formGroup}>
            <label htmlFor="role">Rol </label>
            <select id="role" name="role">
              <option value="user">Usuario </option>
              <option value="shelter">Refugio </option>
            </select>
          </div>
          <div style={styles.formGroup}>
            <label htmlFor="province">Provincia </label>
            <input type="text" id="province" name="province" />
          </div>
          <div style={styles.formGroup}>
            <label htmlFor="locality">Localidad </label>
            <input type="text" id="locality" name="locality" />
          </div>
          <button type="submit" style={styles.button}>Registrarse</button>
          <button type="button" style={styles.button} onClick={onClose}>Cerrar</button>
        </form>
      </div>
    </div>
  );
};

const styles = {
  overlay: {
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
    backgroundColor: 'black',
    padding: '2rem',
    borderRadius: '8px',
    width: '300px',
    maxWidth: '80%',
    zIndex: 1001,
  },
  formGroup: {
    marginBottom: '1rem',
  },
  button: {
    padding: '0.5rem 1rem',
    margin: '0.5rem 0.25rem',
    cursor: 'pointer',
  },
};

export default RegisterModal;

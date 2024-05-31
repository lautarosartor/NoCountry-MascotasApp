
import React, { useState } from 'react';
import LoginModal from './LoginModal';
import RegisterModal from './RegisterModal';

const Header = () => {
  const [showLoginModal, setShowLoginModal] = useState(false);
  const [showRegisterModal, setShowRegisterModal] = useState(false);

  const handleLoginClick = () => {
    setShowLoginModal(true);
  };

  const handleRegisterClick = () => {
    setShowRegisterModal(true);
  };

  const handleCloseLoginModal = () => {
    setShowLoginModal(false);
  };

  const handleCloseRegisterModal = () => {
    setShowRegisterModal(false);
  };

  return (
    <header style={styles.header}>
      <div style={styles.logo}>Animal heaven</div>
      <nav style={styles.nav}>
        <button style={styles.button} onClick={handleRegisterClick}>Registrarse</button>
        <button style={styles.button} onClick={handleLoginClick}>Iniciar sesión</button>
      </nav>
      <LoginModal show={showLoginModal} onClose={handleCloseLoginModal} />
      <RegisterModal show={showRegisterModal} onClose={handleCloseRegisterModal} />
    </header>
  );
};

const styles = {
  header: {
    display: 'flex',
    justifyContent: 'space-between',
    alignItems: 'center',
    padding: '1rem 2rem',
    backgroundColor: 'orange',
    color: 'white',
    flexWrap: 'wrap',
  },
  logo: {
    fontSize: '1.5rem',
    fontWeight: 'bold',
  },
  nav: {
    display: 'flex',
    flexWrap: 'wrap',
  },
  button: {
    marginLeft: '1rem',
    padding: '0.5rem 1rem',
    fontSize: '1rem',
    cursor: 'pointer',
    backgroundColor: 'transparent',
    border: '1px solid white',
    borderRadius: '4px',
    color: 'white',
    marginTop: '0.5rem',
  },
};

export default Header;


import { Typography } from '@mui/material';
import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useAuth } from '../../context/AuthContext';
import { Post } from '../../services/http';

const LoginComponent = () => {
  const navigate = useNavigate();
  const { login } = useAuth();  // Funcion de AuthContext.js
  
  const [error, setError] = useState('');
  const [loginForm, setLogin] = useState({
    email: '',
    password: ''
  });

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setLogin({
      ...loginForm,
      [name]: value,
    });
  };

  const handleLogin = async (event) => {
    event.preventDefault();
    setError('');

    try {
      const data = await Post('Account/login', loginForm);

      if (data && data.accessToken) {
        // Pasamos el token a la funcion login de AuthContext
        login(data.accessToken);

        // Redirigimos al home
        navigate("/", { replace: true });
      }
      else {
        setError("*Datos incorrectos*");
      }
    }
    catch (err) {
      setError(`${err}`);
      console.error('ERROR: ', err);
    }
  }

  return (
    <section id="login-section" className="auth-section d-flex justify-content-center align-items-center position-relative">
      {error &&
        <Typography color="error" className="alert alert-danger fw-bold position-absolute top-0 mt-5">
          {error}
        </Typography>
      }

      <form className="form d-flex flex-column gap-3 p-3 rounded" onSubmit={handleLogin}>
        <p className="title m-0 fw-bold">Inicia Sesión</p>

        <input placeholder="Email" type="email" name="email" value={loginForm.email} className="form-control py-3" onChange={handleInputChange} autoComplete="on"/>

        <input placeholder="Contraseña" type="password" name="password" value={loginForm.password} className="form-control py-3" onChange={handleInputChange} autoComplete="off"/>

        <button className="btn btn-primary" type="submit">
          Iniciar sesión
        </button>

        <small className="text-center text-white">
          ¿Aún no tienes cuenta? <Link to="/register" className="text-info">Registrate</Link>
        </small>
      </form>
    </section>
  );
};

export default LoginComponent;

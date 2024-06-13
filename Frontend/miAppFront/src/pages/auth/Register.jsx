import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useAuth } from '../../context/AuthContext';
import { Get, Post } from '../../services/http';
import './Auth.css';

const RegisterComponent = () => {
  const navigate = useNavigate();
  const { login } = useAuth();
  
  const [formData, setFormData] = useState({
    nombre: '',
    apellido: '',
    email: '',
    password: '',
    idRol: 0,
    idProvincia: 0,
    idLocalidad: 0,
  });
  const [error, setError] = useState('');

  const [provincias, setProvincias] = useState([]);
  const [localidades, setLocalidades] = useState([]);

  useEffect(() => {
    const getProvincias = async () => {
      const provincias = await Get('Provincias'); // Obtenemos las provincias de nuestra BD
      
      setProvincias(provincias);
    };
    
    getProvincias();
  }, []);

  // Consumimos la API del gobierno para consultar las distintas localidades de la provincia seleccionada
  const getLocalidades = async (nombreProvincia) => {
    const response = await fetch(`https://apis.datos.gob.ar/georef/api/localidades?provincia=${nombreProvincia}&aplanar=true&campos=estandar&max=1000&exacto=true&formato=json`);
    const data = await response.json();

    setLocalidades(data.localidades);
  }

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData({
      ...formData,
      [name]: value,
    });

    if (name === 'nombreProvincia') {
      getLocalidades(value);
    }
  };

  const handleRegister = async (e) => {
    e.preventDefault();
    setError('');

    if (formData.password !== formData.confirmPassword) {
      setError('Las contraseñas no coinciden');
      return;
    }

    try {
      const data = await Post('Account/register', formData);

      if (data && data.accessToken) {
        login(data.accessToken);

        navigate("/", { replace: true });
      }
    }
    catch (error) {
      setError('Error al registrar');
      console.error('ERROR:', error);
    }
  };

  return (
    <section id="register-section" className="d-flex justify-content-center align-items-center position-relative">
      <form className="form d-flex flex-column gap-3 p-3 rounded" onSubmit={handleRegister}>
        <p className="title fw-bold m-0">Registrarse</p>
        <>
          {error ? (
            <small className="text-center text-danger fw-bold">{error}</small>
          ) : (
            <small className="text-light">Regístrate ahora y obtén acceso completo a nuestra aplicación.</small>
          )}
        </>

        <select className="rounded border border-primary p-2" name="idRol" onChange={handleChange}>
          <option defaultChecked hidden>Seleccionar Rol</option>
          <option disabled value={1}>Administrador</option>
          <option value={2}>Refugio</option>
          <option value={3}>Cliente</option>
        </select>
        
        <div className="d-flex gap-3">
          <label htmlFor="nombre">
            <input id="nombre" required type="text" className="input" name="nombre" onChange={handleChange} autoComplete="on"/>
            <span>Nombre</span>
          </label>
    
          <label htmlFor="apellido">
            <input id="apellido" required type="text" className="input" name="apellido" onChange={handleChange} autoComplete="on"/>
            <span>Apellido</span>
          </label>
        </div>

        <label htmlFor="email">
          <input id="email" required type="email" className="input" name="email" onChange={handleChange} autoComplete="on"/>
          <span>Email</span>
        </label>

        <label htmlFor="password">
          <input id="password" required type="password" className="input" name="password" onChange={handleChange} autoComplete="off"/>
          <span>Contraseña</span>
        </label>
        
        <label htmlFor="confirmPassword">
          <input id="confirmPassword" required type="password" className="input" name="confirmPassword" onChange={handleChange} autoComplete="off"/>
          <span>Confirmar contraseña</span>
        </label>
          
        <label htmlFor="provincia">
          <select id="provincia" placeholder="Seleccionar provincia" required className="input" name="nombreProvincia" onChange={handleChange}>
            <option defaultChecked hidden></option>
            {
              provincias.map(provincia => (
                <option key={provincia.id} value={provincia.nombre}>
                  {provincia.nombre}
                </option>
              ))
            }
          </select>
          <span>Provincia</span>
        </label>

        <label htmlFor="localidad">
          <select id="localidad" placeholder="Seleccionar localidad" required className="input" name="nombreLocalidad" onChange={handleChange}>
            <option defaultChecked hidden></option>
            {
              localidades && localidades.length > 0 ? (
                localidades.map(localidad => (
                  <option key={localidad.id} value={localidad.nombre}>
                    {localidad.nombre}
                  </option>
                ))
              ) : (
                <option disabled className="text-dark">
                  Seleccione una provincia primero
                </option>
              )
            }
          </select>
          <span>Localidad</span>
        </label>
        
        <div className="mt-3 d-flex justify-content-between">
          <button className="btn btn-primary" type="submit">
            Registrarse
          </button>
          <Link className="btn bg-dark text-light" to="/">
            Volver
          </Link>
        </div>

        <small className="text-center text-light">
          ¿Ya tienes cuenta? <Link to="/login" className="text-info">Iniciar sesión</Link>
        </small>
      </form>
    </section>
  );
};

export default RegisterComponent;
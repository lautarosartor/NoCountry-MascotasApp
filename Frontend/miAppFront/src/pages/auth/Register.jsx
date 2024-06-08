import { Typography } from '@mui/material';
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

  //const [roles, setRoles] = useState([]);
  const [provincias, setProvincias] = useState([]); // State for provinces data
  const [localidades, setLocalidades] = useState([]); // State for localities data

  // Fetch roles, provinces, localidades on component mount (or when needed)
  useEffect(() => {
    /* const getProvincias = async () => {
      const provincias = await Get('Provincias'); // Replace with your API endpoint
      
      console.log(provincias);
      setProvincias(provincias);
    }; */

    const getProvincias = async () => {
      const response = await fetch("https://apis.datos.gob.ar/georef/api/provincias?aplanar=true&campos=estandar&exacto=true&formato=json");
      const data = await response.json();
      console.log(data.provincias);
      setProvincias(data.provincias);
    }

    /* const getLocalidades = async () => {
      const localidades = await Get('Localidades'); // Replace with your API endpoint
      
      //console.log(localidades);
      setLocalidades(localidades);
    };
 */
    getProvincias();
    //getLocalidades();
  }, []);

  const getLocalidades = async (idProvincia) => {
    const response = await fetch(`https://apis.datos.gob.ar/georef/api/localidades?provincia=${idProvincia}&aplanar=true&campos=estandar&max=1000&exacto=true&formato=json`);
    const data = await response.json();
    console.log(data.localidades);
    setLocalidades(data.localidades);
  }

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData({
      ...formData,
      [name]: value,
    });

    if (name === 'idProvincia') {
      getLocalidades(value);
    }
  };

  const handleRegister = async (e) => {
    e.preventDefault();
    setError('');

    /* if (formData.password !== formData.confirmPassword) {
      setError('Las contraseñas no coinciden');
      return;
    } */

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
    <section id="register-section" className="d-flex justify-content-center align-items-center">
      <form className="form d-flex flex-column gap-3 p-3 rounded" onSubmit={handleRegister}>
        <p className="title fw-bold m-0">Registrarse</p>
        <small className="text-light">
          Regístrate ahora y obtén acceso completo a nuestra aplicación.
        </small>

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
        
        {/* <label htmlFor="confirmPassword">
          <input required type="password" className="input" name="confirmPassword" onChange={handleChange}/>
          <span>Confirmar contraseña</span>
        </label> */}
          
        <label htmlFor="provincia">
          <select id="provincia" placeholder="Seleccionar provincia" required className="input" name="idProvincia" onChange={handleChange}>
            <option defaultChecked hidden></option>
            {/* {
              provincias && provincias.length > 0 ? (
                provincias.map(provincia => (
                  <option key={provincia.id} value={provincia.id}>
                    {provincia.nombre}
                  </option>
                ))
              ) : (
                <option className="text-warning">
                  Error al cargar.
                </option>
              )
            } */}
            {
              provincias.map(provincia => (
                <option key={provincia.id} value={provincia.id}>
                  {provincia.nombre}
                </option>
              ))
            }
          </select>
          <span>Provincia</span>
        </label>

        <label htmlFor="localidad">
          <select id="localidad" placeholder="Seleccionar localidad" required className="input" name="idLocalidad" onChange={handleChange}>
            <option defaultChecked hidden></option>
            {
              localidades && localidades.length > 0 ? (
                localidades.map(localidad => (
                  <option key={localidad.id} value={localidad.id}>
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
        
        {error &&
          <Typography color="error" className="alert alert-danger fw-bold position-absolute top-0 mt-5">
            {error}
          </Typography>
        }
        
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
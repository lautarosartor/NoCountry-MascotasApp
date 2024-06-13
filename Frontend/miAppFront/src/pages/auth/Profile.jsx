import React, { useState, useEffect } from 'react';
import { Box, TextField, MenuItem, Button, Dialog, DialogTitle, DialogContent, DialogActions } from '@mui/material';
import { Link } from 'react-router-dom';
import { Get, Put } from '../../services/http';

export const ProfileComponent = ({ email }) => {
  const [usuario, setUsuario] = useState({
    nombre: '',
    apellido: '',
    provincia: '',
    localidad: '',
    direccion: '',
    descripcion: '',
  });
  const [provincias, setProvincias] = useState([]);
  const [localidades, setLocalidades] = useState([]);
  const [editable, setEditable] = useState(false);
  const [confirmOpen, setConfirmOpen] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {
    const getProvincias = async () => {
      try {
        const provinciasData = await Get('Provincias');
        setProvincias(provinciasData);
      }
      catch (error) {
        console.log('ERROR: ', error);
      }
    };

    const getUsuario = async (email) => {
      try {
        const usuarioData = await Get(`Usuarios/${email}`);
        setUsuario(usuarioData);

        if (usuarioData.provincia) {
          getLocalidades(usuarioData.provincia);
        }
      }
      catch (error) {
        console.log('ERROR: ', error);
      }
    };
    
    getUsuario(email);
    getProvincias();
  }, [email, editable]);

  const getLocalidades = async (nombreProvincia) => {
    try {
      const response = await fetch(`https://apis.datos.gob.ar/georef/api/localidades?provincia=${nombreProvincia}&aplanar=true&campos=estandar&max=1000&exacto=true&formato=json`);
      const data = await response.json();
      setLocalidades(data.localidades);
    } catch (error) {
      console.log('ERROR: ', error);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUsuario((prevState) => ({
      ...prevState,
      [name]: value,
    }));

    if (name === 'provincia') {
      getLocalidades(value);
    }
  };

  const handleEdit = (e) => {
    e.preventDefault();
    setEditable(true);
  };

  return (
    <section id="profile-section" className="d-flex justify-content-center align-items-center position-relative">
      <form className="form d-flex flex-column gap-3 p-3 rounded">
        <p className="title fw-bold m-0">
          Información personal
        </p>

        <div className="d-flex gap-3">
          <label htmlFor="nombre">
            <input id="nombre" required type="text" className="input" name="nombre" value={usuario.nombre} onChange={handleChange} autoComplete="on" disabled={!editable} />
            <span>Nombre</span>
          </label>

          <label htmlFor="apellido">
            <input id="apellido" required type="text" className="input" name="apellido" value={usuario.apellido} onChange={handleChange} autoComplete="on" disabled={!editable} />
            <span>Apellido</span>
          </label>
        </div>

        <label htmlFor="provincia">
          <span>Provincia</span>

          <select id="provincia" placeholder="Seleccionar provincia" required className="input" name="provincia" onChange={handleChange} disabled={!editable}>
            <option defaultChecked value={usuario.provincia} hidden>{usuario.provincia}</option>
            {provincias.map(provincia => (
              <option key={provincia.id} value={provincia.nombre}>{provincia.nombre}</option>
            ))}
          </select>
        </label>

        <label htmlFor="localidad">
          <span>Localidad</span>
          <select id="localidad" placeholder="Seleccionar localidad" required className="input" name="localidad" onChange={handleChange} disabled={!editable}>
            <option defaultChecked hidden>{usuario.localidad}</option>
            {localidades.map(localidad => (
              <option key={localidad.id} value={localidad.nombre}>{localidad.nombre}</option>
            ))}
          </select>
        </label>

        <label htmlFor="direccion">
          <input id="direccion" className="input" name="direccion" onChange={handleChange} value={usuario.direccion} style={{ resize: 'none' }} disabled={!editable} />
          <span>Dirección</span>
        </label>

        <label htmlFor="descripcion">
          <span>Descripción</span>
          <textarea id="descripcion" className="input p-2" name="descripcion" onChange={handleChange} value={usuario.descripcion} style={{ resize: 'none' }} disabled={!editable} />
        </label>

        {error && <small className="text-center text-danger fw-bold">{error}</small>}

        <div className="mt-3 d-flex justify-content-between">
          {editable ? (
            <Button variant="contained" color="primary">
              Guardar
            </Button>
          ) : (
            <Button disabled variant="outlined" color="primary" onClick={handleEdit}>
              Editar
            </Button>
          )}

          <Link className="btn bg-dark text-light" to="/dashboard">
            Volver
          </Link>
        </div>
      </form>
    </section>
  );
};

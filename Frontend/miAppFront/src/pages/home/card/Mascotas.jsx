import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import { Button, CardActionArea, CardActions } from '@mui/material';

import Sidebar from '../../../components/sidebar/Sidebar';
import React, { useEffect, useState } from 'react';
import { Get } from '../../../services/http';
import { Link } from 'react-router-dom';
import MascotaModal from './MascotaModal';
import { BtnAdoptar } from '../../../components/BtnAdoptar';

const MascotasComponent = () => {
  const [mascotas, setMascotas] = useState([]);

  const fetchMascotas = async () => {
    try {
      const mascotas = await Get('Mascotas');
      
      setMascotas(mascotas);
    }
    catch (error) {
      console.error('ERROR: ', error);
    }
  };

  // Consumir endpoint GET (en este caso para obtener TODO)
  useEffect(() => {
    
    fetchMascotas();
  }, []); // Al estar vacio el useEffect se ejecutara una vez cuando el componente se monte en el DOM
  
  // Seteamos el modal y le pasamos el id de la mascota seleccionada
  const [open, setOpen] = useState(false);
  const [selectedMascota, setSelectedMascota] = useState(null);

  const handleOpenModal = (id) => {
    setSelectedMascota(id);
    setOpen(true);
  }

  const handleCloseModal = () => {
    setOpen(false);
    setSelectedMascota(null);
  }

  return (
    <section className="container d-flex flex-wrap justify-content-center gap-5">
      {/* <Sidebar/> */}

      {mascotas && mascotas.length > 0 ? (
        mascotas.map(mascota => (
          <Card key={mascota.id} sx={{ maxWidth: 300 }} elevation={6}
              style={mascota.estado !== 'Disponible' ? { opacity: 0.5 } : {}}>
            <CardActionArea onClick={() => handleOpenModal(mascota.id)} className="position-relative">
              <div className="position-absolute top-0 end-0 px-2 rounded" style={{backgroundColor: '#a3a3a390'}}>
              {
                mascota.estado === 'Disponible' ? (
                  <p className="text-success fw-bold m-0">{mascota.estado}</p>
                ):(
                  mascota.estado === 'Solicitada' ? (
                    <p className="text-warning fw-bold m-0">{mascota.estado}</p>
                  ):(
                    <p className="text-danger fw-bold m-0">{mascota.estado}</p>
                  )
                )
              }
              </div>
              <CardMedia
                component="img"
                height="250"
                image = {mascota.urlImagen}
                alt = {mascota.nombre}/>
            </CardActionArea>

            <CardContent>
              <p className="fs-3 m-0 fw-bold">
                {mascota.nombre}
              </p>
              <p className="m-0">
                {mascota.descripcion}
              </p>
            </CardContent>

            <CardActions className="d-flex justify-content-between px-3 pb-3">
              <Button size="small" variant="contained" color="primary" onClick={() => handleOpenModal(mascota.id)}>
                <Link className="text-white text-decoration-none">Detalles</Link>
              </Button>
              
              {/* Boton personalizado */}
              <BtnAdoptar estado={mascota.estado} id={mascota.id} fetchMascotas={fetchMascotas}/>
              
            </CardActions>
          </Card>
        ))
      ) : (
        <p className="alert alert-warning text-center">No hay publicaciones para mostrar</p>
      )}

      {/*MOSTRAR MODAL*/}
      {open &&
        <MascotaModal open={open} onClose={handleCloseModal} idMascota={selectedMascota} />
      }
    </section>
  );
};

export default MascotasComponent;
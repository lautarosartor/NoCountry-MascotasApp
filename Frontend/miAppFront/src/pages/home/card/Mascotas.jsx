import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import { Button, CardActionArea, CardActions } from '@mui/material';

import Sidebar from '../../../components/sidebar/Sidebar';
import React, { useEffect, useState } from 'react';
import { Get } from '../../../services/http';
import { Link } from 'react-router-dom';
import MascotaModal from './MascotaModal';

const MascotasComponent = () => {
  const [mascotas, setMascotas] = useState([]);

  // Consumir endpoint GET (en este caso para obtener TODO)
  useEffect(() => {
    const fetchMascotas = async () => {
      try {
        const mascotas = await Get('Mascotas');
        
        setMascotas(mascotas);
      }
      catch (error) {
        console.error('ERROR: ', error);
      }
    };

    fetchMascotas();
  }, []);
  
  // Consumir endpoint GET (en este caso para obtener UNO)
  const [open, setOpen] = useState(false);
  const [selectedMascota, setSelectedMascota] = useState(null);

  const handleOpenModal = async (id) => {
    try {
      const mascota = await Get(`Mascotas/${id}`)
      
      setSelectedMascota(mascota);

      setOpen(true);
    }
    catch (error) {
      console.error('ERROR: ', error);
    }
  };

  const handleCloseModal = () => {
    setOpen(false);
    setSelectedMascota(null);
  }

  return (
    <section className="container d-flex flex-wrap justify-content-center gap-5">
      {/* <Sidebar/> */}

      {mascotas && mascotas.length > 0 ? (
        mascotas.map(mascota => (
          <Card key={mascota.id} sx={{ maxWidth: 300 }} elevation={6}>
            <CardActionArea onClick={() => handleOpenModal(mascota.id)}>
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
              
              <Button size="small" variant="contained" color="secondary">
                <Link className="text-white text-decoration-none" to={`/mascota/${mascota.id}`}>Adoptar</Link>
              </Button>
            </CardActions>
          </Card>
        ))
      ) : (
        <p className="alert alert-warning text-center">No hay publicaciones para mostrar</p>
      )}

      {/*MOSTRAR MODAL*/}
      <MascotaModal open={open} onClose={handleCloseModal} mascota={selectedMascota} />
    </section>
  );
};

export default MascotasComponent;
import { Box, Button, Modal, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { BtnAdoptar } from "../../../components/BtnAdoptar";
import { Get } from "../../../services/http";

const MascotaModal = ({ open, onClose, idMascota}) => {
  const [mascota, setMascota] = useState(null);

  // Consumir endpoint GET (en este caso para obtener UNO)
  useEffect(() => {
    if (open && idMascota) {
      const getMascota = async (idMascota) => {
        try {
          const mascota = await Get(`Mascotas/${idMascota}`);
          
          setMascota(mascota);
        }
        catch (error) {
          console.error('ERROR: ', error);
        }
      }
      
      getMascota(idMascota);
    }
  }, [open, idMascota]);  //Esto es lo que se tiene que cumplir para que funcione useEffect

  if (!mascota) return null;
  
  return (
    <Modal open={open} onClose={onClose}>
      <Box sx={{ 
          position: 'absolute', 
          top: '50%', 
          left: '50%', 
          transform: 'translate(-50%, -50%)', 
          maxWidth: '700px',
          width: '80%', 
          bgcolor: 'background.paper', 
          boxShadow: 24,
          borderRadius: '5px',
          p: 2,
        }}>

        <Typography variant="h5" mb={2}>
          {mascota.nombre} | {mascota.años} {mascota.años > 1 ? " años" : " año"} + {mascota.meses} {mascota.meses > 1 ? " meses" : "mes"}
        </Typography>
        
        <img className="img-fluid" src={mascota.urlImagen} alt={mascota.nombre} style={{ width: '100%', maxHeight: '60vh', objectFit: 'cover'}} />
        
        <div className="my-2">
          <Typography className="fw-bold" variant="body1">
            {mascota.especie} - {mascota.raza} | Refugio: {mascota.nombreUsuario}
          </Typography>
          <Typography variant="body1">
            {mascota.descripcion}
          </Typography>
        </div>

        {mascota.estado === 'Disponible' ? (
          <p className="text-success fw-bold">{mascota.estado}</p>
        ):(
          mascota.estado === 'Solicitada' ? (
            <p className="text-warning fw-bold">{mascota.estado}</p>
          ):(
            <p className="text-danger fw-bold">{mascota.estado}</p>
          )
        )}

        <div className="d-flex justify-content-between">
          <Button variant="contained" color="primary" onClick={onClose}>
            Cerrar
          </Button>

          {/* Boton personalizado */}
          <BtnAdoptar estado={mascota.estado} id={mascota.id}/>
        </div>
      </Box>
    </Modal>
  );
}
export default MascotaModal
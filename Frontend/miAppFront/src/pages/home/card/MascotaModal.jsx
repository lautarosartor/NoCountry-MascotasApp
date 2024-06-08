import { Box, Button, Modal, Typography } from "@mui/material";
import { Link } from "react-router-dom";

const MascotaModal = ({ open, onClose, mascota}) => {
  
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
        
        <img src={mascota.urlImagen} alt={mascota.nombre} style={{ width: '100%', marginBottom: '16px' }} />
        
        <Typography variant="body1" mb={2}>
          {mascota.especie} - {mascota.raza} | Refugio: {mascota.nombreUsuario}
          <br/>
          {mascota.descripcion}
        </Typography>

        <p className="text-success fw-bold">{mascota.estado}</p>

        <div className="d-flex justify-content-between">
          <Button variant="contained" color="primary" onClick={onClose}>
            Cerrar
          </Button>

          <Button variant="contained" color="secondary">
            <Link className="text-white text-decoration-none" to={`/mascota/${mascota.id}`}>Adoptar</Link>
          </Button>
        </div>
      </Box>
    </Modal>
  );
}
export default MascotaModal
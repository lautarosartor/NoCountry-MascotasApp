import { IconButton, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Tooltip, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { Delete, Get, Put } from "../../services/http";
import { useAuth } from '../../context/AuthContext';
import MascotaModal from "../home/card/MascotaModal";
import DeleteIcon from '@mui/icons-material/Delete';
import SettingsIcon from '@mui/icons-material/Settings';
import CheckCircleIcon from '@mui/icons-material/CheckCircle';
import CancelIcon from '@mui/icons-material/Cancel';
import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline';
import EditIcon from '@mui/icons-material/Edit';
import MascotaFormModal from "./MascotaForm";

const RefugioComponent = () => {
  const { currentUser } = useAuth();
  const [mascotas, setMascotas] = useState([]);

  const [open, setOpen] = useState(false);
  const [modal, setModal] = useState(""); // Para controlar que modal abrir
  const [selectedMascota, setSelectedMascota] = useState(null);

  const handleOpenModal = (id, action) => {
    setSelectedMascota(id);
    setModal(action);
    setOpen(true);
  }

  const handleCloseModal = () => {
    setSelectedMascota(null);
    setModal("");
    setOpen(false);
  }

  const confirmarSolicitud = async (id, estado) => {
    try {
      const solicitudData = await Get(`Solicitud?idMascota=${id}&estado=Pendiente`);
      console.log(solicitudData);
      const primerElemento = solicitudData[0];

      const accion = estado === "Aprobada" ? "aprobar" : "rechazar";

      const confirmacion = window.confirm(`¿Estás seguro que deseas ${accion} esta solicitud?`);

      if (confirmacion && estado === 'Aprobada') {
        await Put(`Solicitud/${primerElemento.id}`, {'estado': estado})
          .then(() => getMascotas());
      }
      if (confirmacion && estado === 'Rechazada'){
        await Put(`Solicitud/${primerElemento.id}`, {'estado': estado})
          .then(() => getMascotas());
      }
    }
    catch (error) {
      console.log('ERROR: ', error);
    }
  }

  const deleteMascota = async (id) => {
    try {
      const confirmacion = window.confirm("¿Estás seguro que deseas eliminar esta publicación?");      
    
      if (confirmacion) {
        await Delete(`Mascotas/${id}`)
          .then(() => getMascotas());
      }
    }
    catch (error) {
      console.log('ERROR: ', error);
    }
  }

  const getMascotas = async () => {
    try {
      const mascotas = await Get(`Mascotas?email=${currentUser.email}`);

      setMascotas(mascotas);
      console.log(mascotas);
    }
    catch (error) {
      console.log('ERROR: ', error);
    }
  }

  useEffect(() => {
    // Obtener registros
    getMascotas();
  }, []);

  return (
    <section className="container">
      <Typography className="text-center mb-3 fs-2 fw-bold">
        Publicaciones de {currentUser.name}

        <br />

        <Tooltip title="Publicar">
          <IconButton onClick={() => handleOpenModal(null, 'CREAR')} className="p-0" aria-label="detalles" aria-haspopup="true">
            <AddCircleOutlineIcon className="text-success" style={{height: '5rem', width: '5rem'}}/>
          </IconButton>
        </Tooltip>
      </Typography>
      
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Refugio</TableCell>
              <TableCell>Animal</TableCell>
              <TableCell>Mascota</TableCell>
              <TableCell>Estado</TableCell>
              <TableCell align="center">Acciones</TableCell>
            </TableRow>
          </TableHead>

          <TableBody>
              {mascotas?.map((m) => (
                <TableRow key={m.id} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                  <TableCell component="th" scope="row"> {m.nombreUsuario}</TableCell>
                  <TableCell>{m.especie}</TableCell>
                  <TableCell>{m.nombre}</TableCell>
                  <TableCell className={`${m.estado === 'Disponible' ? 'text-success' :
                      (m.estado === 'Adoptada' ? 'text-danger' : 'text-warning')} fw-bold`}>
                    {m.estado}
                  </TableCell>

                  <TableCell className="d-flex justify-content-center gap-3">
                    <Tooltip title="Detalles">
                      <IconButton onClick={() => handleOpenModal(m.id, 'DETALLES')} className="p-0" aria-label="detalles" aria-haspopup="true">
                        <SettingsIcon className="text-primary" style={{height: '2rem', width: '2rem'}}/>
                      </IconButton>
                    </Tooltip>

                    {m.estado === 'Disponible' &&
                      <>
                        <Tooltip title="Modificar">
                          <IconButton onClick={() => handleOpenModal(m.id, 'EDITAR')} className="p-0" aria-label="detalles" aria-haspopup="true">
                            <EditIcon className="text-secondary" style={{height: '2rem', width: '2rem'}}/>
                          </IconButton>
                        </Tooltip>

                        <Tooltip title="Eliminar">
                          <IconButton onClick={() => deleteMascota(m.id)} className="p-0" aria-label="eliminar" aria-haspopup="true">
                            <DeleteIcon className="text-danger" style={{height: '2rem', width: '2rem'}}/>
                          </IconButton>
                        </Tooltip>
                      </>
                    }
                    {m.estado === 'Solicitada' &&
                      <>
                        <Tooltip title="Aprobar solicitud">
                          <IconButton onClick={() => confirmarSolicitud(m.id, 'Aprobada')} className="p-0" aria-label="aprobar" aria-haspopup="true">
                            <CheckCircleIcon className="text-success" style={{height: '2rem', width: '2rem'}}/>
                          </IconButton>
                        </Tooltip>

                        <Tooltip title="Rechazar solicitud">
                          <IconButton onClick={() => confirmarSolicitud(m.id, 'Rechazada')} className="p-0" aria-label="rechazar" aria-haspopup="true">
                            <CancelIcon className="text-danger" style={{height: '2rem', width: '2rem'}}/>
                          </IconButton>
                        </Tooltip>
                      </>
                    }
                  </TableCell>
                </TableRow>
              ))}
          </TableBody>
        </Table>
      </TableContainer>
      {modal === 'DETALLES' ? (
        <MascotaModal open={open} onClose={handleCloseModal} modal={modal} idMascota={selectedMascota}/>
      ) : (
        <MascotaFormModal open={open} onClose={handleCloseModal} fetchMascotas={getMascotas} idMascota={selectedMascota} modo={modal}/>
      )}
    </section>
  );
}

export default RefugioComponent;
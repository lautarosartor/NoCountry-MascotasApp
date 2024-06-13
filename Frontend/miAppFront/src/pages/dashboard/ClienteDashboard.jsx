import { IconButton, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Tooltip, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useAuth } from "../../context/AuthContext";
import { Get, Put } from "../../services/http";
import CancelIcon from '@mui/icons-material/Cancel';

const ClienteComponent = () => {
  const { currentUser } = useAuth();
  const [solicitudes, setSolicitudes] = useState([]);

  const handleCancelar = async (id) => {
    try {
      const confirmacion = window.confirm("¿Estás seguro que deseas cancelar esta solicitud?");

      if (confirmacion) {
        await Put(`Solicitud/${id}`, {'estado': 'Cancelada'})
          .then(() => getSolicitudes());
      }
    }
    catch (error) {
      console.log('ERROR: ', error);
    }
  }

  const getSolicitudes = async () => {
    try {
      const solicitudes = await Get(`Solicitud?email=${currentUser.email}`);

      setSolicitudes(solicitudes);
    }
    catch (error) {
      console.log('ERROR: ', error);
    }
  }

  useEffect(() => {
    getSolicitudes();
  }, []);

  const formatearFecha = (fecha) => {
    fecha = new Date(fecha).toLocaleString('es-AR');
    return fecha;
  }

  return (
    <section className="container">
      <Typography className="text-center mb-4 fs-2 fw-bold">
        Solicitudes de {currentUser.name}
      </Typography>

      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Mascota</TableCell>
              <TableCell>Fecha de solicitud</TableCell>
              <TableCell>Estado de solicitud</TableCell>
              <TableCell align="center">Acciones</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {solicitudes && solicitudes.length > 0 ? (
              solicitudes.map((s) => (
                <TableRow key={s.id} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                  <TableCell component="th" scope="row">
                    {s.nombreMascota}
                  </TableCell>
                  
                  <TableCell>
                    {formatearFecha(s.fecha)}
                  </TableCell>

                  <TableCell  className={`${s.estado === 'Aprobada' ? 'text-success' : (s.estado === 'Pendiente' ? 'text-warning' : 
                      (s.estado === 'Rechazada' ? 'text-danger' : 'text-secondary'))} fw-bold`}>
                    {s.estado}
                  </TableCell>

                  <TableCell align="center">
                    <Tooltip title="Cancelar solicitud">
                        {s.estado === 'Pendiente' ? (
                          <IconButton onClick={() => handleCancelar(s.id)} className="p-0">
                            <CancelIcon className="text-danger" style={{height: '2rem', width: '2rem'}}/>
                          </IconButton>
                        ) : (
                          <IconButton className="p-0">
                            <CancelIcon disabled style={{height: '2rem', width: '2rem'}}/>
                          </IconButton>
                        )}
                    </Tooltip>
                  </TableCell>
                </TableRow>
              ))
            ) : (
              <TableRow>
                <TableCell colSpan={4}>
                  <p className="alert alert-warning text-center">
                    No hay registros para mostrar
                  </p>
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </TableContainer>
    </section>
  );
}

export default ClienteComponent;
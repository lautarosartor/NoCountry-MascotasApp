import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useAuth } from "../../context/AuthContext";
import { Get } from "../../services/http";

const ClienteComponent = () => {
  const { currentUser } = useAuth();
  const [solicitudes, setSolicitudes] = useState([]);

  useEffect(() => {
    const getSolicitudes = async () => {
      try {
        const solicitudes = await Get(`Solicitud/usuario/${currentUser.email}`);
        console.log(solicitudes);
        setSolicitudes(solicitudes);
      }
      catch (error) {
        console.log('ERROR: ', error);
      }
    }

    getSolicitudes();
  }, []);

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
              <TableCell>Acciones</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {solicitudes && solicitudes.length > 0 ? (
              solicitudes.map((s) => (
                <TableRow key={s.id} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                  <TableCell component="th" scope="row">{s.nombreMascota}</TableCell>
                  <TableCell>{s.fecha}</TableCell>
                  <TableCell>{s.estado}</TableCell>
                  <TableCell align="center">
                    <a className="btn btn-primary me-1 p-0">Detalles</a>
                    |
                    <a className="btn btn-danger ms-1 p-0">Borrar</a>
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
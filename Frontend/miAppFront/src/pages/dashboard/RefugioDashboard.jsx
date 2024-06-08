import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { Get } from "../../services/http";
import { useAuth } from '../../context/AuthContext';

const RefugioComponent = () => {
  const { currentUser } = useAuth();
  const [mascotas, setMascotas] = useState([]);

  useEffect(() => {
    const getMascotas = async () => {
      try {
        const mascotas = await Get(`Mascotas`);

        setMascotas(mascotas);
      }
      catch (error) {
        console.log('ERROR: ', error);
      }
    }

    getMascotas();
  });

  return (
    <section className="container">
      <Typography className="text-center mb-4 fs-2 fw-bold">
        PUBLICACIONES DE {currentUser.name}
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
            {mascotas.map((m) => (
              <TableRow key={m.id} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                <TableCell component="th" scope="row"> {m.nombreUsuario}</TableCell>
                <TableCell>{m.especie}</TableCell>
                <TableCell>{m.nombre}</TableCell>
                <TableCell>{m.estado}</TableCell>
                <TableCell align="center">
                  <a className="btn btn-primary me-1 p-0">Detalles</a>
                  |
                  <a className="btn btn-danger ms-1 p-0">Borrar</a>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </section>
  );
}

export default RefugioComponent;
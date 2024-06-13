import { Button } from "@mui/material";
import { memo } from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import { Post } from "../services/http";

export const BtnAdoptar = memo(({estado, id, fetchMascotas}) => {
  const { currentUser, authStatus } = useAuth();

  const handleSolicitar = async () => {
    try {
      const confirmacion = window.confirm("¡Estas a punto de solicitar la adopción de esta mascota!");
      
      if (confirmacion) {
        await Post("Solicitud",
        {
          'emailUsuario': currentUser.email,
          'idMascota': id,
        });
        
        fetchMascotas();
      }
    }
    catch (error) {
      console.log('ERROR: ', error);
    }
  }

  return (
    <>
      {authStatus === 'authenticated' && currentUser?.role === "Cliente" ? (
        <Button size="small" variant={estado === 'Disponible' ? 'contained' : 'outlined'}
          color="secondary" disabled={estado !== 'Disponible'}>
          <Link className={`${estado === 'Disponible' ? 'text-white' : 'text-secondary'} text-decoration-none`}
            onClick={handleSolicitar}>
              Adoptar
          </Link>
        </Button>
      ) : (
        <></>
      )}
    </>
  );
});

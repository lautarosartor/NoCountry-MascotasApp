import { Box, Button, Modal, TextField, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useAuth } from "../../context/AuthContext";
import { Get, Post, Put } from "../../services/http";

const MascotaFormModal = ({ open, onClose, fetchMascotas, idMascota, modo }) => {
  const { currentUser } = useAuth();

  const initForm = {
    nombre: '',
    emailUsuario: currentUser.email,
    meses: 0,
    años: 0,
    especie: '',
    raza: '',
    urlImagen: '',
    descripcion: '',
  };

  const [mascotaForm, setMascotaForm] = useState(initForm);
  const [formValid, setFormValid] = useState(false);
  const [error, setError] = useState('');

  const handleChange = (e) => {
    const { name, value } = e.target;

    setMascotaForm({
      ...mascotaForm,
      [name]: value,
    });
  }

  const handleClose = () => {
    onClose(true);
    setMascotaForm(initForm);
  }

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');

    if (modo === 'CREAR') {
      try {
        await Post('Mascotas', mascotaForm)
          .then(() => fetchMascotas());  // Actualizamos la tabla
      }
      catch (error) {
        setError('Error al crear la publicación');
        console.log('ERROR: ', error);
      }
    }
    if (modo === 'EDITAR') {
      try {
        await Put(`Mascotas/${idMascota}`, mascotaForm)
          .then(() => fetchMascotas());  // Actualizamos la tabla
      }
      catch (error) {
        setError('Error al editar la publicación');
        console.log('ERROR: ', error);
      }
    }

    handleClose();
  };

  useEffect(() => {
    setError('');

    if (modo === 'EDITAR' && idMascota) { 
      const getMascota = async (idMascota) => {
        try {
          const mascotaData = await Get(`Mascotas/${idMascota}`);
          setMascotaForm(mascotaData);
        }
        catch (error) {
          console.log('ERROR: ', error);
        }
      }

      getMascota(idMascota);
    }

  }, [modo, idMascota]);

  useEffect(() => {
    const { nombre, meses, años, especie, raza, urlImagen } = mascotaForm;

    // Validacion del formulario
    setFormValid(nombre && meses && años && especie && raza && urlImagen);
  }, [mascotaForm]);

  return (
    <Modal open={open} onClose={handleClose}
      aria-labelledby="modal-modal-title"
      aria-describedby="modal-modal-description">

      <Box component="form" noValidate autoComplete="off" onSubmit={handleSubmit}
        className="d-flex flex-column gap-3"
        sx={{
          position: 'absolute', top: '50%', left: '50%', 
          transform: 'translate(-50%, -50%)', 
          maxWidth: '500px', width: '80%', 
          bgcolor: 'background.paper', boxShadow: 24,
          borderRadius: '5px', p: 2,
        }}>

        <Typography variant="h5" className="text-center mb-4" component="p">
          {error && <p className="text-danger">{error}</p>}
          {modo === 'CREAR' ? "Crear" : "Editar"} publicación
        </Typography>

        <div className="d-flex justify-content-between gap-3">
          <TextField label="Nombre mascota" fullWidth required name="nombre"
            onChange={handleChange} value={mascotaForm.nombre}/>

          <TextField label="Usuario" fullWidth name="emailUsuario"
            value={currentUser.email} inputProps={{ readOnly: true }}/>
        </div>

        <div className="d-flex justify-content-between gap-3">
          <TextField label="Meses" type="number" inputProps={{ min: "0" }}
            fullWidth required name="meses" onChange={handleChange} value={mascotaForm.meses || ""}/>

          <TextField label="Años" type="number" inputProps={{ min: "0" }}
            fullWidth required name="años" onChange={handleChange} value={mascotaForm.años || ""}/>
        </div>

        <div className="d-flex justify-content-between gap-3">
          <TextField select fullWidth required name="especie"
            onChange={handleChange} value={mascotaForm.especie}
            SelectProps={{
              native: true,
            }}>

            <option defaultChecked hidden>
              Seleccionar mascota
            </option>

            <option value={"Perro"}>
              Perro
            </option>

            <option value={"Gato"}>
              Gato
            </option>

            <option value={"Otro"}>
              Otros..
            </option>
          </TextField>

          <TextField className="d-flex" label="Raza" id="raza" fullWidth required name="raza"
            onChange={handleChange} value={mascotaForm.raza}/>
        </div>

        <TextField label="URL imagen" fullWidth required name="urlImagen"
          onChange={handleChange} value={mascotaForm.urlImagen}/>

        <textarea className="form-control" rows="4" name="descripcion" style={{resize: 'none'}}
          onChange={handleChange} value={mascotaForm.descripcion} placeholder="Descripción"/>

        <div className="d-flex justify-content-between">
          <Button type="submit" variant="contained" onClick={handleSubmit} disabled={!formValid}>
            {modo === "CREAR" ? "Crear" : "Guardar cambios"}
          </Button>
          
          <Button variant="outlined" onClick={handleClose}>
            Cancelar
          </Button>
        </div>

      </Box>
    </Modal>
  );
}

export default MascotaFormModal;
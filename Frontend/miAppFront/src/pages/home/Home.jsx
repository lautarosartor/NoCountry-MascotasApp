
import { Button } from '@mui/material';
import MascotasComponent from './card/Mascotas';
import './Home.css';

const HomeComponent = () => {
  return (
    <>
    <div className="portada d-flex text-center">
      <div className="container p-4 position-relative text-end">
        <p className="titulo m-0">
          El amor no
          <br/>
          se compra,
          <br/>
          se adopta.
        </p>
    
        <p className="m-0 mt-5 fs-2">
          ¡Encontrá tu compañero ideal!
        </p>

        <div className="p-4 d-flex justify-content-end gap-4 position-absolute bottom-0 start-0 end-0">
          <Button size="large" color='primary' variant="contained">Adoptar</Button>
          <Button size="large" color='secondary' variant="contained">Dar en adopción</Button>
        </div>
      </div>
    </div>
    
    <MascotasComponent/>
    </>
  );
};

export default HomeComponent;


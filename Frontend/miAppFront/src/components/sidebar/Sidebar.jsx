import './Sidebar.css'

const Sidebar = () => {
  return (
    <aside className="contenedor d-flex justify-content-center gap-3">
      <div className="filter">
        <p className="fs-4 fw-bold m-0">Animal</p>
        
        <label className="material-checkbox">
          <input type="checkbox"/>
          Perros
        </label>

        <label className="material-checkbox">
          <input type="checkbox"/>
          Gatos
        </label>

        <label className="material-checkbox">
          <input type="checkbox"/>
          Otros..
        </label>
      </div>

      <div className="filter">
        <p className="fs-4 fw-bold m-0">Sexo</p>
        
        <label className="material-checkbox">
          <input type="checkbox"/>
          Macho
        </label>

        <label className="material-checkbox">
          <input type="checkbox"/>
          Hembra
        </label>
      </div>

      <div className="filter">
        <p className="fs-4 fw-bold m-0">Tamaño</p>
        
        <label className="material-checkbox">
          <input type="checkbox"/>
          Pequeño
        </label>

        <label className="material-checkbox">
          <input type="checkbox"/>
          Mediano
        </label>

        <label className="material-checkbox">
          <input type="checkbox"/>
          Grande
        </label>
      </div>
    </aside>
  );
};

export default Sidebar;

/*
<aside style={styles.sidebar}>
      <ul>
        <h4>Animal</h4>
        <li>Perros<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Gatos<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Otros<input type="checkbox" id="filtro1" name="filtro1" /></li>
      </ul>
      <ul>
        <h4>Raza</h4>
        <li>Labrador<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Persa<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Bulldog<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Otros<input type="checkbox" id="filtro1" name="filtro1" /></li>
      </ul>
      <ul>
        <h4>Sexo</h4>
        <li>Macho<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Hembra<input type="checkbox" id="filtro1" name="filtro1" /></li>
      </ul>
      <ul>  
        <h4>Tamaño</h4>
        <li>Pequeño<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Mediano<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Grande<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Otros<input type="checkbox" id="filtro1" name="filtro1" /></li>
      </ul>
      <ul>
        <h4>Rango de Edad</h4>
        <li>Recien nacido<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Cachorro<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Adulto<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Otros<input type="checkbox" id="filtro1" name="filtro1" /></li>
      </ul>
    </aside>

const styles = {
  sidebar: {
    width: ' 100%',
    maxWidth: '180px',
    padding: '0.5rem',
    backgroundColor: '#f4f4f4',
    height: '100vh',
    boxSizing: 'border-box',
    borderRadius: '10px',
  },
  checkboxContainer: {
    display: 'flex',
    alignItems: 'center',
    marginBottom: '1rem',
  },
};
*/
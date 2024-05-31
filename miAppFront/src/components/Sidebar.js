import React from 'react';

const Sidebar = () => {
  return (
    <aside style={styles.sidebar}>
      <ul>
        <h4>Animal</h4>
        <li>Perros<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Gatos<input type="checkbox" id="filtro1" name="filtro1" /></li>
        <li>Conejos<input type="checkbox" id="filtro1" name="filtro1" /></li>
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
  );
};
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
// const styles = {
//   sidebar: {
//     width: '200px',
//     padding: '1rem',
//     backgroundColor: '#f4f4f4',
//     height: '100vh',
//     borderRadius: '10px',
//   },
//   checkboxContainer: {
//            display: 'flex',
//            alignItems: 'center',
//            marginBottom: '1rem',
//      }
// };

export default Sidebar;
// const Sidebar = () => {
//     return (
//       <aside style={styles.sidebar}>
//         <h2>Filtros</h2>
//         <form>
//           <div style={styles.checkboxContainer}>
//             <h4>Animal</h4>
//             <input type="checkbox" id="filtro1" name="filtro1" />
//             <label htmlFor="filtro1">Filtro 1</label>
//           </div>
//           <div style={styles.checkboxContainer}>
//             <input type="checkbox" id="filtro2" name="filtro2" />
//             <label htmlFor="filtro2">Filtro 2</label>
//           </div>
//           <div style={styles.checkboxContainer}>
//             <input type="checkbox" id="filtro3" name="filtro3" />
//             <label htmlFor="filtro3">Filtro 3</label>
//           </div>
//         </form>
//       </aside>
//     );
//   };
  
//   const styles = {
//     sidebar: {
//       width: '200px',
//       padding: '1rem',
//       backgroundColor: '#f4f4f4',
//       height: '100vh',
//     },
//     checkboxContainer: {
//       display: 'flex',
//       alignItems: 'center',
//       marginBottom: '1rem',
//     }
//   };
  //export default Sidebar;

import React from 'react';
import Header from './Header';
import Sidebar from './Sidebar';
import ProductCard from './ProductCard';
import WelcomeSection from './WelcomeSection';

const HomePage = () => {
  const products = [
    { id: 1, Nombre: 'Mascota 1', description: 'Descripción de la Mascota 1', imageUrl: 'https://www.elespectador.com/resizer/YgvTGqw5eyPDD3RTo5SQyl-7tRU=/920x613/filters:quality(60):format(jpeg)/www.elespectador.com/resizer/GtLezpDdZTdlwNqHVM1C0zSafJw=/arc-anglerfish-arc2-prod-elespectador/public/BOP5BVFGYBDMDK4J5B7YQ3VOUM.jpg'},
    { id: 2, Nombre: 'Mascota 2', description: 'Descripción de la Mascota 2', imageUrl: 'https://www.elespectador.com/resizer/YgvTGqw5eyPDD3RTo5SQyl-7tRU=/920x613/filters:quality(60):format(jpeg)/www.elespectador.com/resizer/GtLezpDdZTdlwNqHVM1C0zSafJw=/arc-anglerfish-arc2-prod-elespectador/public/BOP5BVFGYBDMDK4J5B7YQ3VOUM.jpg'},
    { id: 3, Nombre: 'Mascota 3', description: 'Descripción de la Mascota 3', imageUrl: 'https://www.elespectador.com/resizer/YgvTGqw5eyPDD3RTo5SQyl-7tRU=/920x613/filters:quality(60):format(jpeg)/www.elespectador.com/resizer/GtLezpDdZTdlwNqHVM1C0zSafJw=/arc-anglerfish-arc2-prod-elespectador/public/BOP5BVFGYBDMDK4J5B7YQ3VOUM.jpg' },
  ];

  return (
    <div style={styles.container}>
      <Header />
      <WelcomeSection />
      <div style={styles.content}>
        <main style={styles.main}>
        <Sidebar />
          {products.map(product => (
            <ProductCard
              key={product.id}
              title={product.title}
              description={product.description}
              imageUrl={product.imageUrl}
            />
          ))}
        </main>
      </div>
    </div>
  );
};
const styles = {
    container: {
      display: 'flex',
      flexDirection: 'column',
    },
    content: {
      display: 'flex',
      flexDirection: 'column',
    },
    main: {
      display: 'flex',
      flexWrap: 'wrap',
      justifyContent: 'center',
      padding: '1rem',
      overflowY: 'auto',
    },
  };
// const styles = {
//   container: {
//     display: 'flex',
//     flexDirection: 'column',
//     height: '100vh',
//   },
//   content: {
//     display: 'flex',
//     flex: 1,
//   },
//   main: {
//     display: 'flex',
//     flexWrap: 'wrap',
//     justifyContent: 'center',
//     padding: '1rem',
//     overflowY: 'auto',
//   },
// };

export default HomePage;

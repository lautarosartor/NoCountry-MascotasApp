<div align="center">
  <h1>ANIMAL HEAVEN: Plataforma de Adopción de Mascotas</hh1>
  <img src="https://images.vexels.com/media/users/3/202270/isolated/preview/272fa397d8b6706f8dde05db9b5a561d-huella-de-perro-rojo-splash-plana.png" width="250"/>
</div>

# Descripción
<p>
  Este proyecto es una plataforma en línea diseñada para facilitar la adopción de mascotas rescatadas.
</p>

<p>
  La plataforma permite a las <em>personas</em> buscar mascotas y solicitar la adopción de las mismas.
  </br>
  Los <em>refugios</em> de animales pueden publicar y gestionar las mascotas disponibles para adopción, ayudando a encontrarles hogares amorosos.
</p>

## Historias de Usuario

- **Persona Interesada en Adoptar:**
  - Como persona interesada en adoptar una mascota, quiero poder buscar y adoptar mascotas rescatadas en una plataforma en línea.

- **Refugio de Animales:**
  - Como refugio de animales, quiero poder registrar mascotas en la plataforma y gestionar procesos de adopción para encontrarles hogares amorosos.

## Funcionalidades Esenciales

1. **Búsqueda y Solicitud de Adopción por parte de las personas:**
   - Las personasueden buscar mascotas, ver detalles de las mascotas disponibles y enviar solicitudes de adopción en línea.

2. **Registro y Gestión de Mascotas por parte de los Refugios:**
   - Los refugios pueden registrar nuevas mascotas en la plataforma, actualizar la información de las mascotas existentes y gestionar las solicitudes de adopción.


<div align="center">
  <h2>Tecnologías utilizadas</h2>
  <h3>Frontend</h3>
  <img src="https://skillicons.dev/icons?i=js,react,mui,html,css,bootstrap&perline=10" />
  
  <h3>Backend</h3>
  <img src="https://skillicons.dev/icons?i=cs,dotnet&perline=5" />
  
  <h3>Base de datos</h3>
  <img src="https://skillicons.dev/icons?i=sqlite&perline=5" />
  
  <h3>Herramientas de desarrollo</h3>
  <img src="https://upload.wikimedia.org/wikipedia/commons/3/32/HeidiSQL_logo_image.png" width="50" title="HeidiSQL" alt="HeidiSQL"/>
  <img src="https://static-00.iconduck.com/assets.00/swagger-icon-512x512-halz44im.png" width="50" title="Swagger" alt="Swagger"/>
  <img src="https://skillicons.dev/icons?i=git,github,docker&perline=5" />
</div>

</br>
<hr>

<div align="center">
<h1>AUTOR</h1>

<h3>Full Stack</h3>

|                                                                                                                                            <img src="https://avatars.githubusercontent.com/u/72401480?v=4" width=200>                                                                                                                                             |
| :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
|                                                                                                                                                             **Sartor Lautaro**                                                                                                                                                             |
| <a href="https://github.com/lautarosartor" target='_BLANK'><img src="https://img.shields.io/badge/github-%23121011.svg?&style=for-the-badge&logo=github&logoColor=white"/></a><a href="https://www.linkedin.com/in/lautarosartor/"><img src="https://img.shields.io/badge/linkedin%20-%230077B5.svg?&style=for-the-badge&logo=linkedin&logoColor=white"/></a> |

</div>

  **Backend:**
  - Desarrollo de la web API utilizando C#.NET y Entity Framework.
  - Autenticación y autorización de usuario con JWT Token.
  - Conexión a base de datos SQLite, y gestión de la BBDD en HeidiSQL.
  - Testeo de la API en Swagger UI.
  
  **Frontend:**
  - Desarrollo de la interfaz e interactividad de usuario en React.js.
  - Conexión con el backend y consumo de endpoints de la API.
  - Consumo de la API de Argentina para la obtención de localidades.
  - Manejo de estado reactivo del usuario y rutas restringidas.

  **Docker**
  - Creación de los Dockerfiles adecuados para generar las imagenes de contenedor tanto para el frontend como para el backend.
  - Utilización de docker-compose para definir y ejecutar ambos contenedores como un servicio. Esto facilitó la configuración y ejecución del frontend y backend de manera simultanea.

</br>
<hr>

## Instalación y Configuración (sin Docker)

1. Clona el repositorio:
   ```sh
   git clone https://github.com/lautarosartor/NoCountry-MascotasApp.git

2. Navega al directorio del backend:
   ```sh
   cd NoCountry-MascotasApp/Backend/webAPI/

3. Instala las dependencias del backend:
   ```sh
   dotnet restore

4. Inicia el servidor backend:
   ```sh
   dotnet run

5. Navega al directorio del frontend:
   ```sh
   cd ../..
   cd Frontend/miAppFront

6. Instala las dependencias del frontend:
   ```sh
   npm install

7. Inicia el servidor frontend:
   ```sh
   npm start

<hr>

## Instalación con Docker
1. Clona el repositorio:
   ```sh
   git clone https://github.com/lautarosartor/NoCountry-MascotasApp.git

2. Navega al directorio del proyecto:
   ```sh
   cd NoCountry-MascotasApp/

3. Ejecuta el Docker Compose:
   ```sh
   docker-compose up --build

<div align="center">
  <img src="https://cdn.prod.website-files.com/65773955177041dbf059ed20/6584760759a54bef40894700_Logo%20navbar.svg" width="500"/>
</div>

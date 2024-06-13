# NO COUNTRY
# Proyecto: Plataforma de Adopción de Mascotas - *ANIMAL HEAVEN*

## Descripción
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

1. **Búsqueda y Solicitud de Adopción:**
   - Los usuarios pueden buscar mascotas disponibles para adopción y enviar solicitudes de adopción en línea.

2. **Registro y Gestión de Mascotas por parte de los Refugios:**
   - Los refugios pueden registrar nuevas mascotas en la plataforma, actualizar la información de las mascotas existentes y gestionar las solicitudes de adopción.

## Tipos de Usuarios

- **Personas interesadas en adoptar mascotas:**
  - Pueden buscar mascotas, ver detalles de las mascotas disponibles y enviar solicitudes de adopción.

- **Refugios de animales:**
  - Pueden registrar y gestionar las mascotas disponibles para adopción.

## Tecnologías Utilizadas

- **Frontend:** </br>
  <img src="https://skillicons.dev/icons?i=react,bootstrap&perline=5" />

- **Backend:** </br>
  <img src="https://skillicons.dev/icons?i=cs,dotnet&perline=5" />

- **Base de Datos:** </br>
  <img src="https://skillicons.dev/icons?i=sqlite&perline=5" />

- **Herramientas de desarrollo:** </br>
  <img src="https://upload.wikimedia.org/wikipedia/commons/3/32/HeidiSQL_logo_image.png" width="50" />
  <img src="https://static-00.iconduck.com/assets.00/swagger-icon-512x512-halz44im.png" width="50" />
  <img src="https://skillicons.dev/icons?i=git,github,docker&perline=5" />

## Instalación y Configuración

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

## Autor

* ### Sartor Lautaro *(Full-Stack)*
  
  **Backend:**
  - Desarrollo de la web API utilizando C#.NET y Entity Framework.
  - Autenticación y autorización de usuario con JWT Token.
  - Conexión a base de datos SQLite, gestión de la BBDD en HeidiSQL.
  - Testeo de la API en Swagger UI.
  
  **Frontend:**
  - Desarrollo de la interfaz e interactividad de usuario en React.js.
  - Conexión con el backend y consumo de la API.
  - Consumo de API de localidades de Argentina.
  - Manejo de estado reactivo del usuario y rutas restringidas.


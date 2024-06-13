# Usa una imagen base de Node.js para construir y servir la aplicación
FROM node:21-alpine3.18 as build

# Establece el directorio de trabajo dentro del contenedor
WORKDIR /app/miAppFront

# Copia el package.json y package-lock.json primero
COPY miAppFront/package*.json ./

# Instala las dependencias
RUN npm install

# Copia el resto de los archivos de la aplicación
COPY miAppFront/ ./

# Construye la aplicación
RUN npm run build

# Usa una imagen base ligera para servir la aplicación
FROM nginx:1.25.3-alpine as runtime

# Expone el puerto 80 para permitir la comunicación
EXPOSE 80

# Copia los archivos generados en la etapa de construcción
COPY --from=build /app/miAppFront/build /usr/share/nginx/html

# Define el comando para ejecutar nginx al iniciar el contenedor
CMD ["nginx", "-g", "daemon off;"]

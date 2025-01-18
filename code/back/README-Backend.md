
![image](https://github.com/user-attachments/assets/c830c83c-010d-42b7-a981-7bfbdfc5ad6a)

# ONE-MILLION-LUXURY-BACKEND

## Desarrollo C#

Este proyecto se enfoca en la creación de una API REST utilizando tecnologías como .NET, C# y SQL. El desarrollo sigue el patrón de diseño CQRS junto con MediatR. lo que facilita la implementación de un API con corte vertical. ([Codigo Fuente](https://github.com/jhoney787813/one-million-luxury-app/tree/main/code/back/src)) 

### Requerimientos a evaluar:

# Desarrollo Backend (BFF)

## Objetivos

En este proyecto, se tiene como objetivo desarrollar una API en C# utilizando .NET 8 o 9 para obtener datos de propiedades desde una base de datos MongoDB. Esta API deberá contar con filtros específicos que permitan recuperar una lista de propiedades según los siguientes parámetros:

- **Nombre** de la propiedad.
- **Dirección** de la propiedad.
- **Rango de precio** de las propiedades.


# Desarrollo Backend (API) con Patrón BFF

## Introducción

Este desarrollo de la API se realizó utilizando el patrón **Backend for Frontend (BFF)**, lo cual ofrece una solución elegante y eficiente para manejar las interacciones entre el frontend y el backend en un entorno altamente dinámico. Este patrón se ha implementado con el objetivo de que la API pueda ser reutilizada tanto en aplicaciones móviles como web, brindando una experiencia optimizada en cada uno de estos contextos.

## ¿Por qué utilizar el patrón BFF?

El patrón BFF tiene como principal ventaja la capacidad de crear un backend que sirva de puente específico entre las necesidades del frontend y el backend general. En otras palabras, se crea un **backend personalizado** para cada tipo de interfaz (ya sea web o móvil), lo que permite optimizar tanto el rendimiento como la experiencia de usuario.

### Ventajas de aplicar el patrón BFF:

1. **Optimización del rendimiento**:
   - Al crear un backend personalizado para cada tipo de cliente (móvil y web), se pueden gestionar mejor las llamadas a las APIs y minimizar los datos innecesarios que se envían a cada tipo de cliente.
   - Esto reduce el consumo de recursos y mejora el tiempo de carga, lo cual es crucial, sobre todo en dispositivos móviles.

2. **Flexibilidad**:
   - El patrón BFF permite que cada cliente (web o móvil) pueda tener su propia lógica de negocio en el backend. Esto se traduce en una mayor **adaptabilidad** a las necesidades de cada plataforma, sin interferir en el funcionamiento global de la aplicación.

3. **Escalabilidad**:
   - Como cada cliente tiene un backend dedicado, es más fácil escalar cada parte del sistema según las demandas específicas de cada plataforma. Por ejemplo, si se requiere un mayor procesamiento para la aplicación móvil, solo se escalaria la parte correspondiente sin afectar al cliente web.

4. **Reutilización de código**:
   - Al estructurar la API siguiendo este patrón, no solo estamos optimizando el rendimiento de cada plataforma, sino que también estamos **maximizando la reutilización del código**. Las funcionalidades y lógica de negocio que no dependen de la interfaz de usuario se pueden compartir entre ambos entornos.

5. **Mantenimiento más sencillo**:
   - Este enfoque facilita el **mantenimiento** de la aplicación, ya que los cambios o nuevas funcionalidades para una plataforma específica no afectarán directamente a la otra, evitando posibles problemas de compatibilidad o sobrecarga de datos.

## Estructura del DTO

En este contexto, la estructura del DTO (Data Transfer Object) se mantiene clara y eficiente, adaptándose a las necesidades tanto de la web como de la aplicación móvil. Los campos definidos en el DTO son los siguientes:

- **IdOwner**: Identificador único del propietario de la propiedad.
- **Name**: Nombre de la propiedad.
- **Address Property**: Dirección de la propiedad.
- **Price Property**: Precio de la propiedad.
- **Image**: Solo se incluirá una imagen representativa de la propiedad.


# Documentación de la API: BFF Backend Million App

## Introducción

La **API BFF Backend Million App** es una solución diseñada para la consulta y gestión de propiedades y propietarios. Esta arquitectura sigue el patrón **Backend for Frontend (BFF)**, lo que permite crear aplicaciones escalables y optimizadas para su uso en plataformas tanto web como móviles.

### Versión:
- **Versión**: 1.0

### Descripción:
Esta API está diseñada para gestionar propiedades de usuarios y permite realizar consultas filtradas por nombre, dirección y precio. Al utilizar el patrón BFF, la API facilita la interacción entre el frontend y el backend, permitiendo aplicaciones móviles y web que compartan lógica de negocio y optimización.

## Endpoints

### 1. **Consultar propiedades por filtros**
- **Ruta**: `/api/v1/getpropertybyfilters`
- **Método**: `POST`
- **Resumen**: Permite consultar la información de las propiedades de los usuarios aplicando filtros como el nombre, la dirección y el rango de precio.

#### Cuerpo de la solicitud:
La solicitud debe contener un objeto JSON que cumple con el esquema **GetFilteredPropertyQuery**, que puede incluir los siguientes parámetros:
- **name**: Nombre de la propiedad (opcional).
- **address**: Dirección de la propiedad (opcional).
- **minPrice**: Precio mínimo de la propiedad (opcional).
- **maxPrice**: Precio máximo de la propiedad (opcional).

#### Respuestas:
- **200 (OK)**: Devuelve una lista de propiedades que cumplen con los filtros aplicados, siguiendo el esquema **GetFilteredPropertyQueryResponse**.
  - **Campos del esquema de respuesta**:
    - **idOwner**: ID del propietario de la propiedad.
    - **ownerName**: Nombre del propietario.
    - **propertyName**: Nombre de la propiedad.
    - **propertyAddress**: Dirección de la propiedad.
    - **price**: Precio de la propiedad.
    - **imageUrl**: URL de la imagen representativa de la propiedad.

- **400 (Bad Request)**: Se produce cuando la solicitud no cumple con los requisitos del servidor.
- **401 (Unauthorized)**: Indica que la solicitud no está autorizada.
- **406 (Not Acceptable)**: El servidor no puede procesar el tipo de contenido de la solicitud.
- **409 (Conflict)**: Se produce cuando hay un conflicto con el estado actual del servidor.
- **500 (Internal Server Error)**: Error interno en el servidor.

### 2. **Consultar el Top N propiedades más recientes**
- **Ruta**: `/api/v1/getpropertytop/{top}`
- **Método**: `GET`
- **Resumen**: Permite consultar el top N propiedades de los usuarios, ordenadas por la más reciente.

#### Parámetros:
- **top**: Número entero que indica cuántas propiedades se desean consultar (requerido).

#### Respuestas:
- **200 (OK)**: Devuelve las propiedades más recientes según el número indicado en el parámetro **top**, siguiendo el esquema **GetTopPropertyQueryResponse**.
  - **Campos del esquema de respuesta**:
    - **idOwner**: ID del propietario de la propiedad.
    - **ownerName**: Nombre del propietario.
    - **propertyName**: Nombre de la propiedad.
    - **propertyAddress**: Dirección de la propiedad.
    - **price**: Precio de la propiedad.
    - **imageUrl**: URL de la imagen representativa de la propiedad.

- **400 (Bad Request)**: Solicitud incorrecta.
- **401 (Unauthorized)**: No autorizado.
- **406 (Not Acceptable)**: No aceptable, tipo de contenido no soportado.
- **409 (Conflict)**: Conflicto con la solicitud.
- **500 (Internal Server Error)**: Error interno del servidor.

## Esquemas de Respuesta

### **GetFilteredPropertyQuery**:
Este esquema se utiliza en la solicitud para filtrar propiedades por nombre, dirección y rango de precio. Los campos son:
- **name**: Cadena opcional para el nombre de la propiedad.
- **address**: Cadena opcional para la dirección de la propiedad.
- **minPrice**: Número opcional que define el precio mínimo.
- **maxPrice**: Número opcional que define el precio máximo.

### **GetFilteredPropertyQueryResponse** y **GetTopPropertyQueryResponse**:
Estos esquemas describen la estructura de la respuesta que contiene la información de las propiedades consultadas:
- **idOwner**: ID del propietario.
- **ownerName**: Nombre del propietario (opcional).
- **propertyName**: Nombre de la propiedad (opcional).
- **propertyAddress**: Dirección de la propiedad (opcional).
- **price**: Precio de la propiedad (opcional).
- **imageUrl**: URL de la imagen de la propiedad (opcional).

### **ProblemDetails**:
Este esquema describe los detalles de un problema o error ocurrido en la API, y contiene:
- **type**: Tipo de error.
- **title**: Título del error.
- **status**: Código de estado HTTP.
- **detail**: Descripción detallada del error.
- **instance**: Instancia del error.

## Conclusión

La API **BFF Backend Million App** está diseñada para optimizar el acceso y gestión de propiedades, permitiendo consultas eficientes y adaptadas a las necesidades de las plataformas web y móviles. Con el uso de filtros y la posibilidad de consultar las propiedades más recientes, esta solución proporciona una manera efectiva de interactuar con los datos de propiedades y propietarios a través de un backend flexible y escalable.





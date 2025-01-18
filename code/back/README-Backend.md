
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


![image](https://github.com/user-attachments/assets/b8a4301c-68aa-4a19-ae8b-73ab8b15ec78)


### Versión:
- **Versión**: 1.0

### Descripción:
Esta API está diseñada para gestionar propiedades de usuarios y permite realizar consultas filtradas por nombre, dirección y precio. Al utilizar el patrón BFF, la API facilita la interacción entre el frontend y el backend, permitiendo aplicaciones móviles y web que compartan lógica de negocio y optimización.

## Endpoints

### 1. **Consultar propiedades por filtros**

![image](https://github.com/user-attachments/assets/df59038c-d786-4165-82a6-cd1c64338632)

![image](https://github.com/user-attachments/assets/80954274-2b55-4067-8647-7374ed301935)

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

![image](https://github.com/user-attachments/assets/602d5304-0df0-4956-9d23-b15634a403fa)

![image](https://github.com/user-attachments/assets/3d79dab2-caaf-4837-be20-59ab8ace3c04)

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



# Distribución de archivos en solución de proyecto "BFF.Backend.Million.App"

![image](https://github.com/user-attachments/assets/cb7c438c-1f2e-4963-8110-f08f5cd05c56)


# Estructura de Paquetes en la Construcción de APIs con CQRS y Vertical Slice

La distribución física de paquetes que mencionas en la construcción de APIs sigue un enfoque modular y bien organizado para favorecer la aplicación de principios SOLID, así como el patrón CQRS (Command Query Responsibility Segregation) y Vertical Slice, lo cual mejora la seguridad y la modularidad de la aplicación. A continuación, se explica cómo cada parte contribuye a estos objetivos:

## 1. Proyecto `BFF.Backend.Million.App` (API) y `BFF.Backend.Million.App.csproj` (controladores, endpoints y Swagger)
- Estos proyectos contienen la lógica de exposición de la API y la interfaz con el cliente. Siguiendo el patrón **MVC** (Model-View-Controller), los controladores sirven como intermediarios entre la capa de presentación (clientes) y la lógica de negocio.
- Al mantener los controladores separados de la lógica de negocio y la infraestructura, la aplicación queda más limpia y flexible. La documentación con **Swagger** proporciona visibilidad clara para los consumidores de la API.

 ![image](https://github.com/user-attachments/assets/ec84db56-4857-439c-8461-916b3c9a60a5)


## 2. Proyecto de clases `Application` (comunicación entre controladores y capa de dominio)
- Aquí se encuentran las clases encargadas de la **orquestación de comandos y consultas** dentro del patrón CQRS. Esta capa traduce las solicitudes de los controladores en acciones que deben realizarse en el dominio, y maneja el flujo de la aplicación sin incluir la lógica de negocio directa.
- **CQRS** separa las operaciones de lectura y escritura en distintos modelos, permitiendo una gestión más eficiente y escalable de los datos.
- Esto favorece principios como el de **responsabilidad única** y **abierto/cerrado**, ya que cada módulo solo tiene una razón para cambiar.
- 
![image](https://github.com/user-attachments/assets/04a70337-9aa4-4e71-b539-4f74226cc057)



## Requisito de Negocio de validar los datos de entrada

> Los servicios expuestos deberán validar que los datos ingresados como parámetros sean válidos. 

Para esto se promone que los datos de los modelos son validados sobre la capa de aplicación antes de llegar al dominio para realizar las operaciones de inserción o actualización. Esto garantiza que los datos de entrada sean los esperados antes de ejecutar las acciones sobre la base de datos.

Este enfoque asegura que se eviten errores innecesarios y que los datos ingresados sean correctos antes de afectar el sistema, preservando la integridad de la base de datos y las operaciones de negocio.


## Explicación de la Clase `GetFilteredPropertyQueryHandler`

La clase `CreateUserCommandHandler` es responsable de manejar la creación de un nuevo usuario a través del comando `CreateUserCommand`. Su función principal es validar los datos antes de invocar la lógica de dominio para ejecutar la operación.
![image](https://github.com/user-attachments/assets/9f9448ef-cc19-49a8-b4a2-b16331ef9b01)
![image](https://github.com/user-attachments/assets/06890890-ad78-4c04-831e-c6d79967ac11)


# Resumen de la Explicación de las Validaciones

## Proceso de Validación
La función `ModelIsValid` se encarga de validar las propiedades del query GetFilteredPropertyQuery -> `PropertyFilterRequestEntity` antes de procesar los datos. Las validaciones aplicadas son:

Todas estas validaciones se hacen tieniendo en cuenta el modelo de base de daos previamente creado para dar consistencia a los datos: respentando tipos de datos y longitud de los campos.

### Validación de la Solicitud de Filtros de Propiedades

A continuación se detallan las reglas y justificaciones de las validaciones implementadas para la solicitud de filtros de propiedades.

- **Name**:
  - **Regla**: Si se proporciona, no debe exceder los 300 caracteres.
  - **Justificación**: Se limita el tamaño del nombre de la propiedad para evitar problemas de almacenamiento y asegurar que la base de datos mantenga un formato consistente y manejable.

- **Address**:
  - **Regla**: Si se proporciona, no debe exceder los 400 caracteres.
  - **Justificación**: Se establece una longitud máxima para la dirección con el fin de evitar sobrecargar la base de datos y garantizar que la información se mantenga clara y accesible.

- **MinPrice**:
  - **Regla**: Si se proporciona, debe ser un valor positivo.
  - **Justificación**: Es importante que el precio mínimo sea positivo, ya que un valor negativo no tendría sentido en el contexto de propiedades y podría generar errores en el sistema.

- **MaxPrice**:
  - **Regla**: Si se proporciona, debe ser un valor positivo.
  - **Justificación**: Similar al precio mínimo, el precio máximo debe ser positivo para asegurar que las consultas sobre las propiedades sean válidas.

- **MinPrice y MaxPrice**:
  - **Regla**: Si se proporcionan ambos, el valor de MinPrice no puede ser mayor que el valor de MaxPrice.
  - **Justificación**: Es necesario garantizar que el filtro de precios sea lógico, es decir, el precio mínimo no puede ser mayor que el máximo, ya que esto generaría una inconsistencia en los resultados de la búsqueda de propiedades.

### Mensajes de Error

Si alguna de las validaciones anteriores no se cumple, se generan mensajes de error detallados, como:

- "The property filter request cannot be null."
- "The property name cannot exceed 3000 characters."
- "The property address cannot exceed 400 characters."
- "The minimum price must be a positive value."
- "The maximum price must be a positive value."
- "The minimum price cannot be greater than the maximum price."

Estos errores se agregan a un objeto `StringBuilder` para ser enviados como una respuesta de error en caso de que la solicitud no pase las validaciones, garantizando así que los filtros aplicados sean válidos y consistentes.

### Respuesta

La función devuelve `true` si no hay errores, lo que indica que la solicitud de filtro es válida. Si hay errores, devuelve `false` y se agregan mensajes de error descriptivos.


Clase **CreateUserCommandHandler**

<img width="708" alt="image" src="https://github.com/user-attachments/assets/c051a978-511f-41a7-9790-3529760134b2">

<img width="458" alt="image" src="https://github.com/user-attachments/assets/be6e2abe-774f-4418-8004-b2a7c4f69c21">


## 3. Proyecto de clases `Domain` (definiciones e implementaciones de reglas de negocio)
- Aquí es donde se define la lógica de negocio principal, separada de los detalles de implementación. Esto incluye **interfaces** que definen contratos de comportamiento y reglas de negocio independientes de cómo se implementan.
- **Vertical Slice** es clave aquí, ya que segmenta la lógica por funcionalidad (cada "slice" es una característica completa) para nuestro caso se segmenta por "casos de uso" ys que nuestro desarrollo se orienta al dominio del negocio, lo que facilita que cada parte de la aplicación crezca de manera autónoma, permitiendo iteraciones ágiles y un código más fácil de mantener.
- Este enfoque modular ayuda a reducir el acoplamiento y promueve **polimorfismo** y **inversión de dependencias**, dos principios de SOLID.
- 
![image](https://github.com/user-attachments/assets/68047791-4aac-4164-ada9-0e027a37d21d)

## 4. Proyecto de clases `Infrastructure` (implementación de repositorios)
- Esta capa se encarga de la persistencia de datos y la comunicación con otros servicios externos (como bases de datos o APIs externas). La **implementación de repositorios** está alineada con las interfaces definidas en el dominio.
- **Inversión de dependencias** (uno de los principios de SOLID) se aplica aquí porque la capa de aplicación y dominio dependen de **abstracciones** y no de implementaciones concretas. Esto permite cambiar la infraestructura (como el tipo de base de datos) sin afectar el dominio o la lógica de negocio.
  
![image](https://github.com/user-attachments/assets/837f737e-ba64-4827-a932-bda49e327f5e)



# Conclusión
La API **BFF Backend Million App** está diseñada para optimizar el acceso y gestión de propiedades, permitiendo consultas eficientes y adaptadas a las necesidades de las plataformas web y móviles. Con el uso de filtros y la posibilidad de consultar las propiedades más recientes, esta solución proporciona una manera efectiva de interactuar con los datos de propiedades y propietarios a través de un backend flexible y escalable.







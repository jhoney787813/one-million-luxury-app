
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




# BaseSolution - Aplicación de microservicio BASE. Utilizando Tecnología Docker Containers y .NET Core 2.1 Implementando patrón Domain Driven Design.
Es una solución base para aplicaciones arquitectónico de microservicios que implementa el patrón DDD para aquellos que quieren comenzar a desarrollar con tecnología .NET Core 2.1 y Docker.
## Capas del Patron Domain Driver Design.
Descripcion de las caracteristicas de las capas en una patron Domain Driver Design

## Descripcion grafica de las dependencias entre capas 
![Dependencia Entre Layer Patron DDD](https://github.com/JohanVillegas/BaseSolution/blob/master/img/DependenciaEntreLayerPatronDDD.png) 

## 1. Domain Model Layer
El modelo de dominio debe capturar las reglas, el comportamiento, el lenguaje de negocios y las restricciones del contexto delimitado o microservicio de negocio que representa.

### Descripcion grafica de la estructura basica de Domain Model Layer
![Descripcion de la capa del dominio](https://github.com/JohanVillegas/BaseSolution/blob/master/img/DomainModelLayerV2.png) 


### The Domain Entity pattern
Las entidades representan objetos del dominio y se definen principalmente por su **identidad**, **continuidad** y **persistencia** en el tiempo y no solo por los atributos que las componen.

  - *Las entidades de dominio deben implementar el comportamiento además de los atributos de datos*
  
  Una entidad de dominio DDD, debe implementar la lógica del dominio o el comportamiento relacionado con los datos de entidad.

  **Partes de una clases de entidad**
  - Propiedades que componen el almacenamiento de los datos **{ATRIBUTOS}**
  
    ```
    Ejemplo: Id, FirstName, etc...
    Los atributos que sea necesarios para el negocio.
    ```

  - Lógica de negocio y las operaciones **{MÉTODOS}**

    ```
    Ejemplo : Agregar un elemento, validar datos o cálculos matemáticos
    Los métodos se encarga de las invariable y las regla de la entidad.
    ```

### The Value Object pattern
Un objeto de valor es un objeto **sin identidad** conceptual que describe un aspecto de dominio. Se trata de objetos de los que se crea una instancia para representar elementos de diseño que solo interesan temporalmente, asociado a esto, otra caracteristica importante es que tienes que ser **inmutable**, es decir  cuando se construye el objeto, debe proporcionar los valores necesarios, pero no debe permitir que cambien durante la vigencia del objeto. 

### The Aggregate pattern
Es un **grupo de entidades y comportamientos** que se pueden tratar como una unidad coherente que tienen procesos que pueden controlar un área importante de funcionalidad.

### Repository Contract/Interface
Son los requisitos de infraestructura del modelo de dominio expresado en **interfaces**. Es decir, estas expresan qué repositorios debe implementar la capa de infraestructura y cómo.

### SeedWork
En nuestro Domain Entity pattern, existen código que puede estar repetido al comienzo del proyecto, para esos podemos utilizar una de nuestras mejores practica para ir unificando las clases y convirtiéndola en código reutilizable, es por ende que se utilizar un sección en el proyecto (carpeta llamada SeedWord), donde se va a ir ubicando todas clases reutilizables y personalizadas.

## Continuara ... Hasta aqui estariamos culminando la primera fase de la implementacion de esta capa. De igual forma se estara actualizando a medida que el proyecto vaya evolucionando.

## 2. Infrastructure Layer
En la Infraestructura esta encargada de realizar las operaciones de persistencia de datos, dicho esto es necesario resalta que la implementación esta basada en el marco Entity Framawork Core, estableciendo los Repositories, UnitOfWork con DbContext como base.

### Repositories

### UnitOfWork

### Context

### EntityConfiguration


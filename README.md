# BaseSolution - Aplicación de microservicio BASE. Utilizando Tecnología Docker Containers y .NET Core 2.1 Implementando patrón Domain Driven Design.
Es una solución base para aplicaciones arquitectónico de microservicios que implementa el patrón DDD para aquellos que quieren comenzar a desarrollar con tecnología .NET Core 2.1 y Docker.
## Capas del Patron Domain Driver Design.
Descripcion de las caracteristicas de las capas en una patron Domain Driver Design
![Patron DDD](https://github.com/JohanVillegas/BaseSolution/blob/master/img/ddd.png) 

## Domain Model Layer
El modelo de dominio debe capturar las reglas, el comportamiento, el lenguaje de negocios y las restricciones del contexto delimitado o microservicio de negocio que representa.

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

#### The Value Object pattern
Un objeto de valor es un objeto **sin identidad** conceptual que describe un aspecto de dominio. Se trata de objetos de los que se crea una instancia para representar elementos de diseño que solo interesan temporalmente. 

#### The Aggregate pattern
Es un grupo de entidades y comportamientos que se pueden tratar como una unidad coherente que tienen procesos que pueden controlar un área importante de funcionalidad.

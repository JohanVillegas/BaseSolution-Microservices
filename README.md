# BaseSolution - Aplicación de microservicio BASE. Utilizando Tecnología Docker Containers y .NET Core 2.1 Implementando Domain Driven Design.
Es una solución base para aplicaciones arquitectónico de microservicios que implementa DDD para aquellos que quieren comenzar a desarrollar con tecnología .NET Core 2.1 y Docker.
## Capas del Domain Driver Design.
Descripcion de las caracteristicas de las capas en una Domain Driver Design

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
La capa Infraestructura esta encargada de realizar las operaciones de persistencia de datos, dicho esto es necesario resalta que la implementación esta basada en el marco Entity Framawork Core, estableciendo los Repositories, UnitOfWork con DbContext como base.

### Descripcion grafica de la estructura basica de Infrastructure Layer
![Descripcion de la capa del dominio](https://github.com/JohanVillegas/BaseSolution/blob/master/img/InfrastructureLayerV1.png) 

### Repositories
Los repositorios son clases o componente que encapsulan la lógica necesaria para tener accesos a orígenes de datos,
dicho esto cada repositorio implementa una interfaz de los Aggregare-Root, esto quiere decir que cada Aggregate posee un repositorio especificando sus implementaciones que se encuentra en la capa de dominio.

### UnitOfWork
Una unidad de trabajo se conoce como una sola transacción que implica varias operaciones de inserción, actualización o eliminación. En otras palabras, las transacciones de inserción, actualización o eliminación se administran en una única transacción. Esto es más eficaz que el control de varias transacciones de base de datos de una manera profusa. 

### DbContext
Es una representación de una sesión con la base de datos y se puede usar  para el guardado y consultas de las entidades, esta funcionalidad es una combinación de los patrones UnitOfWork y Repositoy, en nuestro caso va a realizar el guardado y configuración de nuestras entidades que van a estar alojadas en una base de datos.

### EntityConfiguration
Es donde van a estar agrupadas las configuraciones de cada entidad, existen diferentes formas de realizar las configuraciones necesarias para las entidades de un proyecto, en este caso vamos a utilizar Fuent API, que es una forma práctica de cambiar la mayoría de convenciones y asignaciones en el nivel de infraestructura de la persistencia de datos, por lo que el modelo de entidad estará limpio y desacoplado de la infraestructura de persistencia.

## Continuara ... Hasta aqui estariamos culminando la primera fase de la implementacion de esta capa. De igual forma se estara actualizando a medida que el proyecto vaya evolucionando.

## 3. Application Layer
En la capa de aplicación se destacan las solicitudes y consultas por medio de **Command**, CommandHandler, **Query** y QueryHandler, que necesita la aplicación para su **presentación**, además de **validaciones de entrada** para su respectiva funcionalidades, todo esto con una libreria que nos permite tener una cominicacion sin dependencia entre ellas **MediatR**. 

### Descripcion grafica de la estructura basica de Application Layer
![Descripcion de la capa del dominio](https://github.com/JohanVillegas/BaseSolution/blob/master/img/ApplicationLayerV1.png) 

### Commands
#### Class Commands
Básicamente, la clase de comando contiene todos los datos que se necesitan para llevar a cabo una transacción empresarial mediante los objetos de modelo de dominio. Por tanto, los comandos son simplemente las estructuras de datos que contienen datos de solo lectura y ningún comportamiento.
#### Class Commands Handlers
Un controlador de comandos recibe un comando y obtiene un resultado del agregado que se usa (de dominio). El resultado debe ser la ejecución correcta del comando, o bien una excepción. En el caso de una excepción, el estado del sistema no debe cambiar.

- **Normalmente, el controlador de comandos realiza estos pasos:**
  - Recibe el objeto de comando, como un DTO (desde el mediador u otro objeto de infraestructura).
  - Valida que el comando sea válido (si no lo hace el mediador).
  - Crea una instancia de la instancia de raíz agregada que es el destino del comando actual.
  - Ejecuta el método en la instancia de raíz agregada y obtiene los datos necesarios del comando.
  - Conserva el nuevo estado del agregado en su base de datos relacionada. Esta última operación es la transacción real.

### Queries
#### Class Queries
La clase de consultas contiene todos los datos que se necesitan para llevar a cabo las series de filtros o condiciones necesarias para la consulta empresarial mediante los objetos de modelo de dominio. Por tanto, las consultas son simplemente las estructuras de datos que contienen datos de solo lectura y ningún comportamiento.
#### Class Queries Handlers
Un controlador de consulta recibe una consulta y obtiene un resultado del agregado que se usa (de dominio). en este caso el estado del sistema no debe ser afectado ya que simplemente estamos realizando consultas a nuestro persistencia.

### Models
### Validations

# Actividad 05 - Modelado de Base de Datos y Scaffolding

**Integrantes:**
* Benjamin Sulca Huaman
* Jordy Farlee Gomez Venero
* Sebastian Alcocer Flores
* Alexander Vasquez Montez

## Desarrollo de la Actividad

### Pasos 1 y 2: Análisis y Modelo de Base de Datos
Revisamos los requerimientos del Caso 5 para entender cómo gestionar la producción, el inventario y el control de calidad. Identificamos las tablas principales (Productos, MateriasPrima, OrdenesProduccion, InspeccionesCalidad y Proveedore). Diseñamos la base de datos en PostgreSQL asegurándonos de configurar correctamente las llaves primarias y foráneas para mantener la integridad referencial.

### Paso 3: Proyecto en .NET y Scaffolding
Creamos un proyecto Web API utilizando .NET 10.0. Como decidimos trabajar con PostgreSQL, instalamos los paquetes de Npgsql para Entity Framework Core. Usando el enfoque Database-First, ejecutamos el comando de scaffold en la terminal de Rider para generar de forma automática nuestro ApplicationDbContext y todas las clases a partir de la base de datos.

### Paso 4: Revisión de las Relaciones
Revisamos la carpeta Models que generó el comando. Comprobamos que las relaciones de la base de datos se mapearon correctamente al código (por ejemplo, verificamos las colecciones `ICollection` para las relaciones de uno a muchos) y validamos que el DbContext tuviera las configuraciones correctas de Fluent API.

### Paso 5: Control de Versiones y Arquitectura
Trabajamos el proyecto de forma colaborativa a través de GitHub, donde cada integrante registró sus commits. Para organizar el código y prepararlo para escalar, armamos una estructura en capas:
* Controllers: Para exponer los endpoints de la API.
* Models: Las clases generadas por el scaffold.
* Repositories: Creamos una interfaz genérica asíncrona (IGenericRepository) para estandarizar las consultas a la base de datos.
* Services: Capa para manejar la lógica del negocio.

## Paso 6: Reflexión Final

Como grupo, nuestra principal impresión del proceso es que realizar un buen modelado de base de datos desde el inicio facilita enormemente el desarrollo posterior. Lo que más aprendimos durante esta actividad fue ver cómo la herramienta de .NET (Entity Framework Core) logra leer todas las reglas que pusimos en PostgreSQL y las convierte automáticamente en clases de C#. Esto nos demostró el valor real del enfoque Database-First para ahorrar tiempo escribiendo código repetitivo.

En cuanto a los desafíos enfrentados al trabajar con el modelo y la herramienta de .NET, destacamos los siguientes:
* **El reto con la herramienta .NET:** La configuración inicial fue el mayor obstáculo. Al salir del entorno tradicional de SQL Server para usar PostgreSQL, tuvimos que investigar qué paquetes de NuGet exactos instalar y cómo estructurar la cadena de conexión y el comando de scaffold para que la herramienta de .NET lo reconociera.
* **El reto con el modelo:** Al revisar el código generado, tuvimos que ser cuidadosos analizando cómo Entity Framework nombró a las tablas y a las propiedades de navegación para asegurarnos de que la lógica de negocio no se viera afectada al momento de armar los repositorios.
* **El reto colaborativo:** Trabajar los 4 en el mismo repositorio de GitHub requirió mucha coordinación. Tuvimos que avisarnos antes de hacer pull o push para evitar conflictos de código, especialmente al momento de estructurar las carpetas nuevas de la arquitectura.

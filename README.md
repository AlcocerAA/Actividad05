# Actividad 05: Scaffolding y Modelado de Base de Datos en .NET 8

Repositorio grupal para el desarrollo de la Actividad 05, enfocada en el Caso 5: Empresa de Fabricación (Gestión de Producción y Control de Calidad).

## Institución
Tecsup - Diseño y Desarrollo de Software

## Integrantes del Grupo
* Benjamin Sulca Huaman
* Jordy Farlee Gomez Venero
* Sebastian Alcocer Flores
* Alexander Vasquez Montez

## Desarrollo de la Actividad
Para este trabajo desarrollamos el Caso 5, cuyo objetivo es gestionar el ciclo de producción de una planta. Siguiendo las instrucciones de la actividad, dividimos el trabajo en los siguientes pasos:

1. Análisis y Modelado: Identificamos las entidades necesarias (Órdenes de Producción, Inspecciones de Calidad, Materias Primas, Productos y Proveedores) y creamos el modelo relacional en PostgreSQL, asegurando la integridad de los datos mediante llaves primarias y foráneas.
2. Implementación en .NET 8: Creamos la estructura base del proyecto Web API.
3. Scaffolding: Utilizamos el enfoque Database-First ejecutando el comando de Entity Framework Core para generar automáticamente el DbContext y las entidades a partir de nuestra base de datos en Postgres.
4. Verificación de Relaciones: Revisamos las clases generadas en la carpeta Models para comprobar que las relaciones de uno a muchos y las restricciones se reflejaran correctamente en el código C#.
5. Trabajo Colaborativo en GitHub: Organizamos el código, manejamos el control de versiones y nos aseguramos de que todos los integrantes registren sus aportes mediante commits.

## Tecnologías Utilizadas
* Framework: .NET 8 (Web API)
* Base de Datos: PostgreSQL
* ORM: Entity Framework Core (Npgsql)
* Entorno de Desarrollo: JetBrains Rider
* Control de Versiones: Git y GitHub

## Reflexión del Grupo (Paso 6)
Hacer esta actividad nos ayudó a entender lo importante que es diseñar bien las tablas y las relaciones desde el gestor de base de datos antes de programar. Al ejecutar el comando scaffold, pudimos ver cómo todo ese diseño previo se transforma automáticamente en clases de C# y en las configuraciones del DbContext (Fluent API), lo cual ahorra muchísimo tiempo y evita errores manuales.

Dificultades que encontramos:
* Nos tomó un poco de tiempo configurar los paquetes al principio porque decidimos trabajar con PostgreSQL en lugar de SQL Server, por lo que tuvimos que investigar y adaptar el comando y la cadena de conexión.
* Sincronizarnos usando Git para no chancarnos los archivos al hacer push y pull. Al final logramos organizarnos para que cada uno pueda descargar los cambios, hacer su commit y tener el repositorio actualizado sin perder el trabajo del otro.

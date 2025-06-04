# MusicRadio

Descripción:

Arquitectura de la aplicación MVC, se crea una sola solución para practicidad del ejercicio. En el mundo real la carpeta Infrastructure y Services se pueden crear como una capa o solución de libreria de clases, para desacoplar
el código.

Carpeta Controllers:
Se alojan los controladores de la aplicación.

Carpeta Models:
Se alojan los modelos o entidades de la aplicación, estos corresponden a su vez a las tablas de la DB.

Carpeta Views:
Se alojan las vistas de la aplicación, el frontend de la app. 

Carpeta Services:
Esta carpeta aloja todos lo Services de la aplicación, con el fin de agruparlos. cada service implementa la logica de cada entidad, el cual implementa su respectiva interfaz. Se podria definir como logica de negocio

Carpeta Infrastructure:
Esta Carpeta aloja los repositorios de la aplicación, con el fin de agruparlos. Se hace uno del patrón repositorio, para encapsular el comportamiento de almacenamiento, obtención y busqueda de las entidades. Esto nos ayuda
a centralizar la logica de acceso a los datos y su configuración.

Carpeta Dto:
Se usa para almacenamiento de los dto que seran usados, en la tranferencia de datos entre front y back, en estas podemos implementar validaciones con librerias eje:fluentvalidation. 

 
Carpeta Extentions:
Se usa para crear clases extensiones de configuración, por ejemplo para autenticación con JWT, Cognito, u otro libreria externa.


1. Ejecutar script de base de datos MusicRadio.sql que se encuentra en la ruta base del proyecto
2. Clonar el proyecto y actualizar referencias de Nuget
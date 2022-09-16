# DPRN3_U1_EA_JHRM
Uber-like: Calcula distancia entre dos coordenadas, recorrido en kms y costo de recorrido de un viaje.

Programa por consola que calcula la distancia en kilómetros del viaje, la dirección cardinal, el tiempo estimado del recorrido, hora estimada de llegada y el costo del viaje. 
Con base a unas coordenadas y hora de salida. Los registros se almacenan en una BD local.

## Ventana de consola
Manipulación por consola

<p align="center">
  <img src="https://user-images.githubusercontent.com/38293508/190550198-1782af57-d451-44ad-837c-4a5abd63024a.png"/>
</p>


## Base de datos
La conexión con la base de datos local está configurada con SQL Server. Si requiere otro manejador, se debe reconfigurar de acuerdo a dicho manejador. 
Para que los registros se carguen exitosamente, hay que crear la tabla de acuerdo al siguiente esquema:

<p align="center">
  <img src="https://user-images.githubusercontent.com/38293508/190550290-9791e02e-14df-497a-adf0-332af0feb42f.png"/>
</p>


## Versiones y dependencias
* System.Data.SqlClient
* Visual Studio Community 2019 16.11.19
* Geolocation

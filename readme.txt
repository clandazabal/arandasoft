--======================================================================================================
-- Instrucciones de Instalación: BACKEND DEVELOPER .NET - ArandaSoftware
--======================================================================================================
1. Puede descargar el códio ya sea desde GitHub o desde el OneDrive
	Drive : https://1drv.ms/u/s!Aij7IvsogLYm9ia6GYKk_vouMoWB?e=Tlfwb0
	Github: https://github.com/clandazabal/arandasoft.git
2. Después de descargado el código fuente ejecute el archivo ArandaSoft.Test.sln con Visual Studio 2019 o Superior.
3. Valide que todas las librerias y paquetes Nuget se hayan cargado en su totalidad. 
4. Validar que el Proyecto ArandaSoft.Test.API esté configurado como proyecto de inicio.
5. Configuración de la base de datos:
   La cadena de conexión está configurada para tomar la instancia local del equipo con autenticación de windows.  
   Si desea cambiar la instancia del servidor de base de datos puede modificar la cadena de conexión [ArandaSoftTestConnection] en el Web.config del proyecto ArandaSoft.Test.API
6. Ejecutar la aplicación desde Visual Studio (F5)

Importante!!!
* Cuando la aplicación se ejecuta por primera vez, la base de datos es construida através de EntityFramework por CodeFirst.
  Adicionalmente, se crean datos paramétricos:
	- 5 registros en la tabla ProductCategory
  y se crean registros de productos demo para pruebas:
	- 9 registros en la tabla Product
--======================================================================================================

Contact:
Email: carloslandazabal@hotmail.com
Móvil & WhatsApp: +573042505207 
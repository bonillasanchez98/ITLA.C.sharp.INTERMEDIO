# ITLA C# INTERMEDIO CONVERSOR DE TEMPERATURAS
Esta es una aplicacion de consola de C# donde se hara conversiones de formas implicita de las temperatueas Fahrenheit a Celsius y viceversa.

## Estructura del proyecto
En este proyecto hay dos clases publicas creadas. **TemperaturaCelsius**, **TemperaturaFahrenheit** y la clase **Program**, que es donde se encuentra el metodo Main el cual sera el punto de acceso a la aplicacion.<br>
![image](https://github.com/user-attachments/assets/4c66963c-b8ae-44b1-8a97-bc96462d872f)

## Clase TemperaturaCelsius
- ### La formula para convertir de grados Fahrenheit a Celsius: 
![image](https://github.com/user-attachments/assets/54f7bd34-9870-44d3-8656-c3eb1420b813)
### Captura en codigo:
Esta clase cuenta con un metodo **public** de tipo **void** llamado **ConvertirCelsius** que se encargara de realizar la operacion para la conversion de grado.<br>
>**Nota:** Los grados a convetir son estaticos y se almacenan en una variable de tipo **double**, este caso en la variable **fahrenheit** con el valor de **73**.<br>
![image](https://github.com/user-attachments/assets/ab4f21f4-4d72-4a91-a0d4-e9031a8f8f18)

## Clase TemperaturaFahrenheit
- ### La formula para convertir de grados Celsius a Fahrenheit:
![image](https://github.com/user-attachments/assets/340cb1c3-0c6d-44b7-a8ed-fb32ef7bdaa3)
### Captura en codigo:
Esta clase cuenta con un metodo **public** de tipo **void** llamado **ConvertirFahrenheit** que se encargara de realizar la operacion para la conversion de grado.<br>
>**Nota:** Los grados a convetir son estaticos y se almacenan en una variable de tipo **double**, este caso en la variable **celsius** con el valor de **23**.<br>
![image](https://github.com/user-attachments/assets/a5f64ac9-f679-4027-9585-26b935b684f5)

## Clase Program
En la clase program se crean dos objetos de cada una de la clases anteriores y se almacenan en una variable, **fahrenheit** para **TemperaturaFahrenheit** y **celsius** para **TemperaturaCelsius**. Se accede a los metodos que convertiran las temperaturas respectivas a traves del operador punto.<br>
![image](https://github.com/user-attachments/assets/ab4b9dcf-f446-4df9-9d78-f058727ca53d)
## Resultado
![image](https://github.com/user-attachments/assets/0cc7d505-779d-4c7b-9f7f-ab809ad2f42e)

# ITLA C# INTERMEDIO CONVERSOR DE DISTANCIAS
Esta es una aplicacion de consola de C# donde se hara conversiones de formas implicita de distancias Kilometros a Millas y viceversa.
## Estructura del proyecto
En este proyecto hay dos clases publicas creadas. **Kilometros**, **Millas** y la clase **Program**, que es donde se encuentra el metodo Main el cual sera el punto de acceso a la aplicacion.<br>
![image](https://github.com/user-attachments/assets/9e0269a3-df40-42a2-9c95-1699236f2590)


## Clase Kilometros
- ### La formula para convertir de Millas a Kilometros: 
![image](https://github.com/user-attachments/assets/c1372843-1da0-40fa-88d2-c4b09dad65b3)
### Captura en codigo:
Esta clase cuenta con un metodo **public** de tipo **void** llamado **ConvertirKM** que se encargara de realizar la operacion para la conversion a Kilometros.<br>
>**Nota:** La distancia o millas a recorrer sera un valor estaticos y se almacenan en una variable de tipo **double**, este caso en la variable **millas** con el valor de **150**.
>Ademas, la constante de tipo **double** esta almacenando el valor fijo **1.60934**.<br>
![image](https://github.com/user-attachments/assets/d7ad29ce-4148-43b9-bccc-21901c31e8e9)

## Clase Millas
- ### La formula para convertir de Kilometros a Millas:
![image](https://github.com/user-attachments/assets/4e31c91e-f61d-4d8e-a468-883973b8088a)
### Captura en codigo:
Esta clase cuenta con un metodo **public** de tipo **void** llamado **ConvertirMillas** que se encargara de realizar la operacion para la conversion a Millas.<br>
>**Nota:** La distancia o kilometros a recorrer sera un valor estaticos y se almacenan en una variable de tipo **double**, este caso en la variable **km** con el valor de **150**.
>Ademas, la constante de tipo **double** esta almacenando el valor fijo **0.621371**.<br>
![image](https://github.com/user-attachments/assets/f9feb27a-9ad1-463f-9688-ed9e1e4e0d69)

## Clase Program
En la clase program se crean dos objetos de cada una de la clases anteriores y se almacenan en una variable, **km** para la clase **Kilometros** y **millas** para la clase **Millas**.
Se accede a los metodos que convertiran las temperaturas respectivas a traves del operador punto.<br>
![image](https://github.com/user-attachments/assets/13600297-a598-42b9-9eb7-463721ca7fef)

## Resultado
![image](https://github.com/user-attachments/assets/96abc7c8-05ad-420b-864c-086269fc0f6f)

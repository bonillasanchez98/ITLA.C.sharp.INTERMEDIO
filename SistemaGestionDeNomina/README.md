# ✨Sistema de Gestión de Nómina por Categoría de Empleados✨
## 📄Sobre el proyecto
Una empresa realiza pagos semanales a sus empleados, quienes se dividen en cuatro categorías:
empleados asalariados, que reciben un sueldo fijo semanal sin considerar las horas trabajadas;
empleados por hora, que ganan según las horas trabajadas y reciben pago adicional por horas extras si exceden las 40 horas;
empleados por comisión, que obtienen un porcentaje de sus ventas; y empleados asalariados con comisión, que reciben un salario base más una comisión por ventas.
En este ciclo de pago, la empresa ha decidido otorgar una bonificación del 10% sobre el salario base a los empleados asalariados con comisión.
La empresa quiere desarrollar una aplicación que le permita gestionar la nómina según el requerimiento.

## Diagrama de Clases UML
![image](https://github.com/user-attachments/assets/14124dff-0b7b-45e1-964b-ff51d1ce99d7)

## 🚀Características
- ### 💾 Aplicación de consola.
- ### ↔️ Diagrama de clases.
- ### 👨‍👦 Herencia.
- ### 💊 Encapsulamiento.
- ### 🎭 Polimorfismo.

## ✔️Requisitos técnicos.
- Calcular los sueldos de las distintas categorías de empleados. Así sean sueldo fijo, por comisión u horas trabajadas.
- A la categoría de empleados asalariados con comisión se le debe de aplicar un bono.

## 🏗️ Componentes
### Estructura del proyecto
![image](https://github.com/user-attachments/assets/baf0de3b-4cf5-4163-8d2c-06c56f4a9aa8)

#### Clase Empleado
>Esta es una clase abstracta con algunas de las propiedades públicas, junto con sus metodos get y set. Cuenta con dos constructores, uno vacío
> y otro con todos los argumentos. Luego se crea el método abstracto **CalcularPago()** tipo void, donde se implementará la lógica del pago de los distintos empleados.
> Y por último se implementa un método virtual **MostrarInformacion()** de tipo void, donde este mostrara por consola las propiedades básicas de cada empleado.

![image](https://github.com/user-attachments/assets/5f447caa-29ca-47c8-aa49-dbb0564f27d2)

#### Clase Empleado Asalariado
>Esta clase hereda de la clase padre **Empleado** e implementa su método abstracto, donde solo mostrara por consola el sueldo fijo ingresado.

![image](https://github.com/user-attachments/assets/c944ed43-2acb-4573-b8b3-491b928c0f84)

#### Clase Empleado por hora
> Esta clase cuenta con dos propiedades, una publica de tipo int que son las horas trabajadas y otra privada tipo double, que será el sueldo del empleado.
> En esta clase se debe de tomar en cuenta que si el empleado excede las 40 horas trabajas, recibe un pago extra. Dentro del método CalcularPago se almacena en una variable
> booleana las horas trabajadas **menores a 40 horas**, y debajo se encontrará el sueldo, que se calculara las horas trabajadas por seis, que serán los días de la semana que este
> tipo de empleados trabajara. Se evaluará con una condición, si el empleado no hizo horas extra, entonces se mostrará las horas trabajadas y su sueldo, de caso contrario se mostrará
> las horas trabajas, el sueldo mas el pago extra.

![image](https://github.com/user-attachments/assets/978de005-7c87-4af8-9f5a-e2aa9939bc17)

#### Clase Empleado por Comision
> Estos tipos de empleados reciben su sueldo según un porcentaje del **5%** de las ventas totales que realicen, por ende, cuanta con una propiedad publica de tipo double **(_VentasTotales)**
> que serán las ventas totales que realice, y otra privada de tipo double **(_Sueldo)** que será el sueldo. En el método CalcularPago de estos tipos de empleado el sueldo será las ventas
> totales por 0.05, que es equivalente al 5% de las ventas. Y luego se mostrará por consola el total de ventas y el sueldo ganado.

![image](https://github.com/user-attachments/assets/7ba95cab-39b0-492d-930b-6af8ad2e3ec5)

#### Clase Empleado Asalariado con Comision
> Esta categoría de empleados cuanta con dos propiedades publicas de tipo double **(_Sueldo y _VentasTotales)**, ya que parte de su sueldo está compuesto por estas. Dentro del método **CalcularPago**,
> se crea una variable de tipo double llamada bono, la cual será igual al sueldo por la **bonificación del 10%** de la empresa. Otra variable de tipo double llamada comisionPorVentas, que será igual al
> 5% de las ventas totales que tenga el empleado y el sueldo total, que sería la suma del sueldo con el bono más la comisión por las ventas. Y por último, se mostrará en consola el sueldo, la bonificación,
> las ventas totales, la comisión por las ventas y el sueldo total.

![image](https://github.com/user-attachments/assets/01fbc4d2-8c3a-40ab-a516-089628700917)

#### Clase Program
> En esta clase se encuentra el método **Main**, el cual será el punto de entrada a la aplicación. En este método se construyen los objetos de cada una de las categorías de empleados, luego de la creación de cada objeto se
> llama al método **CalcularPago** y luego al método virtual **MostrarInformacion**.

![image](https://github.com/user-attachments/assets/d72e7f1c-059b-4234-b246-76f38e7ae284)

#### Diagrama de clases del proyecto
![image](https://github.com/user-attachments/assets/02e69b14-a994-421c-8801-aba5e71f6681)

## 📷 Demo
![image](https://github.com/user-attachments/assets/871034d2-34cc-4c1c-b7f4-9ab29304f10c)

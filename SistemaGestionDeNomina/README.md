# ✨Sistema de Gestión de Nómina por Categoría de Empleados✨
## 📄Sobre el proyecto
Una empresa realiza pagos semanales a sus empleados, quienes se dividen en cuatro categorías:
empleados asalariados, que reciben un sueldo fijo semanal sin considerar las horas trabajadas;
empleados por hora, que ganan según las horas trabajadas y reciben pago adicional por horas extras si exceden las 40 horas;
empleados por comisión, que obtienen un porcentaje de sus ventas; y empleados asalariados con comisión, que reciben un salario base más una comisión por ventas.
En este ciclo de pago, la empresa ha decidido otorgar una bonificación del 10% sobre el salario base a los empleados asalariados con comisión.
La empresa quiere desarrollar una aplicación que le permita gestionar la nómina según el requerimiento.

## Diagrama de Clases UML
![image](https://github.com/user-attachments/assets/f6cfe338-4560-4a1d-bf07-cf3795bfbca1)

## 🚀Características
- 💾 Aplicación de consola.
- ↔️ Diagrama de clases.
- 👨‍👦 Herencia.
- 💊 Encapsulamiento.
- 🎭 Polimorfismo.

## ✔️Requisitos técnicos.
- Calcular los sueldos de las distintas categorías de empleados. Así sean sueldo fijo, por comisión u horas trabajadas.
- A la categoría de empleados asalariados con comisión se le debe de aplicar un bono.

## 🏗️ Componentes
### Estructura del proyecto
![image](https://github.com/user-attachments/assets/b2795d27-9d0a-4643-bfbb-fc12276caab5)

#### Clase Empleado
![image](https://github.com/user-attachments/assets/67f319a8-bdbb-4263-95e5-7a6c2e78cb66)

#### Clase Empleado Asalariado
![image](https://github.com/user-attachments/assets/0ea519fa-a665-475a-a089-44e1a16d043f)

#### Clase Empleado por hora
![image](https://github.com/user-attachments/assets/76e4ebdc-ebfe-41e7-8ad2-1b95f9d53e7a)

#### Clase Empleado por Comision
![image](https://github.com/user-attachments/assets/0197a334-ff5c-4cfd-8dce-d087b3aebe09)

#### Clase Empleado por Comision Normal
![image](https://github.com/user-attachments/assets/aa57fb92-2fae-4a4e-a973-8e41dcf3ee36)

#### Clase Empleado Asalariado con Comision
![image](https://github.com/user-attachments/assets/2d328595-9d45-402c-aa6b-6ff3ba87b3ce)

#### Clase Program
> En esta clase se encuentra el método **Main**, el cual será el punto de entrada a la aplicación.
> Aquí se construyen los objetos de cada una de las categorías de empleados,
> luego de la creación de cada objeto se llama a los métodos **CalcularPago** y **MostrarInformacion**.
![image](https://github.com/user-attachments/assets/05f821ec-bc8e-4b5e-8acd-e0fe50771766)
![image](https://github.com/user-attachments/assets/c3c5c46d-9b7a-4427-a055-4c7d5f6e7e7a)

#### Diagrama de clases del proyecto
![image](https://github.com/user-attachments/assets/02df8bc3-69bb-475b-a634-2970f1cce8c8)

## 📷 Demo
![image](https://github.com/user-attachments/assets/be7c78b5-2eda-4f0c-bebd-87079a8aa959)

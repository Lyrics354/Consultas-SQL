# Laboratorio # [Número] – Resolución de Problemas en C# y SQL

**Fecha:** 29/09/2026

## Contenido del Repositorio

Este laboratorio reúne cinco ejercicios de programación trabajados en clase:

1. **3 consultas SQL** sobre una base de datos `universidad` (SELECT con filtros, JOIN y funciones de agregado).
2. **Diccionario** en C# con las funciones **Insertar** y **Actualizar**.
3. **Factorial** calculado con **recursividad**.
4. **Sobrecarga de métodos** (mismo nombre, distinta firma).
5. **Estadísticas** con contadores: frecuencia de cada cara al lanzar un dado 6000 veces.

Los ejercicios de C# se ejecutan desde un único programa de consola con menú; las consultas SQL están en la carpeta `sql/`.

## Tecnologías Utilizadas

- **Lenguaje / Framework:** C# con .NET 8 (aplicación de consola)
- **Base de datos:** MySQL / MariaDB
- **Herramientas:** Git, Visual Studio / Visual Studio Code, WampServer (o XAMPP) / MySQL Workbench

## Capturas de Pantalla y Problemas

### 1. Consultas SQL

Base de datos con tres tablas: `estudiantes`, `cursos` y `matriculas` (script en `sql/01_crear_base_datos.sql`).

**Consulta 1 – SELECT con WHERE y ORDER BY:** lista los estudiantes de Ingeniería de Software ordenados por apellido.

![Consulta SQL 1](capturas/05_sql_consulta1.png)

**Consulta 2 – INNER JOIN de tres tablas:** muestra la nota de cada estudiante en cada curso, de mayor a menor.

![Consulta SQL 2](capturas/05_sql_consulta2.png)

**Consulta 3 – GROUP BY / HAVING con funciones de agregado:** cuenta los estudiantes y calcula el promedio, la nota máxima y la mínima por curso, mostrando solo los cursos con promedio ≥ 70.

![Consulta SQL 3](capturas/05_sql_consulta3.png)

### 2. Diccionario (funciones Insertar / Actualizar)

Se usa un `Dictionary<int, string>` (ID → nombre del estudiante):

- `Insertar(id, nombre)`: agrega el registro solo si la clave **no existe** (usa `ContainsKey`); si ya existe, muestra un error y devuelve `false`.
- `Actualizar(id, nuevoNombre)`: modifica el valor solo si la clave **existe**; si no, muestra un error y devuelve `false`.

![Diccionario](capturas/01_diccionario.png)

### 3. Factorial → Recursividad

El método `Calcular(long numero)` se llama a sí mismo:

- **Caso base:** si `numero <= 1` devuelve `1`.
- **Paso recursivo:** `numero * Calcular(numero - 1)`.

Se imprime el factorial de 0 a 10.

![Factorial recursivo](capturas/02_factorial_recursivo.png)

### 4. Sobrecarga de métodos

La clase `SobreCarga` declara varios métodos con el mismo nombre y distinta firma. El compilador elige cuál ejecutar según los argumentos:

- **Por tipo:** `Cuadrado(int)` y `Cuadrado(double)`.
- **Por número de parámetros:** `Sumar(int, int)` y `Sumar(int, int, int)`.
- **Por orden de parámetros:** `Describir(string, int)` y `Describir(int, string)`.

![Sobrecarga de métodos](capturas/03_sobrecarga_metodos.png)

### 5. Estadísticas (frecuencia de un dado)

Con `Random.Next(1, 7)` se simulan 6000 lanzamientos de un dado. Un `switch` incrementa el contador de la cara obtenida (`frecuencia1` … `frecuencia6`). Al final se muestra la frecuencia y el porcentaje de cada cara, la más y la menos frecuente, y la frecuencia esperada (1000). Como los números son aleatorios, cada ejecución da resultados distintos.

![Estadísticas del dado](capturas/04_estadisticas_dado.png)

## Estructura de Carpetas o Directorios

```plaintext
Laboratorio/
├── 01-Consultas-SQL/
│   └── consultas.sql
├── 02-Diccionario/
├── 03-Sobrecarga-Contadores/
├── 04-Sobrecarga-Metodos/
├── 05-Sobrecarga-Recursividad/
└── README.md                         # Documentación del proyecto
```

## Instrucciones de Ejecución / Uso

### Programa en C#

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/<usuario>/Laboratorio-CSharp.git
   cd Laboratorio-CSharp
   ```
2. **Configurar el entorno local:** instalar el [SDK de .NET 8](https://dotnet.microsoft.com/download) (o abrir `Laboratorio.sln` en Visual Studio).
3. **Ejecutar el comando de arranque:**
   ```bash
   dotnet run --project src/Laboratorio
   ```
   Se abre un menú para elegir el ejercicio. También se puede ejecutar uno directamente:
   ```bash
   dotnet run --project src/Laboratorio -- 1   # Diccionario
   dotnet run --project src/Laboratorio -- 2   # Sobrecarga-Contadores
   dotnet run --project src/Laboratorio -- 3   # Sobrecarga-Metodos
   dotnet run --project src/Laboratorio -- 4   # Sobrecarga-Recursividad
   ```

### Consultas SQL

1. Iniciar MySQL (por ejemplo, desde WampServer).
2. Crear la base de datos y cargar los datos:
   ```bash
   mysql -u root -p < sql/01_crear_base_datos.sql
   ```
3. Ejecutar las consultas:
   ```bash
   mysql -u root -p --table < sql/02_consultas.sql
   ```
   También se pueden abrir los archivos `.sql` en phpMyAdmin o MySQL Workbench y ejecutarlos allí.

## Autor y Contexto

- **Nombre:** Wilson Wu
- **Institución:** Universidad Tecnológica de Panamá (UTP)
- **Profesora:** Ing. Irina Fong
- **Fecha de Realización:** 29/09/2026

## Referencias

- Presentación *Declaración de métodos sobrecargados* – Ing. Irina Fong.
- Práctica *Resolución de Problemas: Frecuencias (Contadores), Sobrecarga de Métodos, Recursividad*.
- [Documentación de C# – Microsoft Learn](https://learn.microsoft.com/es-es/dotnet/csharp/)
- [Clase Dictionary<TKey,TValue> – Microsoft Learn](https://learn.microsoft.com/es-es/dotnet/api/system.collections.generic.dictionary-2)
- [Manual de referencia de MySQL](https://dev.mysql.com/doc/refman/8.0/en/)

# Laboratorio en Clases – Resolución de Problemas en C# y SQL

**Fecha:** 29/09/2026

## Contenido del Repositorio

Este laboratorio reúne cinco ejercicios de programación trabajados en clase:

1. **3 consultas SQL** Explica brevemente que el proyecto demuestra vulnerabilidades de inyección SQL y operaciones CRUD sobre una tabla productos.
2. **Diccionario** en C# con las funciones **Insertar** y **Actualizar**.
3. **Factorial** calculado con **recursividad**.
4. **Sobrecarga de métodos** (mismo nombre, distinta firma).
5. **Estadísticas** con contadores: frecuencia de cada cara al lanzar un dado 6000 veces.

## Tecnologías Utilizadas

- **Lenguaje / Framework:** C# con .NET 8 (aplicación de consola)
- **Base de datos:** MySQL / productosdb
- **Herramientas:** Git, Visual Studio / Visual Studio Code, WampServer (o XAMPP) / MySQL Workbench

## Capturas de Pantalla y Problemas

### 1. Consultas SQL

**Causa común:**
todos funcionan porque la aplicación concatena la entrada del usuario directamente en la consulta sin validarla.

**Solución / mitigación:**
usar consultas parametrizadas (prepared statements), validación de entradas, principio de mínimo privilegio en el usuario de la BD, y nunca mostrar errores SQL al usuario final.

**Clasificación:**
el #1 es in-band, el #2 es blind/inferencial, el #3 es una técnica auxiliar que puede acompañar a cualquiera.

**Contexto real:**
la inyección SQL lleva años en el Top 10 de OWASP como una de las vulnerabilidades más críticas en aplicaciones web.

**Consulta 1 – Bypass con OR '1'='1'** 

Devuelve todos los registros ignorando el filtro.
SELECT * FROM productos WHERE nombre = '' OR '1'='1';
Es el ejemplo más clásico de inyección SQL. Se aprovecha de que '1'='1' siempre es verdadero, así que la condición WHERE deja de filtrar y devuelve toda la tabla.
Simula el caso de un login o buscador donde el atacante mete ' OR '1'='1 en un campo de texto para saltarse la autenticación o la restricción.
Es una inyección in-band (basada en resultados): el atacante ve directamente los datos robados en la respuesta.
Riesgo principal: fuga masiva de información (todos los registros expuestos).

<img width="692" height="782" alt="image" src="https://github.com/user-attachments/assets/d885bba5-9a9f-4d85-9c20-c2ff2731140f" />


**Consulta 2 – Inyección basada en tiempo** 

SLEEP() para confirmar vulnerabilidad por retardo.
SELECT * FROM productos WHERE id = 1 - SLEEP(1);
Es una inyección ciega (blind SQL injection): el atacante no ve los datos directamente, sino que deduce información observando cuánto tarda la respuesta.
SLEEP(1) hace una pausa de 1 segundo. Si la página tarda ese tiempo, confirma que el código es vulnerable aunque no muestre errores ni resultados.
Se usa cuando la aplicación no devuelve mensajes de error ni datos visibles, por eso el atacante recurre al tiempo como "canal" de información.
Normalmente se combina con condiciones (IF, AND) para extraer datos letra por letra. Ejemplo: "si la primera letra del password es 'a', duerme 5 segundos".
Es más lenta y sigilosa, difícil de detectar en logs normales.

<img width="763" height="835" alt="image" src="https://github.com/user-attachments/assets/0e8885b6-d0a2-41fb-8c29-cf31999f2baf" />


**Consulta 3 – Inyección por comentario** 

Anula el resto de la condición.
SELECT * FROM productos WHERE nombre = 'Libros'; -- ' AND precio = ...
Los símbolos -- (o #, o /* */) convierten en comentario todo lo que viene después, por lo que el resto de la consulta original queda anulado.
Sirve para eliminar condiciones de seguridad. Por ejemplo, en un login: WHERE usuario = 'admin' -- ' AND password = '...' ignora la verificación de contraseña y entra como admin.
También se usa para "cerrar limpiamente" una inyección y evitar errores de sintaxis por las comillas o paréntesis sobrantes.

<img width="740" height="816" alt="image" src="https://github.com/user-attachments/assets/01683558-f801-49c9-b65d-d350c353ad60" />


### 2. Diccionario (funciones Insertar / Actualizar)

Se usa un `Dictionary<int, string>` (ID → nombre del estudiante):

- `Insertar(id, nombre)`: agrega el registro solo si la clave **no existe** (usa `ContainsKey`); si ya existe, muestra un error y devuelve `false`.
- `Actualizar(id, nuevoNombre)`: modifica el valor solo si la clave **existe**; si no, muestra un error y devuelve `false`.

<img width="1475" height="367" alt="image" src="https://github.com/user-attachments/assets/615ed532-143c-4bfc-98ca-a958d3dc297f" />

### 3. Factorial → Recursividad

El método `Calcular(long numero)` se llama a sí mismo:

- **Caso base:** si `numero <= 1` devuelve `1`.
- **Paso recursivo:** `numero * Calcular(numero - 1)`.

Se imprime el factorial de 0 a 10.

<img width="1475" height="482" alt="image" src="https://github.com/user-attachments/assets/d3945ff2-6c5c-4c68-8167-379fb4beb407" />

### 4. Sobrecarga de métodos

La clase `SobreCarga` declara varios métodos con el mismo nombre y distinta firma. El compilador elige cuál ejecutar según los argumentos:

- **Por tipo:** `Cuadrado(int)` y `Cuadrado(double)`.
- **Por número de parámetros:** `Sumar(int, int)` y `Sumar(int, int, int)`.
- **Por orden de parámetros:** `Describir(string, int)` y `Describir(int, string)`.

<img width="1460" height="393" alt="image" src="https://github.com/user-attachments/assets/e5b22f60-8be4-46d4-82be-2e7f5cb8987f" />

### 5. Estadísticas (frecuencia de un dado)

Con `Random.Next(1, 7)` se simulan 6000 lanzamientos de un dado. Un `switch` incrementa el contador de la cara obtenida (`frecuencia1` … `frecuencia6`). Al final se muestra la frecuencia y el porcentaje de cada cara, la más y la menos frecuente, y la frecuencia esperada (1000). Como los números son aleatorios, cada ejecución da resultados distintos.

<img width="1462" height="400" alt="image" src="https://github.com/user-attachments/assets/1f126fe3-335a-4742-8017-cc87723fcc5b" />

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
   https://github.com/Lyrics354/Consultas-SQL.git
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

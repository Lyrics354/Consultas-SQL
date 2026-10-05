using System;
using System.Collections.Generic;

/* Pruebas del Código de Conexión */
Dictionary<string, object> datosInventario = new Dictionary<string, object>
{
    { "Nombre", "Laptop HP Envy" },
    { "Precio", 850.99m },
    { "Cantidad", 15 }
};

var setParts = new List<string>();
foreach (var key in datosInventario.Keys)
{
    setParts.Add($"{key} = @{key}");
}
string setClause = string.Join(", ", setParts);

// Imprimimos el resultado en consola para verificar cómo se armó
Console.WriteLine($"Cláusula SET generada: {setClause}");

var columns = string.Join(", ", datosInventario.Keys);
var placeholders = "@" + string.Join(", @", datosInventario.Keys);

string sql = $"INSERT INTO productos ({columns}) VALUES ({placeholders})";
Console.WriteLine($"la cadena sql es: {sql} ");

// Ejemplo de la diapositiva 7
Dictionary<string, object> misCabeceras = new Dictionary<string, object>();
misCabeceras.Add("ID", 1);
misCabeceras.Add("Usuario", "Irina");
misCabeceras.Add("Rol", "Administrador");

foreach (var item in misCabeceras.Keys)
{
    Console.WriteLine(item);
}
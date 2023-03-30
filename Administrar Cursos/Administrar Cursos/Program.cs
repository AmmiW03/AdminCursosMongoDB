// See https://aka.ms/new-console-template for more information
using Administrar_Cursos.Modelos;

Task tExcel = Task.Run(() => mdlMetodos.Obtener());

Console.WriteLine("\nCargando información...\n");

await tExcel;

if (tExcel.IsCompletedSuccessfully)
{
    Console.Clear();
    Console.WriteLine("\nDatos insertados correctamente.\n");
}





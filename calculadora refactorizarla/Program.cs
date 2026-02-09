using System;
using calculadora_refactorizarla.App;
using calculadora_refactorizarla.Interface;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Calculadora Simple ===");

        Console.Write("Ingrese el primer número: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese el segundo número: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        // Program solo conoce la abstracción IOperationProvider
        IOperationProvider provider = new DefaultOperationProvider();

        var selector = new OperationSelector(provider);

        selector.MostrarMenu();

        Console.Write("Opción: ");
        int opcion = Convert.ToInt32(Console.ReadLine());

        try
        {
            var operacion = selector.ObtenerOperacion(opcion);
            double resultado = operacion.Calcular(num1, num2);
            Console.WriteLine($"\nResultado: {resultado}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

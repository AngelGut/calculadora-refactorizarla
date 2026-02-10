using System;
using calculadora_refactorizarla.App;
using calculadora_refactorizarla.Interface;

class Program
{
    static void Main()
    {
        // Presentación (UI): muestra el título principal del programa.
        // SRP: Program se encarga del flujo de la aplicación por consola, no de la lógica matemática.
        Console.WriteLine("=== Calculadora Simple ===");

        // Entrada de datos por consola (UI).
        // Nota: Convert.ToDouble puede lanzar excepción si el usuario escribe texto no numérico.
        Console.Write("Ingrese el primer número: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese el segundo número: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        // DIP / Composition Root:
        // Aquí es el lugar "permitido" donde se instancian implementaciones concretas.
        // Program solo depende de la abstracción IOperationProvider, no de clases como Suma o Resta.
        // DefaultOperationProvider es el "proveedor concreto" que sabe qué operaciones existen.
        IOperationProvider provider = new DefaultOperationProvider();

        // Se crea el selector de operaciones inyectándole el proveedor (abstracción).
        // DIP: OperationSelector no crea operaciones, las obtiene desde el provider.
        var selector = new OperationSelector(provider);

        // Muestra el menú al usuario basado en las operaciones disponibles.
        selector.MostrarMenu();

        // Lectura de la opción (UI).
        Console.Write("Opción: ");
        int opcion = Convert.ToInt32(Console.ReadLine());

        try
        {
            // Se obtiene la operación seleccionada (validación incluida dentro del selector).
            // Si la opción no es válida, el selector lanza una excepción que atrapamos aquí.
            var operacion = selector.ObtenerOperacion(opcion);

            // Se ejecuta el cálculo mediante la interfaz ICalcular.
            // SRP: Program no sabe cómo se calcula; solo llama al contrato (Calcular).
            // LSP: cualquier clase que implemente ICalcular puede reemplazar a otra aquí.
            double resultado = operacion.Calcular(num1, num2);

            // Salida por consola (UI).
            Console.WriteLine($"\nResultado: {resultado}");
        }
        catch (Exception ex)
        {
            // Manejo de errores a nivel de UI.
            // Importante: las operaciones lanzan excepciones (ej: división entre cero),
            // y la UI decide cómo mostrar el mensaje sin mezclar lógica matemática aquí.
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

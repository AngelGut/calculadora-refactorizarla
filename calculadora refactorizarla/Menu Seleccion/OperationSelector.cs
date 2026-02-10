using System;
using System.Collections.Generic;
using calculadora_refactorizarla.Interface;

namespace calculadora_refactorizarla.App
{
    /// <summary>
    /// Clase responsable de gestionar la selección de operaciones.
    /// 
    /// Su responsabilidad es:
    /// 1) Obtener el conjunto de operaciones disponibles (desde un proveedor).
    /// 2) Mostrar el menú de operaciones al usuario.
    /// 3) Validar la opción elegida y devolver la operación correspondiente.
    /// 
    /// Esta clase NO realiza cálculos matemáticos (eso lo hacen las clases que implementan ICalcular)
    /// y NO crea operaciones concretas (eso lo hace un proveedor IOperationProvider).
    /// 
    /// Principios SOLID aplicados:
    /// - SRP: tiene una sola responsabilidad (selección/menú/validación de opción).
    /// - DIP: depende de abstracciones (IOperationProvider e ICalcular), no de clases concretas.
    /// </summary>
    public class OperationSelector
    {
        /// <summary>
        /// Lista interna de operaciones disponibles.
        /// Se almacena como ICalcular (abstracción) para mantener desacoplamiento.
        /// </summary>
        private readonly List<ICalcular> _operaciones;

        /// <summary>
        /// Constructor que recibe un proveedor de operaciones.
        /// 
        /// DIP (Dependency Inversion Principle):
        /// - En lugar de instanciar operaciones aquí o recibir una lista creada con "new Suma()", etc.,
        ///   recibimos un proveedor abstracto (IOperationProvider).
        /// - Esto permite cambiar el origen de las operaciones (por ejemplo, otro proveedor)
        ///   sin modificar esta clase.
        /// </summary>
        /// <param name="provider">
        /// Proveedor que entrega la lista de operaciones disponibles.
        /// </param>
        public OperationSelector(IOperationProvider provider)
        {
            // Se obtiene la lista desde el proveedor.
            // Esta clase no sabe (ni le importa) cuáles operaciones concretas existen.
            _operaciones = provider.GetOperations();
        }

        /// <summary>
        /// Muestra en consola el menú de operaciones disponibles.
        /// 
        /// Nota:
        /// - Este método solo presenta información (menú).
        /// - No realiza cálculos ni contiene reglas matemáticas.
        /// 
        /// Si en el futuro quisieras cambiar la salida a otra UI,
        /// podrías extraer Console.WriteLine a una interfaz IOutput (para DIP más completo).
        /// </summary>
        public void MostrarMenu()
        {
            Console.WriteLine("\nSeleccione la operación:");

            // Se recorre la lista y se imprime cada operación con su número.
            for (int i = 0; i < _operaciones.Count; i++)
                Console.WriteLine($"{i + 1}. {_operaciones[i].Name}");
        }

        /// <summary>
        /// Valida la opción ingresada y retorna la operación seleccionada.
        /// 
        /// Si la opción no corresponde a un rango válido, se lanza una excepción,
        /// permitiendo que la capa superior (Program/UI) decida cómo mostrar el error.
        /// 
        /// Esto mantiene:
        /// - SRP: esta clase valida selección; no imprime errores ni calcula.
        /// - LSP: cualquier operación que implemente ICalcular puede ser devuelta aquí.
        /// </summary>
        /// <param name="opcion">Número de opción escogida por el usuario (1..N).</param>
        /// <returns>La operación seleccionada como ICalcular.</returns>
        public ICalcular ObtenerOperacion(int opcion)
        {
            // Validación de rango (1..cantidad de operaciones)
            if (opcion < 1 || opcion > _operaciones.Count)
                throw new Exception("Opción no válida.");

            // Se convierte la opción 1..N a índice 0..N-1
            return _operaciones[opcion - 1];
        }
    }
}

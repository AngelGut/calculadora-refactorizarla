using System.Collections.Generic;
using calculadora_refactorizarla.Clases;
using calculadora_refactorizarla.Interface;

namespace calculadora_refactorizarla.Interface
{
    /// <summary>
    /// Implementación concreta del proveedor de operaciones.
    /// 
    /// Esta clase actúa como el punto central de creación
    /// de las operaciones matemáticas disponibles en el sistema.
    /// 
    /// Aunque aquí se instancian clases concretas (Suma, Resta, etc.),
    /// esto NO viola el principio de Inversión de Dependencias (DIP),
    /// ya que la creación de dependencias está aislada en un único lugar
    /// conocido como "Composition Root".
    /// </summary>
    public class DefaultOperationProvider : IOperationProvider
    {
        /// <summary>
        /// Crea y retorna la lista de operaciones matemáticas disponibles.
        /// 
        /// Las operaciones se exponen mediante la interfaz ICalcular,
        /// permitiendo que las capas superiores de la aplicación
        /// trabajen únicamente con abstracciones y no con
        /// implementaciones concretas.
        /// 
        /// Para agregar una nueva operación, basta con:
        /// 1) Crear una clase que implemente ICalcular.
        /// 2) Registrarla en esta lista.
        /// 
        /// El resto del sistema no requiere modificaciones.
        /// </summary>
        /// <returns>
        /// Lista de operaciones que implementan la interfaz ICalcular.
        /// </returns>
        public List<ICalcular> GetOperations()
        {
            return new List<ICalcular>
            {
                new Suma(),
                new Resta(),
                new Multiplicacion(),
                new Division()
            };
        }
    }
}

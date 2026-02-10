using System.Collections.Generic;
using System.Collections.Generic;

namespace calculadora_refactorizarla.Interface
{
    /// <summary>
    /// Interfaz que define un proveedor de operaciones matemáticas.
    /// 
    /// Aplica el principio de Inversión de Dependencias (DIP),
    /// ya que las capas superiores (Program, OperationSelector)
    /// dependen de esta abstracción y no de clases concretas
    /// como Suma, Resta, Multiplicación o División.
    /// </summary>
    public interface IOperationProvider
    {
        /// <summary>
        /// Retorna la lista de operaciones disponibles para la calculadora.
        /// 
        /// Las operaciones se devuelven como una colección de la interfaz
        /// ICalcular, permitiendo que la lógica de la aplicación
        /// desconozca las implementaciones concretas.
        /// 
        /// De esta forma, es posible agregar, quitar o cambiar operaciones
        /// sin modificar el código que las consume.
        /// </summary>
        /// <returns>
        /// Lista de operaciones que implementan la interfaz ICalcular.
        /// </returns>
        List<ICalcular> GetOperations();
    }
}


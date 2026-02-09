using System.Collections.Generic;
using calculadora_refactorizarla.Clases;

namespace calculadora_refactorizarla.Interface
{
    public class DefaultOperationProvider : IOperationProvider
    {
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

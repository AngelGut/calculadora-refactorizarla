using System.Collections.Generic;

namespace calculadora_refactorizarla.Interface
{
    public interface IOperationProvider
    {
        List<ICalcular> GetOperations();
    }
}

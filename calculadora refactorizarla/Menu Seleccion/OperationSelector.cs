using System;
using System.Collections.Generic;
using calculadora_refactorizarla.Interface;

namespace calculadora_refactorizarla.App
{
    public class OperationSelector
    {
        private readonly List<ICalcular> _operaciones;

        // DIP: en vez de recibir List concreta armada en Program,
        // recibimos un proveedor abstracto.
        public OperationSelector(IOperationProvider provider)
        {
            _operaciones = provider.GetOperations();
        }

        public void MostrarMenu()
        {
            Console.WriteLine("\nSeleccione la operación:");
            for (int i = 0; i < _operaciones.Count; i++)
                Console.WriteLine($"{i + 1}. {_operaciones[i].Name}");
        }

        public ICalcular ObtenerOperacion(int opcion)
        {
            if (opcion < 1 || opcion > _operaciones.Count)
                throw new Exception("Opción no válida.");

            return _operaciones[opcion - 1];
        }
    }
}

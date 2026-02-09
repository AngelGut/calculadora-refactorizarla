using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using calculadora_refactorizarla.Interface;

namespace calculadora_refactorizarla.Clases
{
    internal class Division : ICalcular
    {
        public string Name => "División";

        public double Calcular(double a, double b)
        {

            // Validación propia de la operación
            if (b == 0)
                throw new DivideByZeroException("No se puede dividir entre cero.");

            return a / b;
        }
    }
}

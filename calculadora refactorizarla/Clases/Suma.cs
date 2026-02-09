using calculadora_refactorizarla.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculadora_refactorizarla.Clases
{
    public class Suma : ICalcular
    {
        public string Name => "Sumar";
        public double Calcular(double a, double b) => a + b;
    }
}

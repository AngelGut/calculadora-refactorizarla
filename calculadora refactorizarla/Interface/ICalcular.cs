using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculadora_refactorizarla.Interface
{
    public interface ICalcular
    {
        string Name { get; }
        
        double Calcular(double a, double b);
    }
}

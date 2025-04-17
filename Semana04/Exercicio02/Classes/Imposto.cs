using System;

namespace Exercicio02.Classes
{
    public class Imposto
    {
        public virtual void valeAlimentacao(double salario)
        {
            Console.WriteLine("Desconto do vale:"+(salario * 0.1));
        }
        public void valeTransporte(double salario)
        {
            Console.WriteLine("Desconto do transporte:"+(salario * 0.06));
        }
    }
}
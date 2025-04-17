using System;
namespace Exercicio02.Classes
{
    public class Gerente : Imposto
    {
        public override void valeAlimentacao(double salario)
        {
            Console.WriteLine("Desconto do vale gerente:"+(salario * 0.15));
        }
    }
}
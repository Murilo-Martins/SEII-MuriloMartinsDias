using System;
namespace Exercicio02.Classes
{
    public class Atendente : Imposto
    {
        public override void valeAlimentacao(double salario)
        {
            Console.WriteLine("Desconto do vale atendente:"+(salario * 0.12));
        }
    }
}
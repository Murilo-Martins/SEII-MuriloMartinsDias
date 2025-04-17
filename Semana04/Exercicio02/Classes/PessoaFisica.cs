using System;
namespace Exercicio02.Classes
{
    public class PessoaFisica : Padrao
    {
        //Obrigatorio
        public override void taxaEmprestimo(double valor)
        {
            Console.WriteLine("Taxa de emprestimo pessoa fisica R$ "+(valor*0.1));
        }
    }
}
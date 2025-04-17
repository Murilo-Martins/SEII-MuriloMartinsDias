using System;
namespace Exercicio02.Classes
{
    public class PessoaJuridica : Padrao
    {
        public override void taxaEmprestimo(double valor)
        {
            Console.WriteLine("Taxa de emprestimo pessoa juridica R$ "+(valor*0.2));
        }
    }
}
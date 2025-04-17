// See https://aka.ms/new-console-template for more information
using System;
using Exercicio02.Classes;
namespace _01Conceitos
{
    class Program
    {
        public static void Main (string[] args)
        {
            
            if(false){
                //Video 3 -------------
                Pessoa pessoa = new Pessoa("Murilo");
                pessoa.nome = "Maria";
                pessoa.idade = 11;
                pessoa.mensagem();

                //Video 4 -------------
                pessoa.apresentar();
                pessoa.apresentar("Murilo");
                pessoa.apresentar("Murilo",27);

                //Video 5 -------------
                Aluno a = new Aluno();
                a.nome = "Denis";
                a.nota1 = 8;
                a.nota2 = 10;
                a.mensagem();

                //Video 6 -------------
                pessoa.peso = 85.0;
                pessoa.altura = 1.80;
                pessoa.CorreRisco();

                //Video 8 -------------
                a.getNotas();

                //Video 10 ------------
                pessoa.SobreNome = "Ralf";
                Console.WriteLine(pessoa.SobreNome);

                //Video 12 ------------
                Colaborador colab = new Colaborador("Murilo", 27, 1000);

                //Video 13 ------------
                Imposto estagiario = new Estagiario();
                estagiario.valeAlimentacao(1000);
                estagiario.valeTransporte(1000);

                Imposto gerente = new Gerente();
                gerente.valeAlimentacao(5000);
                gerente.valeTransporte(5000);

                Imposto atendente = new Atendente();
                atendente.valeAlimentacao(2000);
                atendente.valeTransporte(2000);

                //Video 14 --------------
                Exemplo.soma(3,2);

                //Video 16 --------------
                PessoaFisica pf = new PessoaFisica();
                pf.taxaEmprestimo(1000);

                PessoaJuridica pj = new PessoaJuridica();
                pj.taxaEmprestimo(1000);
            }
                //Video 17 ---------------
                Calculo c = new Calculo();
                c.somar(10,15);
                c.subtrair(15,10);
                
                
                
        }
    }
}
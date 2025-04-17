using System;
namespace Exercicio02.Classes
{
    public class Aluno
    {
        //Atributos
        public string nome;
        public double nota1, nota2;

        //Métodos
        public double media()
        {
            return (nota1+nota2)/2;
        }
        public string situacao(double media)
        {
            return media >= 7 ? "aprovado" : "reprovado";
        }
        public void mensagem()
        {
            double obterMedia = media();
            string obterSituacao = situacao(obterMedia);

            Console.WriteLine(nome+" está "+obterSituacao+" com média "+obterMedia);
        }

        //Video 8 -------
        private double nota3, nota4;

        public double Pmedia()
        {
            return (nota3+nota4)/2;
        }

        public void getNotas()
        {
            Console.WriteLine("Informe a primeira nota");
            nota3 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a segunda nota");
            nota4 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("A média é: " +Pmedia());
        }


    }
}
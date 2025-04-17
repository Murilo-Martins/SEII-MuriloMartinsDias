namespace Exercicio02.Classes
{
    public class Colaborador : Pessoa
    {
        private double salario;

        public Colaborador(string nome, int idade, double salario)
        {
            this.nomeColab = nome;
            this.idadeColab= idade;
            this.salario = salario;
            mensagemPessoa();
            mensagemColaborador();
        }

        private void mensagemColaborador(){
            Console.WriteLine("Salário: "+salario);
        }
    }
}
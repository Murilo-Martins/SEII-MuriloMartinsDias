namespace Exercicio02.Classes
{
    public class Pessoa
    {
        //Atributos
        public string? nome;
        public int idade;
        public double peso;
        public double altura;


        //Métodos
        public void mensagem()
        {
            Console.WriteLine( "Olá "+nome+" você tem "+idade+" anos" );
        }

        //01
        public void apresentar ()
        {
            Console.WriteLine("Olá");
        }
        //02
        public void apresentar (string nome)
        {
            Console.WriteLine( "Olá "+nome);
        }
        //03
        public void apresentar (string nome, int idade)
        {
            Console.WriteLine( "Olá "+nome+" você tem "+idade+" anos" );
        }

        //Video 6
        public double IMC()
        {
            return (peso/(altura*altura));
        }

        public string Risco()
        {
            double Imc = IMC();
            if (Imc < 18.5)
            {
                return "Abaixo do peso";
            }
            else if (Imc < 25)
            {
                return "Peso noral";
            }
            else if (Imc < 30)
            {
                return "Acima do peso";
            }
            else if (Imc < 35)
            {
                return "Obesidade I";
            }
            else if (Imc < 40)
            {
                return "Obesidade II";
            }
            else
            {
                return "Obesidade III";
            }
        }

        public void CorreRisco()
        {
            Console.WriteLine(nome+" tem "+idade+" pesa "+peso+"kg e mede "+altura+"m está, atualmente ela está "+Risco());
        }

        //Video 9 ---------
        public Pessoa()
        {
            Console.WriteLine("Contrutor executado");
        }

        

        //Video 10 ----
        private string sobreNome;

        public string SobreNome
        {
            get{return sobreNome;}
            set{sobreNome=value;}

        }

        //Video 11 ----
        public Pessoa(string sobreNome)
        {
            Console.WriteLine(sobreNome);
            Console.WriteLine(this.nome);
        }

        //Video 12 -----
        protected string nomeColab;
        protected int idadeColab;

        protected void mensagemPessoa()
        {
            Console.WriteLine("Nome: "+nomeColab);
            Console.WriteLine("Idade: "+idadeColab);
        }

    }
}
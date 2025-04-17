namespace Exercicio02.Classes
{
    public class Calculo :IPadrao
    {
        public void somar(int n1, int n2)
        {
            Console.WriteLine("Soma : "+(n1+n2));
        }
        public void subtrair(int n1, int n2)
        {
            Console.WriteLine("Subtrair : "+(n1-n2));
        }
    }
}
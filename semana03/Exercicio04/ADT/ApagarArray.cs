namespace Exercicio04.ADT
{
    public class ApagarArray
    {
                //Arrays
        //Array Insertions & Deletions

        // Inserting at the End of an Array
        public static void Executar(){
            int[] intArray = new int[9];
            int length = 0;
            for(int i = 0; i < 6; i++)
            {
                intArray[length] = i;
                length++;
            }

            //length--;

            //Apagar do primeiro
            for(int i = 2; i <length; i++)
            {
                intArray[i-1] = intArray[i];
                
            }

            //Apagar de qualquer lugar
            for(int i = 3; i <length; i++)
            {
                intArray[i-1] = intArray[i];
            
            }
            length--;

    //Printar
            for(int i = 0; i <length; i++)
            {
                
                Console.WriteLine(intArray[i]);
            }



            for (int i = 4; i>=2; i--)
            {
                intArray[i + 1] = intArray[i];
            }
        }
    }
}
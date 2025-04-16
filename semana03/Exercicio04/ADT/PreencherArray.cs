namespace ADT
{
    public class Video1PreencherArray
    {
        public static void Executar()
        {
            //Arrays
            //Array Insertions & Deletions

            // Inserting at the End of an Array

            int[] intArray = new int[10];
            int length = 0;
            for(int i = 0; i < 8; i++)
                {
                    intArray[length] = i;
                    length++;
                }

            if(false)
            {
                intArray[length] = 8;
                length++;
                //Colocar no inicio
                for(int i = 3; i >= 0; i--)
                {
                    intArray[i+1] = intArray[i];
                }
                intArray[0] = 20;
                int value = 0;
            }


            for (int i = 4; i>=2; i--)
            {
                intArray[i + 1] = intArray[i];
            }
        
        }
    }
}
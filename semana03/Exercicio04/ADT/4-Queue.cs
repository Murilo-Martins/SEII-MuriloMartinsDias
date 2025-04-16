namespace Exercicio04.ADT
{
    public class Queue
    {
        public int MaxSize { get; set; }
        public int[] QueueArray { get; set; }
        public int Front { get; set; }
        public int Rear { get; set; }
        public int NItems { get; set; }

        public Queue(int size)
        {
            this.MaxSize = size;
            this.QueueArray = new int[size];
            Front=0;
            Rear=-1;
        }

        public void Enqueue(int item){
            //Incrementa o ponteiro
            Rear++;
            //Insere onde o ponteiro está o valor
            QueueArray[Rear]=item;
            NItems++;
        }

        public int Dequeue(){
            int temp = QueueArray[Front];
            Front++;
            if(Front == MaxSize)
            {
                Front = 0;
            }
            NItems--;
            return temp;
        }

        public int Peek(){
            return QueueArray[Front];
        }

    
    }
}
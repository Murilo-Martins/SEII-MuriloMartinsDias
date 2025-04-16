using Exercicio04.ADT;

if(false){
    //LinkedLink Parte
    InserirLinkedList linkedList = new InserirLinkedList();
    linkedList.InsertFirst(1);
    linkedList.InsertFirst(2);
    linkedList.InsertFirst(3);
    linkedList.InsertFirst(4);

    linkedList.DeleteFirst();
    linkedList.DeleteFirst();

    linkedList.InsertLast(546);
    linkedList.InsertLast(3434);

    linkedList.DisplayList();


    //Stack Parte
    Stack stack = new Stack(10);
    for (int i = 0; i < 3; i++)
    {
        stack.Push("Pikachu");
        stack.Push("Charmeleon");
        stack.Push("Squirtle");
    }

    stack.Pop();
    stack.Peek();

    while(!stack.isEmpty()){
        var var = stack.Pop();
        Console.WriteLine(var);
    }

    //Queue Parte
    Queue queue = new Queue(10);
    queue.Enqueue(1);
    queue.Enqueue(2);
    queue.Enqueue(3);
    queue.Enqueue(4);
    queue.Enqueue(5);

    queue.Dequeue();
    queue.Dequeue();

    queue.Peek();

    //Binary Search
    int[] intArray = {-22,-15,2,7,20,30,54};
    Console.WriteLine(BinarySearch(intArray, 2));
    int BinarySearch(int[] intArray, int value)
    {
        int start = 0;
        int end = 0;

        while(start<end)
        {
            int midpoint =(start+end)/2;
            if(intArray[midpoint] == value)
            {
                return midpoint;
            }
            else if(intArray[midpoint]<value){
                start = midpoint +1;
            }
            else{
                end = midpoint;
            }
        }
        return -1;
    }

    //Binary search
    BinarySearchTree bst = new BinarySearchTree();
    bst.Insert(13,"Pikachu");
    bst.Insert(23,"Mew");
    bst.Insert(78,"Arceus");
    bst.Insert(153,"Zapdos");

    Console.WriteLine(bst.Find(153));
}


int[] intArray2 = new int[] {6,5,1,7,2,4};

Console.WriteLine(BubbleSort(intArray2));

int[] BubbleSort(int[] array)
{
    int temp;

    for (int pointer = 0; pointer < array.Length; pointer++){
        for(int sort = 0; sort < array.Length -1; sort++){
            if(array[sort]>array[sort +1])
            {
                temp = array[sort+1];
                array[sort+1]=array[sort];
                array[sort]=temp;
            }
        }
    }
    return array;
}

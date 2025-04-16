namespace Exercicio04.ADT
{
    public class InserirLinkedList
    {
        
        public Node? First { get; set; }

        public void InsertFirst (int data)
        {
           
            //Create the node
            Node newNode = new Node();
            newNode.Data = data;
            newNode.Next = First;
            First = newNode;
        }

        public Node DeleteFirst()
        {
            Node temp = First;

            First = First.Next;
            return temp;

        }

        public void DisplayList()
        {
            Console.WriteLine("For para a lista...");
            Node current = First;
            while(current != null){
                current.DisplayNode();
                current = current.Next;
            }
        }
        
        public void InsertLast(int data){
            Node current = First;
            while(current.Next != null){
                current = current.Next;
            }
            Node newNode = new Node();
            newNode.Data = data;
            current.Next = newNode;
        }
        
    }
}


namespace Exercicio04.ADT
{
    public class BinarySearchTree{
        public TreeNode Root { get; set; }

        public void Insert(int key, string value)
        {
            Root = InsertItem(Root, key, value);
        }

        public TreeNode InsertItem(TreeNode node, int key, string value)
        {
            TreeNode newNode = new TreeNode(key,value);
            //Primeira vez? :;
            if(node==null)
            {
                node = newNode;
                return node;
            }

            //Não é a primeira! 
            if(key<node.key)
            {
                node.LeftChild = InsertItem(node.LeftChild,key,value);
            }
            else
            {
                node.RightChild =InsertItem(node.RightChild,key,value);
            }
            return node;
        }
        public string Find(int key)
        {
            TreeNode node = Find(Root, key);
            return node == null ? null: node.Value;
        }

        private TreeNode? Find(TreeNode node, int key)
        {
            if(node==null || node.key == key)
            {
                return node;
            }
            else if(key < node.key)
            {
                return Find(node.LeftChild, key);
            }
            else if( key> node.key)
            {
                return Find(node.RightChild, key);
            }
            return null;
        }

    }
    public class TreeNode
    {
        public int key { get; set; }    
        public string Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode(int key, string value){
            this.key=key;
            this.Value=value;
        }
    }
}
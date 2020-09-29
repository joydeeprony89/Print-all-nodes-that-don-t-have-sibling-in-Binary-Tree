using System;
using System.Runtime.CompilerServices;

namespace Print_all_nodes_that_don_t_have_sibling_in_Binary_Tree
{
    class Program
    {
        public class Node
        {
            public int value { get; set; }
            public Node left, right;
            public Node(int value = 0)
            {
                this.value = value;
                left = right = null;
            }
        }

        static void Main(string[] args)
        {
            Node root = new Node(8);
            root.left = new Node(3);
            root.right = new Node(10);
            root.left.left = new Node(1);
            root.left.right = new Node(6);
            root.left.right.left = new Node(4);
            root.left.right.right = new Node(7);
            root.right.right = new Node(14);
            root.right.right.left = new Node(13);
            Console.WriteLine("Printing nodes which does not have siblings");
            PrintSingleChild(root);
        }

        static void PrintSingleChild(Node root)
        {
            if (root == null) return;

            //traverse the left and right subtrees , this condition is use to break when either left or right child is missing.
            if (root.left != null && root.right != null)
            {
                PrintSingleChild(root.left);
                PrintSingleChild(root.right);
            }

            // when parent dont have either left or right

            // parent has left no right so this child has no siblings , we will print it and traverse further subtrees
            else if (root.left != null)
            {
                Console.WriteLine(root.left.value);
                PrintSingleChild(root.left);
            }

            // parent has right no left, so this child has no siblings , we will print it and traverse further subtrees
            else if (root.right != null)
            {
                Console.WriteLine(root.right.value);
                PrintSingleChild(root.right);
            }
        }
    }
}

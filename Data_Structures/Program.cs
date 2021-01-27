using System;

namespace Linked_List
{
    public class SLinkedList
    {
        internal Node head;
        internal Node tail;

        public void InsertFront(int newData)
        {
            Node newNode = new Node(newData);
            newNode.next = this.head;
            this.head = newNode;
        }

        public void InsertBack(int newData)
        {
            Node newNode = new Node(newData);
            if (this.head == null) 
            {
                this.head = newNode;
                this.tail = newNode;
                return;
            }
            this.tail.next = newNode;
            this.tail = newNode;
        }

        public void DeleteNode(int data)
        {
            Node target = FindNode(this.head, data);
            if (target == null)
            {
                Console.WriteLine("Node not found in list.");
                return;
            }

            if (target == this.head) this.head = target.next;

        }

        internal Node FindNode(Node node, int data)
        {
            if (node == null) return null;
            if (node.data == data)
            {
                return node;
            } else { 
                return FindNode(node.next, data);
            }
        }

        internal Node FindPredecessor(Node node, int data)
        {
            if ((node == null) || (node.next == null))
            {
                Console.WriteLine("Error: predecessor sought on null list.");
                return null;
            }

            if (node.next.data == data)
            {
                return node;
            } else {
                return FindPredecessor(node.next, data);
            }
        }
    }

    internal class Node
    {
        internal int data;
        internal Node next;
        public Node(int d) 
        {
            data = d;
            next = null;
        }
    }
}

using System;

namespace LinkedList
{   
    /// <summary>
    /// Singly linked list node.
    /// </summary>
    public class LinkedListNode
    {

        public LinkedListNode Next { get; set; }
        public int Data { get; set; }

        /// <summary>
        /// Constructor for singly linked list node
        /// </summary>
        /// <param name="d">Integer data for the node to hold</param>
        public LinkedListNode(int d)
        {
            Data = d;
            Next = null;
        }

        public static void Main() { }
    }

    /// <summary>
    /// Doubly linked list node.
    /// </summary>
    public class DLinkedListNode
    {
        /// <summary>
        /// Constructor for doubly linked list node
        /// </summary>
        /// <param name="d">Integer data for the node to hold</param>
        public DLinkedListNode(int d)
        {
            Data = d;
            Next = null;
            Prev = null;
        }

        public int Data { get; set; }
        public DLinkedListNode Next { get; set; }
        public DLinkedListNode Prev { get; set; }
    }

    /// <summary>
    /// Singly linked list with Integer data field, head, and tail.
    /// </summary>
    public class SLinkedList
    {
        public LinkedListNode Head { get; private set; }
        public LinkedListNode Tail { get; private set; }

        public SLinkedList()
        {
            this.Head = null;
            this.Tail = null;
        }



        /// <summary>
        /// Creates a new Node object with provided data then adds it at the head of the list.
        /// </summary>
        /// <param name="newData">Desired data to be entered</param>
        public void InsertFront(int newData)
        {
            LinkedListNode newNode = new LinkedListNode(newData);
            if (this.Head == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                newNode.Next = this.Head;
                this.Head = newNode;
            }
        }

        /// <summary>
        /// Creates a new Node object with provided data then adds it at the tail of the list.
        /// </summary>
        /// <param name="newData">Desired data to be entered</param>
        public void InsertBack(int newData)
        {
            LinkedListNode newNode = new LinkedListNode(newData);
            if (this.Head == null) 
            {
                this.Head = newNode;
                this.Tail = newNode;
                return;
            }
            this.Tail.Next = newNode;
            this.Tail = newNode;
        }

        /// <summary>
        /// Finds and returns the first Node with data that matches the provided data.
        /// </summary>
        /// <param name="node">Node to start at when called.</param>
        /// <param name="data">Data to compare Nodes against.</param>
        /// <returns></returns>
        public LinkedListNode FindNode(LinkedListNode node, int data)
        {
            if (node == null) return null;
            if (node.Data == data)
            {
                return node;
            }
            else
            {
                return FindNode(node.Next, data);
            }
        }
        
        /// <summary>
        /// Finds and returns the Node before the first Node with data that matches the provided data.
        /// </summary>
        /// <param name="head">Node to start at when called.</param>
        /// <param name="data">Data to compare nodes against.</param>
        /// <returns></returns>
        private LinkedListNode FindPredecessor(LinkedListNode head, int data)
        {
            if ((head == null) || (head.Next == null))
            {
                Console.WriteLine("Error: predecessor sought on null list.");
                return null;
            }

            if (head.Next.Data == data)
            {
                return head;
            }
            else
            {
                return FindPredecessor(head.Next, data);
            }
        }

        /// <summary>
        /// Finds and removes the first matching Node from the list.
        /// </summary>
        /// <param name="data">Data to compare nodes against.</param>
        public void DeleteNode(int data)
        {
            LinkedListNode target = FindNode(this.Head, data);
            if (target == null)
            {
                Console.WriteLine("Node not found in list.");
                return;
            }

            if (target == this.Head)
            {
                this.Head = target.Next;
                return;
            }
            LinkedListNode pred = FindPredecessor(this.Head, data);
            if (target == this.Tail) this.Tail = pred;
            pred.Next = target.Next;
        }

        /// <summary>
        /// Reverses the order of the linked list.
        /// </summary>
        /// <param name="list">List to reverse.</param>
        public void ReverseLinkedList(SLinkedList list)
        {
            list.Head = ReverseOperation(list.Head);
        }

        private LinkedListNode ReverseOperation(LinkedListNode head)
        {
            if (head.Next == null) return head;
            LinkedListNode newHead = ReverseOperation(head.Next);
            LinkedListNode temp = head.Next.Next;
            head.Next.Next = head;
            head.Next = temp;
            return newHead;
        }
    }

    /// <summary>
    /// Doubly linked list with Integer data field, head, and tail.
    /// </summary>
    public class DLinkedList
    {

        public DLinkedList()
        {
            this.Head = null;
            this.Tail = null;
        }

        public DLinkedListNode Head { get; private set; }
        public DLinkedListNode Tail { get; private set; }

        /// <summary>
        /// Creates a new Node object with provided data then adds it at the head of the list.
        /// </summary>
        /// <param name="newData">Desired data to be entered</param>
        public void InsertFront(int newData)
        {
            DLinkedListNode newNode = new DLinkedListNode(newData);
            if (this.Head == null) {
                this.Head = newNode;
                this.Tail = newNode;
            } else
            {
                newNode.Next = this.Head;
                this.Head.Prev = newNode;
                this.Head = newNode;
            }
        }

        /// <summary>
        /// Creates a new Node object with provided data then adds it at the tail of the list.
        /// </summary>
        /// <param name="newData">Desired data to be entered</param>
        public void InsertBack(int newData)
        {
            DLinkedListNode newNode = new DLinkedListNode(newData);
            if (this.Head == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                newNode.Prev = this.Tail;
                this.Tail.Next = newNode;
                this.Tail = newNode;
            }
        }

        /// <summary>
        /// Finds and returns the first Node with data that matches the provided data.
        /// </summary>
        /// <param name="head">Node to start at when called.</param>
        /// <param name="data">Data to compare Nodes against.</param>
        /// <returns></returns>
        public DLinkedListNode FindNode(DLinkedListNode head, int data)
        {
            if (head == null) return null;
            if (head.Data == data)
            {
                return head;
            }
            else
            {
                return FindNode(head.Next, data);
            }
        }

        /// <summary>
        /// Finds and removes the first matching Node from the list.
        /// </summary>
        /// <param name="data">Data to compare nodes against.</param>
        public void DeleteNode(int data)
        {
            DLinkedListNode target = FindNode(this.Head, data);
            if (target == null) {
                Console.WriteLine("Node not found in list");
                return;
            }
            DLinkedListNode pred = target.Prev;
            pred.Next = target.Next;
        }
    }
    
}

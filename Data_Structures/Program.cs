using System;

namespace Linked_List
{
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

    internal class DNode
    {
        internal int data;
        internal DNode next;
        internal DNode prev;
        public DNode(int d)
        {
            data = d;
            next = null;
            prev = null;
        }
    }

    /// <summary>
    /// Singly linked list with Integer data field, head, and tail.
    /// </summary>
    public class SLinkedList
    {
        private Node head = null;
        private Node tail = null;

        internal Node Head { get; }
        internal Node Tail { get; }

        /// <summary>
        /// Creates a new Node object with provided data then adds it at the head of the list.
        /// </summary>
        /// <param name="newData">Desired data to be entered</param>
        internal void InsertFront(int newData)
        {
            Node newNode = new Node(newData);
            newNode.next = this.head;
            this.head = newNode;
        }

        /// <summary>
        /// Creates a new Node object with provided data then adds it at the tail of the list.
        /// </summary>
        /// <param name="newData">Desired data to be entered</param>
        internal void InsertBack(int newData)
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

        /// <summary>
        /// Finds and returns the first Node with data that matches the provided data.
        /// </summary>
        /// <param name="node">Node to start at when called.</param>
        /// <param name="data">Data to compare Nodes against.</param>
        /// <returns></returns>
        internal Node FindNode(Node node, int data)
        {
            if (node == null) return null;
            if (node.data == data)
            {
                return node;
            }
            else
            {
                return FindNode(node.next, data);
            }
        }
        
        /// <summary>
        /// Finds and returns the Node before the first Node with data that matches the provided data.
        /// </summary>
        /// <param name="head">Node to start at when called.</param>
        /// <param name="data">Data to compare nodes against.</param>
        /// <returns></returns>
        internal Node FindPredecessor(Node head, int data)
        {
            if ((head == null) || (head.next == null))
            {
                Console.WriteLine("Error: predecessor sought on null list.");
                return null;
            }

            if (head.next.data == data)
            {
                return head;
            }
            else
            {
                return FindPredecessor(head.next, data);
            }
        }

        /// <summary>
        /// Finds and removes the first matching Node from the list.
        /// </summary>
        /// <param name="data">Data to compare nodes against.</param>
        internal void DeleteNode(int data)
        {
            Node target = FindNode(this.head, data);
            if (target == null)
            {
                Console.WriteLine("Node not found in list.");
                return;
            }

            if (target == this.head) this.head = target.next;
            Node pred = FindPredecessor(target, data);
            pred.next = target.next;
        }

        /// <summary>
        /// Reverses the order of the linked list.
        /// </summary>
        /// <param name="head">Node to start reversal at.</param>
        internal void ReverseLinkedList(SLinkedList list)
        {
            list.head = ReverseOperation(list.head);
        }

        internal Node ReverseOperation(Node head)
        {
            if (head.next == null) return head;
            Node newHead = ReverseOperation(head.next);
            Node temp = head.next.next;
            head.next.next = head;
            head.next = temp;
            return newHead;
        }
    }

    /// <summary>
    /// Doubly linked list with Integer data field, head, and tail.
    /// </summary>
    public class DLinkedList
    {
        private DNode head = null;
        private DNode tail = null;

        internal DNode Head { get; }
        internal DNode Tail { get; }

        /// <summary>
        /// Creates a new Node object with provided data then adds it at the head of the list.
        /// </summary>
        /// <param name="newData">Desired data to be entered</param>
        internal void InsertFront(int newData)
        {
            DNode newNode = new DNode(newData);
            if (this.head == null) {
                this.head = newNode;
                this.tail = newNode;
            } else
            {
                newNode.next = this.head;
                this.head.prev = newNode;
                this.head = newNode;
            }
        }

        /// <summary>
        /// Creates a new Node object with provided data then adds it at the tail of the list.
        /// </summary>
        /// <param name="newData">Desired data to be entered</param>
        internal void InsertBack(int newData)
        {
            DNode newNode = new DNode(newData);
            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.prev = this.tail;
                this.tail.next = newNode;
                this.tail = newNode;
            }
        }

        /// <summary>
        /// Finds and returns the first Node with data that matches the provided data.
        /// </summary>
        /// <param name="head">Node to start at when called.</param>
        /// <param name="data">Data to compare Nodes against.</param>
        /// <returns></returns>
        internal DNode FindNode(DNode head, int data)
        {
            if (head == null) return null;
            if (head.data == data)
            {
                return head;
            }
            else
            {
                return FindNode(head.next, data);
            }
        }

        /// <summary>
        /// Finds and removes the first matching Node from the list.
        /// </summary>
        /// <param name="data">Data to compare nodes against.</param>
        internal void DeleteNode(int data)
        {
            DNode target = FindNode(this.head, data);
            if (target == null) {
                Console.WriteLine("Node not found in list");
                return;
            }
            DNode pred = target.prev;
            pred.next = target.next;
        }
    }
}

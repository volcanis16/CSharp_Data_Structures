using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;
namespace LinkedListTests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void LinkedListNode_CreationWithData_DataShouldMatch()
        {
            // Arrange
            int inputInt = 10;

            // Act
            LinkedListNode node = new LinkedListNode(inputInt);
            DLinkedListNode dNode = new DLinkedListNode(inputInt);

            // Assert
            Assert.AreEqual(inputInt, node.Data);
            Assert.AreEqual(inputInt, dNode.Data);
        }
    }


    [TestClass]
    public class SLinkedListTests
    {
        SLinkedList list;

        [TestInitialize]
        public void TestInit()
        {
            list = new SLinkedList();
        }

        // Singly linked list tests.
        [TestMethod]
        public void SLinkedList_CreationMakesNullHeadAndTail()
        {
            // Assert
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        public void SLinkedList_InsertFront_InsertsCorrectly()
        {
            // Arrange
            SLinkedList addMultipleList = new SLinkedList();
            addMultipleList.InsertFront(10);

            // Act
            list.InsertFront(9);
            addMultipleList.InsertFront(9);

            // Assert
            int expectedHead = 9;

            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(expectedHead, list.Head.Data);
            Assert.IsNull(list.Head.Next);

            Assert.AreEqual(expectedHead, addMultipleList.Head.Data);
            Assert.AreNotEqual(addMultipleList.Head, addMultipleList.Tail);
            Assert.AreEqual(addMultipleList.Tail, addMultipleList.Head.Next);
        }

        [TestMethod]
        public void SLinkedList_InsertBack_InsertsCorrectly()
        {
            // Arrange
            SLinkedList addMultipleList = new SLinkedList();
            addMultipleList.InsertBack(10);

            // Act
            list.InsertBack(9);
            addMultipleList.InsertBack(9);

            // Assert
            int expectedTail = 9;

            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(expectedTail, list.Tail.Data);
            Assert.IsNull(list.Tail.Next);

            Assert.AreEqual(expectedTail, addMultipleList.Tail.Data);
            Assert.AreNotEqual(addMultipleList.Head, addMultipleList.Tail);
            Assert.AreEqual(addMultipleList.Tail, addMultipleList.Head.Next);
            Assert.IsNull(addMultipleList.Tail.Next);
        }

        [TestMethod]
        public void SLinkedList_FindNode_ReturnsCorrectly()
        {
            // Arrange
            list.InsertFront(3);
            list.InsertFront(2);
            list.InsertFront(1);

            // Act
            // Assert
            Assert.IsNull(list.FindNode(list.Head, 4));
            Assert.AreEqual(list.Head, list.FindNode(list.Head, 1));
            Assert.AreEqual(list.Tail, list.FindNode(list.Head, 3));
        }

        [TestMethod]
        public void SLinkedList_DeleteNode_DeletesLastNode()
        {
            // Arrange
            list.InsertFront(1);

            // Act
            list.DeleteNode(1);

            // Assert
            Assert.IsNull(list.FindNode(list.Head, 1));
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        public void SLinkedList_DeleteNode_DeletesHeadAndTail()
        {
            // Arrange
            list.InsertFront(3);
            list.InsertFront(2);
            list.InsertFront(1);

            // Act
            list.DeleteNode(3);
            list.DeleteNode(1);

            // Assert
            int expected = 2;

            Assert.IsNull(list.FindNode(list.Head, 1));
            Assert.IsNull(list.Head.Next);
            Assert.AreEqual(expected, list.Head.Data);
            Assert.AreEqual(expected, list.Tail.Data);
        }

        [TestMethod]
        public void SLinkedList_DeleteNode_DeletesElse()
        {
            // Arrange
            list.InsertFront(3);
            list.InsertFront(2);
            list.InsertFront(1);

            // Act
            list.DeleteNode(2);

            // Assert
            int expectedHead = 1;
            int expectedTail = 3;

            Assert.IsNull(list.FindNode(list.Head, 2));
            Assert.AreEqual(expectedHead, list.Head.Data);
            Assert.AreEqual(expectedTail, list.Tail.Data);
        }

        [TestMethod]
        public void SLinkedList_ReverseLinkedList_ReturnsNullWhenGivenEmptyList()
        {
            // Act
            list.ReverseLinkedList();
            // Assert
            Assert.IsNull(list.Head);
        }

        [TestMethod]
        public void SLinkedList_ReverseLinkedList_ReversesCorrectly_OneNode()
        {
            // Arrange
            list.InsertBack(1);
            // Act
            list.ReverseLinkedList();
            // Assert
            int expected = 1;

            Assert.IsNull(list.Head.Next);
            Assert.AreEqual(expected, list.Head.Data);
            Assert.AreEqual(expected, list.Tail.Data);
        }


        [TestMethod]
        public void SLinkedList_ReverseLinkedList_ReversesCorrectly_MultipleNodes()
        {
            // Arrange
            list.InsertBack(1);
            list.InsertBack(2);
            list.InsertBack(3);
            list.InsertBack(4);
            // Act
            list.ReverseLinkedList();
            // Assert
            int expectedHead = list.FindNode(list.Head, 4).Data;
            int expectedSecondNode = list.Head.Next.Data;
            int expectedThirdNode = list.Head.Next.Next.Data;
            int expectedTail = list.FindNode(list.Head, 1).Data;

            int secondNode = list.FindNode(list.Head, 3).Data;
            int thirdNode = list.FindNode(list.Head, 2).Data;

            Assert.AreEqual(expectedHead, list.Head.Data);
            Assert.AreEqual(expectedSecondNode, secondNode);
            Assert.AreEqual(expectedThirdNode, thirdNode);
            Assert.AreEqual(expectedTail, list.Tail.Data);
            Assert.IsNull(list.Tail.Next);
        }
    }

    [TestClass]
    public class DlinkedListTests
    {
        DLinkedList list;

        [TestInitialize]
        public void TestInit()
        {
            list = new DLinkedList();
        }

        //Doubly linked list tests.
        [TestMethod]
        public void DLinkedList_CreationMakesNullHeadAndTail()
        {
            // Assert
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        public void DlinkedList_InsertFront_InsertsCorrectly()
        {
            // Arrange
            DLinkedList addMultipleList = new DLinkedList();
            addMultipleList.InsertFront(10);

            // Act
            list.InsertFront(9);
            addMultipleList.InsertFront(9);

            // Assert
            int expectedHead = 9;

            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(expectedHead, list.Head.Data);
            Assert.IsNull(list.Head.Next);
            Assert.IsNull(list.Head.Prev);

            Assert.AreEqual(expectedHead, addMultipleList.Head.Data);
            Assert.AreNotEqual(addMultipleList.Head, addMultipleList.Tail);
            Assert.AreEqual(addMultipleList.Tail, addMultipleList.Head.Next);
            Assert.AreEqual(addMultipleList.Head, addMultipleList.Tail.Prev);
        }

        [TestMethod]
        public void DLinkedList_InsertBack_InsertsCorrectly()
        {
            // Arrange
            DLinkedList addMultipleList = new DLinkedList();
            addMultipleList.InsertBack(10);

            // Act
            list.InsertBack(9);
            addMultipleList.InsertBack(9);

            // Assert
            int expectedTail = 9;

            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(expectedTail, list.Tail.Data);
            Assert.IsNull(list.Tail.Next);

            Assert.AreEqual(expectedTail, addMultipleList.Tail.Data);
            Assert.AreNotEqual(addMultipleList.Head, addMultipleList.Tail);
            Assert.AreEqual(addMultipleList.Tail, addMultipleList.Head.Next);
            Assert.AreEqual(addMultipleList.Head, addMultipleList.Tail.Prev);
            Assert.IsNull(addMultipleList.Tail.Next);
        }

        [TestMethod]
        public void DLinkedList_FindNode_ReturnsCorrectly()
        {
            // Arrange
            list.InsertFront(3);
            list.InsertFront(2);
            list.InsertFront(1);

            // Act
            // Assert
            Assert.IsNull(list.FindNode(list.Head, 4));
            Assert.AreEqual(list.Head, list.FindNode(list.Head, 1));
            Assert.AreEqual(list.Tail, list.FindNode(list.Head, 3));
        }

        [TestMethod]
        public void DLinkedList_DeleteNode_DeletesLastNode()
        {
            // Arrange
            list.InsertFront(1);

            // Act
            list.DeleteNode(1);

            // Assert
            Assert.IsNull(list.FindNode(list.Head, 1));
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        public void DLinkedList_DeleteNode_DeletesHeadAndTail()
        {
            // Arrange
            list.InsertFront(3);
            list.InsertFront(2);
            list.InsertFront(1);

            // Act
            list.DeleteNode(3);
            list.DeleteNode(1);

            // Assert
            int expected = 2;

            Assert.IsNull(list.FindNode(list.Head, 1));
            Assert.IsNull(list.Head.Next);
            Assert.IsNull(list.Head.Prev);
            Assert.AreEqual(expected, list.Head.Data);
            Assert.AreEqual(expected, list.Tail.Data);
        }

        [TestMethod]
        public void SLinkedList_DeleteNode_DeletesElse()
        {
            // Arrange
            list.InsertFront(3);
            list.InsertFront(2);
            list.InsertFront(1);

            // Act
            list.DeleteNode(2);

            // Assert
            int expectedHead = 1;
            int expectedTail = 3;

            Assert.IsNull(list.FindNode(list.Head, 2));
            Assert.AreEqual(expectedHead, list.Head.Data);
            Assert.AreEqual(expectedTail, list.Tail.Data);
            Assert.AreEqual(list.Head, list.Tail.Prev);
            Assert.AreEqual(list.Tail, list.Head.Next);
        }

        [TestMethod]
        public void Testytest()
        {
            // Arrange
            // Act
            // Assert
        }
    }    
}

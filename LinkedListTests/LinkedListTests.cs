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
    public class LinkedListTests
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
            list.InsertFront(11);
            addMultipleList.InsertFront(9);

            // Assert
            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(11, list.Head.Data);
            Assert.IsNull(list.Head.Next);

            Assert.AreEqual(9, addMultipleList.Head.Data);
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
            list.InsertBack(11);
            addMultipleList.InsertBack(9);

            // Assert
            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(11, list.Tail.Data);
            Assert.IsNull(list.Tail.Next);

            Assert.AreEqual(9, addMultipleList.Tail.Data);
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
        public void SLinkedList_DeleteNode_DeletesHead()
        {
            // Arrange
            list.InsertFront(3);
            list.InsertFront(2);
            list.InsertFront(1);

            // Act
            list.DeleteNode(3);
            list.DeleteNode(1);

            // Assert
            Assert.IsNull(list.FindNode(list.Head, 1));
            Assert.AreEqual(2, list.Head.Data);
            Assert.AreEqual(2, list.Tail.Data);

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

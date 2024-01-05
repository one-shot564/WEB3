using lab_; //
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class CircularLinkedListTests
    {
        [TestMethod]
        public void Add_SingleItem_ListHasOneItem()
        {
            // Arrange
            var list = new CircularLinkedList<int>();

            // Act
            list.Add(1);

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.IsTrue(list.Contains(1));
        }

        [TestMethod]
        public void Remove_ItemFromList_ItemRemoved()
        {
            // Arrange
            var list = new CircularLinkedList<int>();
            list.Add(1);

            // Act
            var result = list.Remove(1);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, list.Count);
            Assert.IsFalse(list.Contains(1));
        }

        [TestMethod]
        public void Remove_ItemNotInList_ReturnsFalse()
        {
            // Arrange
            var list = new CircularLinkedList<int>();
            list.Add(1);

            // Act
            var result = list.Remove(2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Clear_List_ListIsEmpty()
        {
            // Arrange
            var list = new CircularLinkedList<int>();
            list.Add(1);
            list.Add(2);

            // Act
            list.Clear();

            // Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void Contains_ItemInList_ReturnsTrue()
        {
            // Arrange
            var list = new CircularLinkedList<int>();
            list.Add(1);

            // Assert
            Assert.IsTrue(list.Contains(1));
        }

        [TestMethod]
        public void Contains_ItemNotInList_ReturnsFalse()
        {
            // Arrange
            var list = new CircularLinkedList<int>();

            // Assert
            Assert.IsFalse(list.Contains(1));
        }
    }
}

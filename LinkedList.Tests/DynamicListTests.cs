namespace LinkedList.Tests
{
    using System;

    using CustomLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTests
    {
        private DynamicList<int> dynamicList;
            
        [TestInitialize]
        public void InitDynamicList()
        {
            this.dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        public void EmptyListCountAfterAddingTwoTimes()
        {
            const int expectedCount = 2;
            for (int i = 0; i < expectedCount; i++)
            {
                this.dynamicList.Add(i);
            }

            Assert.AreEqual(
                expectedCount,
                this.dynamicList.Count,
                "Count failed: it should have been {0}. Test output: {1}",
                    expectedCount,
                    this.dynamicList.Count);
        }

        [TestMethod]
        public void TestDynamicListAdd()
        {
            var firstListItem = 5;
            var secondListItem = 15;
            var thirdListItem = 50;

            this.dynamicList.Add(firstListItem);
            this.dynamicList.Add(secondListItem);
            this.dynamicList.Add(thirdListItem);

            var expectedListItems = string.Format(
                "{0}, {1}, {2}",
                firstListItem,
                secondListItem,
                thirdListItem);
            var testListItem = string.Format(
                "{0}, {1}, {2}",
                this.dynamicList[0],
                this.dynamicList[1],
                this.dynamicList[2]);

            Assert.AreEqual(
                expectedListItems,
                testListItem,
                "List.Add() failed -> Expected list items: {0}. Test list items: {1}",
                    expectedListItems,
                    testListItem);
        }

        [TestMethod]
        public void TestEmptyListContains()
        {
            var testEmptyListContains = this.dynamicList.Contains(4);

            Assert.IsFalse(
                testEmptyListContains,
                "Empty List.Contains() failed -> Expected list items: False. Contains value: {0}",
                    testEmptyListContains);
        }

        public void ListContainsTestedValue()
        {
            var firstListItem = 5;
            var secondListItem = 15;
            var thirdListItem = 50;

            this.dynamicList.Add(firstListItem);
            this.dynamicList.Add(secondListItem);
            this.dynamicList.Add(thirdListItem);

            var containsSecondListValue = this.dynamicList.Contains(secondListItem);
            Assert.IsTrue(
                containsSecondListValue,
                "List.Contains() failed -> Expected list items: True. Contains value: {0}",
                    containsSecondListValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAccessingElementOfAnEmptyList()
        {
            var item = this.dynamicList[0];
        }
    }
}

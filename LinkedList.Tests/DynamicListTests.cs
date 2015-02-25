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
            var expectedCount = 2;
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

        [TestMethod]
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

        [TestMethod]
        public void TestRemoveContainedElement()
        {
            var expectedCount = 2;
            for (int i = 0; i < expectedCount; i++)
            {
                this.dynamicList.Add(i);
            }

            Assert.AreEqual(expectedCount, this.dynamicList.Count);

            this.dynamicList.Remove(1);
            Assert.AreEqual(
                1,
                this.dynamicList.Count,
                "List.Remove() failed -> Expected list element count: 1. Contains value: {0}",
                    this.dynamicList.Count);
        }

        [TestMethod]
        public void TestRemoveNotContainedElement()
        {
            var expectedCount = 2;
            for (int i = 0; i < expectedCount; i++)
            {
                this.dynamicList.Add(i);
            }

            Assert.AreEqual(expectedCount, this.dynamicList.Count);

            var removeMethodOutputValue = this.dynamicList.Remove(2);

            Assert.AreEqual(
                -1,
                removeMethodOutputValue,
                "List.Remove() failed -> Expected return value when element not found: -1. Actual return value: {0}",
                    removeMethodOutputValue);
        }

        [TestMethod]
        public void TestRemoveElementAtValidIndex()
        {
            var firstListItem = 5;
            var secondListItem = 15;
            var thirdListItem = 50;

            this.dynamicList.Add(firstListItem);
            this.dynamicList.Add(secondListItem);
            this.dynamicList.Add(thirdListItem);

            Assert.AreEqual(secondListItem, this.dynamicList[1]);

            this.dynamicList.RemoveAt(1);

            Assert.AreEqual(
                thirdListItem,
                this.dynamicList[1],
                "List.RemoveAt() failed -> Expected list element count: {0}. Contains value: {1}",
                    thirdListItem,
                    this.dynamicList[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveElementAtInvalidIndex()
        {
            this.dynamicList.RemoveAt(1);
        }

        [TestMethod]
        public void TestElementSetterAtValidIndex()
        {
            var assignedValue = 5;
            this.dynamicList.Add(2);
            this.dynamicList.Add(2);
            this.dynamicList.Add(2);
            this.dynamicList[2] = assignedValue;

            Assert.AreEqual(
                assignedValue,
                this.dynamicList[2],
                "List element setter failed -> Expected value at position [0]: {0}. Actual value: {1}",
                    assignedValue,
                    this.dynamicList[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestElementSetterAtInvalidIndex()
        {
            var assignedValue = 5;
            this.dynamicList.Add(2);
            this.dynamicList[2] = assignedValue;
        }
    }
}

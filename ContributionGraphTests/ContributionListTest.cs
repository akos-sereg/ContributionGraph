using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContributionGraph.Model;

namespace ContributionGraphTests
{
    [TestClass]
    public class ContributionListTest
    {
        [TestMethod]
        public void List_Aggregating_Works()
        {
            // Arrange
            ContributionList list = new ContributionList();

            // Act
            list.Add(new ContributionItem { Date = DateTime.Parse("2015-01-01"), ContributionCount = 1, Subject = "App.config" });
            list.Add(new ContributionItem { Date = DateTime.Parse("2015-01-01"), ContributionCount = 3, Subject = "Subject" });

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(4, list[0].ContributionCount);
        }

        [TestMethod]
        public void List_AggregatingDifferentDates_Works()
        {
            // Arrange
            ContributionList list = new ContributionList();

            // Act
            list.Add(new ContributionItem { Date = DateTime.Parse("2015-01-01"), ContributionCount = 1, Subject = "App.config" });
            list.Add(new ContributionItem { Date = DateTime.Parse("2015-01-01"), ContributionCount = 3, Subject = "Subject" });
            list.Add(new ContributionItem { Date = DateTime.Parse("2015-01-02"), ContributionCount = 1, Subject = "Contribution on different date" });

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(4, list[0].ContributionCount);
            Assert.AreEqual(1, list[1].ContributionCount);
        }

        [TestMethod]
        public void List_AggregatingCommits_Works()
        {
            // Arrange
            ContributionList list = new ContributionList();

            // Act
            list.Add(new Commit { Date = DateTime.Parse("2015-01-01"), Title = "Commit message" });
            list.Add(new Commit { Date = DateTime.Parse("2015-01-01"), Title = "Another commit message" });
            
            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(2, list[0].ContributionCount);
        }

        [TestMethod]
        public void List_AggregatingCommitsDifferentDates_Works()
        {
            // Arrange
            ContributionList list = new ContributionList();

            // Act
            list.Add(new Commit { Date = DateTime.Parse("2015-01-01"), Title = "Commit message" });
            list.Add(new Commit { Date = DateTime.Parse("2015-01-01"), Title = "Another commit message" });
            list.Add(new Commit { Date = DateTime.Parse("2015-01-02"), Title = "Commit on different date" });

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(2, list[0].ContributionCount);
            Assert.AreEqual(1, list[1].ContributionCount);
        }
    }
}

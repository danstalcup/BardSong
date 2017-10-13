using System;
using NUnit;
using NUnit.Framework;
using BardSong;
using AutoMoq;
using Moq;

namespace Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        private AutoMoqer mocker;
        private Repository classUnderTest;

        [SetUp]
        public void SetUp()
        {
            mocker = new AutoMoqer();
            classUnderTest = mocker.Create<Repository>();
        }

        [Test]
        public void AddThenGet_AddOne_FindsAddedWhenGetForSameTypeCalled()
        {
            // act
            classUnderTest.Add(string.Empty);

            // assert
            Assert.That(classUnderTest.Get<string>().Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_AddOne_FindsAddedWhenGetForBaseTypeCalled()
        {
            // act
            classUnderTest.Add(string.Empty);

            // assert
            Assert.That(classUnderTest.Get<object>().Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_AddOne_EmptyWhenGetForZeroTypeCalled()
        {
            // act
            classUnderTest.Add(string.Empty);

            // assert
            Assert.That(classUnderTest.Get<int>().Count, Is.EqualTo(0));
        }
    }   
            
}

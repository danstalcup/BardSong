using AutoMoq;
using BardSong;
using BardSong.Impl;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class DataSetManagerTests
    {
        private AutoMoqer mocker;
        private DataSetManager classUnderTest;

        [SetUp]
        public void SetUp()
        {
            mocker = new AutoMoqer();
            classUnderTest = mocker.Create<DataSetManager>();
        }

        [Test]
        public void GetDataSet_NonNullDataSetReturned()
        {                        
            //assert
            Assert.That(classUnderTest.GetDataSet("test"), Is.Not.Null);
        }

        [Test]
        public void GetDataSet_SameNames_SameDataSets()
        {
            //assert
            Assert.That(classUnderTest.GetDataSet("test"), Is.EqualTo(classUnderTest.GetDataSet("test")));
        }

        [Test]
        public void GetDataSet_DifferentNames_DifferentDataSets()
        {
            //assert
            Assert.That(classUnderTest.GetDataSet("test1"), Is.Not.EqualTo(classUnderTest.GetDataSet("test2")));
        }
    }
}

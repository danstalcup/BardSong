using System;
using NUnit;
using NUnit.Framework;
using BardSong;
using AutoMoq;
using Moq;
using BardSong.Impl;

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
        public void Add_GetRepositoryOfObjectTypeCalled()
        {
            //arrange
           
           this.mocker
                .GetMock<IDataSetManager>()
                .Setup(x => x.GetDataSet(It.IsAny<string>())).Returns(this.mocker.GetMock<IDataSet>().Object);

            //act
            classUnderTest.Add(new Int16());

            //assert
            this.mocker.GetMock<IDataSetManager>().Verify(x => x.GetDataSet("Int16"), Times.Once());

        }

        [Test]
        public void Add_AddToDataSetCalled()
        {
            //arrange
            this.mocker
                 .GetMock<IDataSetManager>()
                 .Setup(x => x.GetDataSet(It.IsAny<string>())).Returns(this.mocker.GetMock<IDataSet>().Object);

            var item = new Int16();

            //act        
            classUnderTest.Add(item);

            //assert            
            this.mocker.GetMock<IDataSet>().Verify(x => x.Add(item), Times.Once());

        }
    }
}

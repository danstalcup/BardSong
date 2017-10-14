using System;
using NUnit;
using NUnit.Framework;
using BardSong;
using AutoMoq;
using Moq;
using System.Collections.Generic;
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
            this.mocker = new AutoMoqer();
            this.classUnderTest = mocker.Create<Repository>();

            var dataSet = new DataSet();

            this.mocker.GetMock<IDataSet>().Setup(ds => ds.Data).Returns(dataSet.Data);
            this.mocker.GetMock<IDataSet>().Setup(ds => ds.DataTypes).Returns(dataSet.DataTypes);
        }       

        [Test]
        public void Write_CallsWritersWrite()
        {
            // act
            classUnderTest.Write();

            // assert
            this.mocker.GetMock<IRepositoryWriter>().Verify(iw => iw.Write(classUnderTest), Times.Once());
        }

        [Test]
        public void Add_CallsDataSetsWrite()
        {
            var item = new Test_A();

            // act
            classUnderTest.Add(item);

            // assert
            this.mocker.GetMock<IDataSet>().Verify(ds => ds.Add(item), Times.Once());
        }

        [Test]
        public void Get_NoArg_CallsDataSetsGet_False()
        {            
            // act
            classUnderTest.Get<Test_A>();

            // assert
            this.mocker.GetMock<IDataSet>().Verify(ds => ds.Get<Test_A>(false), Times.Once());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Get_Bool_CallsDataSetsGet_SameBool(bool useExactOnly)
        {
            // act
            classUnderTest.Get<Test_A>(useExactOnly);

            // assert
            this.mocker.GetMock<IDataSet>().Verify(ds => ds.Get<Test_A>(useExactOnly), Times.Once());
        }
    }   
            
}

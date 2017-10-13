using AutoMoq;
using BardSong;
using BardSong.Impl;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class RepositoryWriterTests
    {
        private AutoMoqer mocker;
        private RepositoryWriter classUnderTest;
        private Repository repository;

        [SetUp]
        public void SetUp()
        {
            mocker = new AutoMoqer();
            classUnderTest = mocker.Create<RepositoryWriter>();
            repository = mocker.Create<Repository>();       
        }

        [Test]
        public void Write_OneTypeInDataSet_WriteToFileCalledTwice()
        {
            //arrange
            this.mocker.GetMock<IDataSet>().Setup(ds => ds.DataTypes).Returns(new HashSet<Type> { typeof(Test_A) });

            //act
            classUnderTest.Write(repository);

            //assert
            //this.mocker.GetMock<IFileWriter>().Verify(ifw => ifw.WriteToFile(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
        }
    }
}

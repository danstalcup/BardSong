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
    public class RepositoryWriterTests
    {
        private AutoMoqer mocker;
        private RepositoryWriter classUnderTest;

        [SetUp]
        public void SetUp()
        {
            mocker = new AutoMoqer();
            classUnderTest = mocker.Create<RepositoryWriter>();            
        }

        [Test]
        public void Write_ObjectOneTypeAdded_WriteToFileCalledOnce()
        {
            //arrange
            //repository.Add(new Test_A())
        }
    }
}

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
        public void AddThenGet_AddOne_FindsAddedWhenGetForSameTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());

            // assert
            Assert.That(classUnderTest.Get<Test_A>().Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_AddOne_FindsAddedWhenGetForBaseTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());

            // assert
            Assert.That(classUnderTest.Get<Test_Base>().Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_AddOne_EmptyWhenGetForDifferentTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());

            // assert
            Assert.That(classUnderTest.Get<Test_B>().Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThenGet_AddOne_OneWhenGetForImplementedInterfaceCalled()
        {
            // act
            classUnderTest.Add(new Test_A());

            // assert
            Assert.That(classUnderTest.Get<ITest_A>().Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_AddOne_EmptyWhenGetForOtherInterfaceCalled()
        {
            // act
            classUnderTest.Add(new Test_A());

            // assert
            Assert.That(classUnderTest.Get<ITest_B>().Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThenGet_AddOne_OneWhenGetForBaseInterfaceCalled()
        {
            // act
            classUnderTest.Add(new Test_A());

            // assert
            Assert.That(classUnderTest.Get<ITest_Base>().Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_AddOneOfTypeOneOfBaseType_EmptyWhenGetForDifferentTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_Base());

            // assert
            Assert.That(classUnderTest.Get<Test_B>().Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThenGet_AddOneOfTypeOneOfBaseType_TwoWhenGetForBaseTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_Base());

            // assert
            Assert.That(classUnderTest.Get<Test_Base>().Count, Is.EqualTo(2));
        }

        [Test]
        public void AddThenGet_AddOneOfTypeOneOfBaseType_OneWhenGetForSameTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_Base());

            // assert
            Assert.That(classUnderTest.Get<Test_A>().Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_AddOneOfTypeOneOfDifferentType_SameBaseType_OneWhenGetForSameTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_B());

            // assert
            Assert.That(classUnderTest.Get<Test_A>().Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_AddOneOfTypeOneOfDifferentType_SameBaseType_OneWhenGetForSecondTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_B());

            // assert
            Assert.That(classUnderTest.Get<Test_B>().Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_AddOneOfTypeOneOfDifferentType_SameBaseType_TwoWhenGetForBaseTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_B());

            // assert
            Assert.That(classUnderTest.Get<Test_Base>().Count, Is.EqualTo(2));
        }

        [Test]
        public void AddThenGet_AddOneOfTypeOneOfDifferentType_SameBaseType_EmptyWhenGetForOtherTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_B());

            // assert
            Assert.That(classUnderTest.Get<Test_C>().Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThenGet_AddOneOfTypeOneOfDifferentType_SameBaseType_TwoWhenMultipleLevelsOfBaseTypesCalled()
        {
            // act
            classUnderTest.Add(new Test_A_A());
            classUnderTest.Add(new Test_A_B());

            // assert
            Assert.That(classUnderTest.Get<Test_Base>().Count, Is.EqualTo(2));
            Assert.That(classUnderTest.Get<Test_A>().Count, Is.EqualTo(2));
        }

        [Test]
        public void AddThenGet_AddOneOfTypeOneOfSubType_TwoWhenSameTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A_A());
            classUnderTest.Add(new Test_A());

            // assert            
            Assert.That(classUnderTest.Get<Test_A>().Count, Is.EqualTo(2));
        }

        [Test]
        public void AddThenGet_AddOneOfTypeOneOfSubType_OneWhenSubTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A_A());
            classUnderTest.Add(new Test_A());

            // assert            
            Assert.That(classUnderTest.Get<Test_A_A>().Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_AddOneOfTypeOneOfSubType_TwoWhenBaseTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A_A());
            classUnderTest.Add(new Test_A());

            // assert            
            Assert.That(classUnderTest.Get<Test_Base>().Count, Is.EqualTo(2));
        }

        public void AddThenGet_ExactMatchOnly_AddOne_FindsAddedWhenGetForSameTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());

            // assert
            Assert.That(classUnderTest.Get<Test_A>(true).Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOne_EmptyWhenGetForBaseTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());

            // assert
            Assert.That(classUnderTest.Get<Test_Base>(true).Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOne_EmptyWhenGetForDifferentTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());

            // assert
            Assert.That(classUnderTest.Get<Test_B>(true).Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOne_EmptyWhenGetForImplementedInterfaceCalled()
        {
            // act
            classUnderTest.Add(new Test_A());

            // assert
            Assert.That(classUnderTest.Get<ITest_A>(true).Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOne_EmptyWhenGetForOtherInterfaceCalled()
        {
            // act
            classUnderTest.Add(new Test_A());

            // assert
            Assert.That(classUnderTest.Get<ITest_B>(true).Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOne_EmptyWhenGetForBaseInterfaceCalled()
        {
            // act
            classUnderTest.Add(new Test_A());

            // assert
            Assert.That(classUnderTest.Get<ITest_Base>(true).Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOneOfTypeOneOfBaseType_EmptyWhenGetForDifferentTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_Base());

            // assert
            Assert.That(classUnderTest.Get<Test_B>(true).Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOneOfTypeOneOfBaseType_OneWhenGetForBaseTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_Base());

            // assert
            Assert.That(classUnderTest.Get<Test_Base>(true).Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOneOfTypeOneOfBaseType_OneWhenGetForSameTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_Base());

            // assert
            Assert.That(classUnderTest.Get<Test_A>(true).Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOneOfTypeOneOfDifferentType_SameBaseType_OneWhenGetForSameTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_B());

            // assert
            Assert.That(classUnderTest.Get<Test_A>(true).Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOneOfTypeOneOfDifferentType_SameBaseType_OneWhenGetForSecondTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_B());

            // assert
            Assert.That(classUnderTest.Get<Test_B>(true).Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOneOfTypeOneOfDifferentType_SameBaseType_EmptyWhenGetForBaseTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_B());

            // assert
            Assert.That(classUnderTest.Get<Test_Base>(true).Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOneOfTypeOneOfDifferentType_SameBaseType_EmptyWhenGetForOtherTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A());
            classUnderTest.Add(new Test_B());

            // assert
            Assert.That(classUnderTest.Get<Test_C>(true).Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOneOfTypeOneOfDifferentType_SameBaseType_EmptyWhenMultipleLevelsOfBaseTypesCalled()
        {
            // act
            classUnderTest.Add(new Test_A_A());
            classUnderTest.Add(new Test_A_B());

            // assert
            Assert.That(classUnderTest.Get<Test_Base>(true).Count, Is.EqualTo(0));
            Assert.That(classUnderTest.Get<Test_A>(true).Count, Is.EqualTo(0));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOneOfTypeOneOfSubType_OneWhenSameTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A_A());
            classUnderTest.Add(new Test_A());

            // assert            
            Assert.That(classUnderTest.Get<Test_A>(true).Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOneOfTypeOneOfSubType_OneWhenSubTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A_A());
            classUnderTest.Add(new Test_A());

            // assert            
            Assert.That(classUnderTest.Get<Test_A_A>(true).Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThenGet_ExactMatchOnly_AddOneOfTypeOneOfSubType_EmptyWhenBaseTypeCalled()
        {
            // act
            classUnderTest.Add(new Test_A_A());
            classUnderTest.Add(new Test_A());

            // assert            
            Assert.That(classUnderTest.Get<Test_Base>(true).Count, Is.EqualTo(0));
        }        

        [Test]
        public void Write_CallsWritersWrite()
        {
            // act
            classUnderTest.Write();

            // assert
            this.mocker.GetMock<IRepositoryWriter>().Verify(iw => iw.Write(classUnderTest), Times.Once());
        }
    }   
            
}

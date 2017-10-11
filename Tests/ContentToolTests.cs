using System;
using NUnit;
using NUnit.Framework;
using BardSong;

namespace Tests
{
    [TestFixture]
    public class BardSongTests
    {
        [Test]
        public void ContentToolConstructor_NoArgument_FilepathEmpty()
        {
            //act
            var result = new ContentTool();

            //assert
            Assert.That(result.Filepath, Is.EqualTo(string.Empty));
        }

        [Test]
        public void ContentToolConstructor_StringArgument_FilepathSameString()
        {
            //act
            var result = new ContentTool("C:\\");

            //assert
            Assert.That(result.Filepath, Is.EqualTo("C:\\"));
        }
    }
}

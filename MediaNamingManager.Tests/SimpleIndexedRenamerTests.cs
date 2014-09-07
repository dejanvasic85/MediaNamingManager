using NUnit.Framework;

namespace MediaNamingManager.Tests
{
    [TestFixture]
    public class SimpleIndexedRenamerTests
    {
        [Test]
        public void RenameToEpisode_SingleEpisodeSingleDigit_ReturnsString()
        {
            // arrange 
            var renamer = new SimpleIndexedRenamer();
            var result = renamer.RenameToEpisode(1, "whatever.mkv", 1);

            Assert.That(result, Is.EqualTo("s01e01.mkv"));
        }

        [Test]
        public void RenameToEpisode_SingleEpisodeMultiDigits_ReturnsString()
        {
            // arrange 
            var renamer = new SimpleIndexedRenamer();
            var result = renamer.RenameToEpisode(10, "whatever.mkv", 10);

            Assert.That(result, Is.EqualTo("s10e10.mkv"));
        }
    }
}
using NUnit.Framework;

namespace MediaNamingManager.Tests
{
    [TestFixture]
    public class SimpleNumberedParserTests
    {
        [Test]
        public void RenameToEpisode_SingleEpisodeSingleDigit_ReturnsString()
        {
            // arrange 
            var renamer = new SimpleNumberedParser();
            var result = renamer.RenameToEpisode(1, "101.mkv");

            Assert.That(result, Is.EqualTo("s01e01.mkv"));
        }

        [Test]
        public void RenameToEpisode_SingleEpisodeMultiDigits_ReturnsString()
        {
            // arrange 
            var renamer = new SimpleNumberedParser();
            var result = renamer.RenameToEpisode(10, "110.mkv");

            Assert.That(result, Is.EqualTo("s10e10.mkv"));
        }
        
        [Test]
        public void RenameToEpisode_SingleEpisodeSingleDigitWithEpisodeName_ReturnsString()
        {
            // arrange 
            var renamer = new SimpleNumberedParser();
            var result = renamer.RenameToEpisode(1, "101 - Death Has A Shadow.avi");

            Assert.That(result, Is.EqualTo("s01e01 - Death Has A Shadow.avi"));
        }

        [Test]
        public void RenameToEpisode_TwoGuysAndGirl_ReturnsString()
        {
            // arrange 
            var renamer = new SimpleNumberedParser();
            var result = renamer.RenameToEpisode(1, "101.-.Two.Guys.a.Girl.-.The.Pilot.[Buck].avi");

            Assert.That(result, Is.EqualTo("s01e01.avi"));
        }

    }
}
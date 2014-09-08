using NUnit.Framework;

namespace MediaNamingManager.Tests
{
    [TestFixture]
    public class StripRubbishParserTests
    {
        [Test]
        public void RenameToEpisode_SingleEpisodeSingleDigit_ReturnsString()
        {
            // arrange 
            var renamer = new StripRubbishParser();
            var result = renamer.RenameToEpisode(5, "dexter.s05e01.hdtv.xvid-fqm.avi");

            Assert.That(result, Is.EqualTo("s05e01.avi"));
        }

        [Test]
        public void RenameToEpisode_SingleEpisodeMultiDigits_ReturnsString()
        {
            // arrange 
            var renamer = new StripRubbishParser();
            var result = renamer.RenameToEpisode(5, "dexter.s05e10.hdtv.xvid-2hd.mkv");

            Assert.That(result, Is.EqualTo("s05e10.mkv"));
        }

        [Test]
        public void RenameToEpisode_SingleEpisodeMultiDigitsWithUpperCasing_ReturnsString()
        {
            // arrange 
            var renamer = new StripRubbishParser();
            var result = renamer.RenameToEpisode(5, "dexter.S05E10.hdtv.xvid-2hd.mkv");

            Assert.That(result, Is.EqualTo("S05E10.mkv"));
        }
    }
}
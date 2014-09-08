using NUnit.Framework;

namespace MediaNamingManager.Tests
{
    [TestFixture]
    public class SeasonDashNumberAndNamerParserTest
    {
        [Test]
        public void RenameToEpisode_SingleEpisodeSingleDigit_ReturnsString()
        {
            // arrange 
            var renamer = new SeasonDashNumberAndNameParser();
            var result = renamer.RenameToEpisode(4, "4-02 Remains to be Seen.avi");

            Assert.That(result, Is.EqualTo("s04e02 - Remains to be Seen.avi"));
        }

        [Test]
        public void RenameToEpisode_SingleEpisodeMultiDigits_ReturnsString()
        {
            // arrange 
            var renamer = new SeasonDashNumberAndNameParser();
            var result = renamer.RenameToEpisode(4, "4-11 Hello, Dexter Morgan.avi");

            Assert.That(result, Is.EqualTo("s04e11 - Hello, Dexter Morgan.avi"));
        }
    }
}
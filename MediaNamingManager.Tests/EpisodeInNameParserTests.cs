using NUnit.Framework;

namespace MediaNamingManager.Tests
{
    [TestFixture]
    public class EpisodeInNameParserTests
    {
        [Test]
        public void RenameToEpisode_SingleEpisodeSingleDigitEpisodeNumber_ReturnsString()
        {
            // arrange 
            var renamer = new EpisodeInNameParser();
            var result = renamer.RenameToEpisode(4, "The Office Season 4 Episode 01.avi");

            Assert.That(result, Is.EqualTo("s04e01.avi"));
        }

    }
}
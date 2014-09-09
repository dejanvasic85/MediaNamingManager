using NUnit.Framework;

namespace MediaNamingManager.Tests
{
    [TestFixture]
    public class SimpleNumberedWithEpisodeTextParserTests
    {
        [Test]
        public void RenameToEpisode_SingleEpisodeSingleDigit_ReturnsString()
        {
            // arrange 
            var renamer = new SimpleNumberedWithEpisodeTextParser();
            var result = renamer.RenameToEpisode(4, "Parks and Recreation - Episode 401 - Im Leslie Knope.avi");

            Assert.That(result, Is.EqualTo("s04e01 - Im Leslie Knope.avi"));
        }

        [Test]
        public void RenameToEpisode_NoSeriesNameSingleEpisodeSingleDigit_ReturnsString()
        {
            // arrange 
            var renamer = new SimpleNumberedWithEpisodeTextParser();
            var result = renamer.RenameToEpisode(4, "Episode 401 - Im Leslie Knope.avi");

            Assert.That(result, Is.EqualTo("s04e01 - Im Leslie Knope.avi"));
        }
    }
}
using NUnit.Framework;

namespace MediaNamingManager.Tests
{
    [TestFixture]
    public class EpiInNameParserTests
    {
        [Test]
        public void RenameToEpisode_SingleEpisodeSingleDigitEpisodeNumber_ReturnsString()
        {
            // arrange 
            var renamer = new EpiInNameParser();
            var result = renamer.RenameToEpisode(2, "S02 Epi1 - My Overkill.avi");

            Assert.That(result, Is.EqualTo("s02e01 - My Overkill.avi"));
        }

        [Test]
        public void RenameToEpisode_MultiDigit_ReturnsString()
        {
            // arrange 
            var renamer = new EpiInNameParser();
            var result = renamer.RenameToEpisode(10, "Modern Family S10 Epi10 whatever.avi");

            Assert.That(result, Is.EqualTo("s10e10 - whatever.avi"));
        }
    }
}
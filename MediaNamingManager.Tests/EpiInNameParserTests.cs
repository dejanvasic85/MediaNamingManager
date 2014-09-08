using NUnit.Framework;

namespace MediaNamingManager.Tests
{
    [TestFixture]
    public class EpiInNameParserTests
    {
        [Test]
        public void RenameToEpisode_SingleEpisodeSingleDigit_ReturnsString()
        {
            // arrange 
            var renamer = new EpiInNameParser();
            var result = renamer.RenameToEpisode(2, "Modern Family S02 Epi01 Pilot.avi");

            Assert.That(result, Is.EqualTo("s02e01 - Pilot.avi"));
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
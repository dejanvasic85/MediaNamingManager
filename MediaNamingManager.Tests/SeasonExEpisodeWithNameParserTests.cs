using NUnit.Framework;

namespace MediaNamingManager.Tests
{
    [TestFixture]
    public class SeasonExEpisodeWithNameParserTests
    {
        [Test]
        public void RenameToEpisode_SingleEpisodeSingleDigit_ReturnsString()
        {
            // arrange 
            var renamer = new SeasonExEpisodeWithNameParser();
            var result = renamer.RenameToEpisode(1, "Futurama 01x01 - Space Pilot 3000.avi");

            Assert.That(result, Is.EqualTo("s01e01 - Space Pilot 3000.avi"));
        }

        [Test]
        public void RenameToEpisode_SingleEpisodeMultiDigit_ReturnsString()
        {
            // arrange 
            var renamer = new SeasonExEpisodeWithNameParser();
            var result = renamer.RenameToEpisode(10, "Futurama 10x10 - Space Pilot 3000.avi");

            Assert.That(result, Is.EqualTo("s10e10 - Space Pilot 3000.avi"));
        }
        
        [Test]
        public void RenameToEpisode_TheSimpsons_ReturnsString()
        {
            // arrange 
            var renamer = new SeasonExEpisodeWithNameParser();
            var result = renamer.RenameToEpisode(3, "Simpsons 03x01 - Stark Raving Dad [rl-dvd].avi");

            Assert.That(result, Is.EqualTo("s03e01 - Stark Raving Dad [rl-dvd].avi"));
        }
    }
}
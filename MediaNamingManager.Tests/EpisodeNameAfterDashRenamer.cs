using System;
using NUnit.Framework;

namespace MediaNamingManager.Tests
{
    [TestFixture]
    public class EpisodeNameAfterDashRenamerTests
    {
        [Test]
        public void RenameToEpisode_SingleEpisodeSingleDigit_ReturnsString()
        {
            // arrange 
            var renamer = new EpisodeNameAfterDashParser();
            var result = renamer.RenameToEpisode(1, "Seinfeld Episode 01 - wahtevs.mks");

            Assert.That(result, Is.EqualTo("s01e01 - wahtevs.mks"));
        }

        [Test]
        public void RenameToEpisode_SingleEpisodeMultiDigit_ReturnsString()
        {
            // arrange 
            var renamer = new EpisodeNameAfterDashParser();
            var result = renamer.RenameToEpisode(1, "Seinfeld Episode 21 - wahtevs.mks");

            Assert.That(result, Is.EqualTo("s01e21 - wahtevs.mks"));
        }


        [Test]
        public void RenameToEpisode_TwoEpisodes_ReturnsString()
        {
            // arrange 
            var renamer = new EpisodeNameAfterDashParser();
            var result = renamer.RenameToEpisode(1, "Seinfeld Episode 21 & 22 - wahtevs.mks");

            Assert.That(result, Is.EqualTo("s01e21-e22 - wahtevs.mks"));
        }

        [Test]
        public void RenameToEpisode_NameContainsDash_ReturnsString()
        {
            // arrange 
            var renamer = new EpisodeNameAfterDashParser();

            var result = renamer.RenameToEpisode(5, "Seinfeld Season 05 Episode 07 - The Non-Fat Yogurt.mkv");

            Assert.That(result, Is.EqualTo("s05e07 - The Non-Fat Yogurt.mkv"));
        }
    }
}

## Get it ##

Coming soon (at chocolatey - most likely). Or just download the source, build in VS2013 and run it...

## Tasks ##

### Tv Series File Namer ##

Do you have episode file names that are not cosistent and systems such as [Plex does not recognise it?](https://support.plex.tv/hc/en-us/articles/200220687-Naming-Series-Season-Based-TV-Shows)

This command will rename your files in a target directory containing all episodes in a single season.

Currently the target naming style will always produce: *s01e01.avi*

**Parameters**

- Source Directory containing the episode files
- Season Number
- Source naming style codename ( refer to codenames below )


## Tv Naming Styles ##

Below you will find all the currently supported source naming styles and the suitable command. 

> Note: In all the parsers, the series name and season number should not affect finding the episode name and title (if available). E.g. Having Seinfeld 101 or just 101 should both work.

**Seinfeld Episode 01 - Pilot.avi** 


    MediaNamingManager.exe "C:\Senfield\Season 1" 1 nameafterdash


**101.avi**


    MediaNamingManager.exe "C:\Senfield\Season 1" 1 numbered


**1-01 Pilot.avi**


    MediaNamingManager.exe "C:\Senfield\Season 1" 1 seasondash


**Seinfeld.s01e01.pilot.hdtv.xvid-fqm.avi**

	MediaNamingManager.exe "C:\Senfield\Season 1" 1 striprubbish


**Seinfeld 01x01 - Pilot.avi**

	MediaNamingManager.exe "C:\Senfield\Season 1" 1 exepisode

**Seinfeld S01 Epi01 Pilot.avi**
 
	MediaNamingManager.exe "C:\Senfield\Season 1" 1 epi


**Episode 101 - Pilot.avi**
 
	MediaNamingManager.exe "C:\Senfield\Season 1" 1 episodenumbered


**Seinfeld Season 1 Episode 01.avi**

	MediaNamingManager.exe "C:\Senfield\Season 1" 1 episodeInName


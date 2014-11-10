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

**Indexed - ordered by file name** 

    MediaNamingManager.exe "C:\Senfield\Season 1" 1 indexed

This will process all files in the directory by simply getting the index of the file and using this as the episode number.

**Name after dash** _e.g. Seinfeld Episode 01 - Pilot.avi_

    MediaNamingManager.exe "C:\Senfield\Season 1" 1 nameafterdash


**Numbered** _e.g. 101.avi_

    MediaNamingManager.exe "C:\Senfield\Season 1" 1 numbered


**Season number followed by a Dash** _e.g. 1-01 Pilot.avi_


    MediaNamingManager.exe "C:\Senfield\Season 1" 1 seasondash


**Strip all text except s01e01** e.g. _Seinfeld.s01e01.pilot.hdtv.xvid-fqm.avi_

	MediaNamingManager.exe "C:\Senfield\Season 1" 1 striprubbish


**Season with x then Episode Number** e.g. _Seinfeld 01x01 - Pilot.avi_

	MediaNamingManager.exe "C:\Senfield\Season 1" 1 exepisode

**Has Epi text in front of episode number** e.g. _Seinfeld S01 Epi01 Pilot.avi_
 
	MediaNamingManager.exe "C:\Senfield\Season 1" 1 epi


**Simply numbered by Season then Episode number all in same text** _e.g. Episode 101 - Pilot.avi_
 
	MediaNamingManager.exe "C:\Senfield\Season 1" 1 episodenumbered


**Episode text in name followed by space and episode number** _e.g. Seinfeld Season 1 Episode 01.avi_

	MediaNamingManager.exe "C:\Senfield\Season 1" 1 episodeInName


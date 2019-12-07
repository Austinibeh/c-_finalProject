using System.Collections.Generic;
using System.Linq;

namespace MusicAnalyzer
{
    public static class MusicPlayReport
    {
        public static string GenerateText(List<MusicPlayStats> musicList)
        {
            string report = "Music Playlist Report\n\n";

            if (musicList.Count() < 1)
            {
                report += "No data is available.\n";

                return report;
            }

            report += "Names Genres per Name > 200: \n";
            var over200 = from music in musicList where music.Plays > 200 select music;

            foreach (MusicPlayStats music in over200)
            {
                report += music + "\n";
            }
            report += "\n";

            //report += "How many musicList are in the playlist with the Genre of “Alternative” ";
            var alter_count = (from music in musicList where music.Genre == "Alternative" select music).Count();
            //from music in musicList where music.Genre == "Pop" orderby music.Year descending select music;
            report += $"How many musicList are in the playlist with the Genre of “Alternative”: {alter_count}\n";


            //How many musicList are in the playlist with the Genre of “Hip - Hop / Rap”?
            var rap_count = (from music in musicList where music.Genre == "Hip-Hop/Rap" select music).Count();
            report += $"How many musicList are in the playlist with the Genre of “Hip Hop/Rap”: {rap_count}\n";
            report += "\n";

            //What musicList are in the playlist from the album “Welcome to the Fishbowl?”
            var fishbowl = from music in musicList where music.Album == "Welcome to the Fishbowl" select music;
            report += $"MusicPlayStatss from the album Welcome to the Fishbowl:";
            report += "\n";

            foreach (MusicPlayStats music in fishbowl)
            {
                report += music + "\n";
            }
            report += "\n";

            //What are the musicList in the playlist from before 1970 ?
            var pMusicPlayStats = from music in musicList where music.Year < 1970 select music;
            report += $"MusicPlayStatss from before 1970:";
            report += "\n";

            foreach (MusicPlayStats music in pMusicPlayStats)
            {
                report += music + "\n";
            }
            report += "\n";


            //What are the music names that are more than 85 characters long?

            var mChara = from music in musicList where music.Name.Length > 85 select music.Name;
            report += $"MusicPlayStats names longer than 85 characters:";
            report += "\n";
            foreach (var music in mChara)
            {
                report += music + "\n";
            }
            report += "\n";

            //What is the longest music ? (longest in Time)
            var maxTime = (from music in musicList select music.Time).Max();
            var longPlay = (from music in musicList where music.Time == maxTime select music);
            report += $"Longest music:";
            report += "\n";
            foreach (MusicPlayStats x in longPlay)
            {
                report += x + "\n";
            }
            report += "\n";

            return report;
        }
    }
}
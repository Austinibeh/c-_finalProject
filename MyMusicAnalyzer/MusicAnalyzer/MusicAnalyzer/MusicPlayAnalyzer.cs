using System;
using System.Collections.Generic;
using System.IO;



namespace MusicAnalyzer
{
    public static class MusicPlaylistAnalyzer
    {

        private static int NumItemsInRow = 8;

        public static List<MusicPlayStats> Load(string DataFilePath) //method to load the txt file and put the content of each line into a List array. 
        {
            List<MusicPlayStats> musicList = new List<MusicPlayStats>();

            try
            {
                using (var reader = new StreamReader(DataFilePath))
                {
                    int lineNumber = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        lineNumber++;
                        if (lineNumber == 1) continue;

                        var delimiter = '\t';

                        var data = line.Split(delimiter);

                        if (data.Length != NumItemsInRow)
                        {
                            throw new Exception($"Row {lineNumber} contains {data.Length} values. It should contain {NumItemsInRow}.");
                        }
                        try
                        {

                            //musicList.Add(new MusicPlayStats(data[0], data[1], data[2], data[3], Int32.Parse(data[4]), Int32.Parse(data[5]), Int32.Parse(data[6]), Int32.Parse(data[1])));

                            string name = (data[0]);
                            string artist = (data[1]);
                            string album = (data[2]);
                            string genre = (data[3]);
                            int size = Int32.Parse(data[4]);
                            int time = Int32.Parse(data[5]);
                            int year = Int32.Parse(data[6]);
                            int plays = Int32.Parse(data[7]);

                            MusicPlayStats music = new MusicPlayStats(name, artist, album, genre, size, time, year, plays);
                            musicList.Add(music);
                        }
                        catch (FormatException e)
                        {
                            throw new Exception($"Row {lineNumber} contains invalid data. ({e.Message})");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to open {DataFilePath} ({e.Message}).");
            }

            return musicList;
        }
    }
}



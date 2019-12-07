using System;
using System.Collections.Generic;
namespace MusicAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("CrimeAnalyzer <crime_csv_file_path> <report_file_path>");
                Environment.Exit(1);
            }

            string filePath = args[0];
            string reportPath = args[1];

            List<MusicPlayStats> musicList = null;
            try
            {
                musicList = MusicPlaylistAnalyzer.Load(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            }

            var report = MusicPlayReport.GenerateText(musicList);

            try
            {
                System.IO.File.WriteAllText(reportPath, report);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(3);
            }
        }
    }
}



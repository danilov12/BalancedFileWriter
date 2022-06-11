using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BalancedLog
{
    class Program
    {
        static async Task Main(string[] args)
        {
            BalancedLogWritter.CreateFolderWithFilesIfNeeded();
            List<LogRecord> logRecords = new List<LogRecord>();

            for (int i = 0; i < 40; i++)
            {
                LogRecord logRecord = new LogRecord(GenerateRandomString(), (RecordType)new Random().Next(1, 5));
                Console.WriteLine(logRecord);
                logRecords.Add(logRecord);
                Thread.Sleep(1);
            }

            await logRecords.ForEachAsync(async x => await BalancedLogWritter.SaveRecordAsync(x));

            await Directory.GetFiles(FileSystemInfo.rootDirectoryPath).ForEachAsync(async fileName =>
            {
                string[] allLines = await File.ReadAllLinesAsync(fileName);
                Console.WriteLine($"Total line number inside file: {fileName}: {allLines.Length}");
            });
        }

        private static string GenerateRandomString()
        {
            Random random = new Random();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 11; i++)
            {
                sb.Append((char)random.Next(97, 123));
            }

            return sb.ToString();
        }
    }
}

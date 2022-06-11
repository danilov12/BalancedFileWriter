using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedLog
{
    public static class LogReader
    {
        public static async Task<List<string>> ReadAllLogRecordsAsync()
        {
            List<string> allLogRecords = new List<string>();

            await FileSystemInfo.fileNames.Values.ForEachAsync(async fileName =>
            {
                string[] allRecords = await File.ReadAllLinesAsync(fileName.GetFilePath());
                allLogRecords.AddRange(allLogRecords.ToList());
            });

            return allLogRecords;
        }
    }
}

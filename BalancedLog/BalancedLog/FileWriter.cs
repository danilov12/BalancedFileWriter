using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace BalancedLog
{
    public static class FileWriter
    {
        public static async Task AppendTextAsync(string filePath, string logRecords)
        {
            await RemoveOldRecordsIfNeededAsync(filePath);

            using (StreamWriter streamWriter = File.AppendText(filePath))
            {
                await streamWriter.WriteLineAsync(logRecords);
            }
        }

        private static async Task RemoveOldRecordsIfNeededAsync(string filePath)
        {
            string[] allLines = await File.ReadAllLinesAsync(filePath);

            if (allLines.Count() >= 10)
            {
                await File.WriteAllLinesAsync(filePath, allLines.Skip(1));
            }
        }
    }
}

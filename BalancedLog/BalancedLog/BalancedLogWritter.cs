using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BalancedLog
{
    public static class BalancedLogWritter
    {
        #region DistributedHashing
        public static async Task SaveRecordAsync(LogRecord logRecord)
        {
            string filePath = GetFilePathByHashCode(logRecord.GetHashCode());

            await FileWriter.AppendTextAsync(filePath, logRecord.ToString());
        }

        private static string GetFilePathByHashCode(int hashCode)
        {
            int fileLocation = hashCode % FileSystemInfo.fileNames.Keys.Count;

            return FileSystemInfo.fileNames[fileLocation].GetFilePath();
        }
        #endregion

        #region FileHelpers
        public static void CreateFolderWithFilesIfNeeded()
        {
            if (!Directory.Exists(FileSystemInfo.rootDirectoryPath))
            {
                Directory.CreateDirectory(FileSystemInfo.rootDirectoryPath);
            }

            CreateFilesIfNeeded();
        }

        private static void CreateFilesIfNeeded()
        {
            FileSystemInfo.fileNames.Values.ForEach(fileName =>
            {
                string filePath = fileName.GetFilePath();

                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }
            });
        }
        #endregion
    }
}

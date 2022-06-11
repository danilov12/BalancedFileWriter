using System;
using System.Collections.Generic;
using System.Text;

namespace BalancedLog
{
    public static class FileSystemInfo
    {
        public static string rootDirectoryPath = "C:/logger";

        public static Dictionary<int, string> fileNames = new Dictionary<int, string>()
        {
            { 0, "file1.txt" },
            { 1, "file2.txt" },
            { 2, "file3.txt" },
            { 3, "file4.txt" }
        };
    }
}

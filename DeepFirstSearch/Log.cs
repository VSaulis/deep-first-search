using System.Collections.Generic;
using System.IO;

namespace DeepFirstSearch {
    public static class Log {
        private static readonly List<string> _log = new List<string>();
        private static readonly string _filePath = @"C:\Users\Vytautas\Desktop\AI\DeepFirstSearch\DeepFirstSearch\result\result.txt";

        public static void AddToLog(string record) {
            _log.Add(record);
        }

        public static void WriteToFile() {
            File.WriteAllLines(_filePath, _log);
        }

    }
}
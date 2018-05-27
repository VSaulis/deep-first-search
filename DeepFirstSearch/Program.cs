using System;
using ForwardChaining;

namespace DeepFirstSearch {
    class Program {
        static void Main(string[] args) {
            string path = @"C:\Users\Vytautas\Desktop\AI\DeepFirstSearch\DeepFirstSearch\tests\";
            DeepFirstSearch deepFirstSearch = new DeepFirstSearch(path + "Test3.txt");

            int i, j;

            Console.WriteLine("Please enter starting position i:");
            string input = Console.ReadLine();
            Int32.TryParse(input, out i);
            Console.WriteLine("Please enter starting position j:");
            input = Console.ReadLine();
            Int32.TryParse(input, out j);

            if (deepFirstSearch.Start(i - 1, j - 1)) {
                Log.AddToLog("Path found.");
                Log.WriteToFile();
            }
            else {
                Log.AddToLog("Path not found.");
                Log.WriteToFile();
            }
            Console.Read();
        }
    }
}
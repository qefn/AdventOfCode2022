namespace AdventOfCode2022.Solutions {
    public abstract class Solution {
        public abstract List<Action> Stages { get; }

        protected List<string> ReadInputFile(string inputFileName, string fileExtension = "txt") {
            string path = @$".\Inputs\{inputFileName}.{fileExtension}";
            if (!File.Exists(path)) {
                throw new InvalidOperationException($"The input file '{path}' does not exist!");
            }

            return File.ReadAllLines(path).ToList();
        }

    }
}
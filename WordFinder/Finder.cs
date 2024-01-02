namespace WordFinder
{
    public class Finder
    {
        private readonly IEnumerable<string> _grid;

        // Constructor that initializes the grid with input data
        public Finder(IEnumerable<string> input)
        {
            const int MaxGridSize = 64;

            if (input.Count() > MaxGridSize)
            {
                throw new ArgumentException($"Grid size exceeds maximum allowed size of {MaxGridSize}.");
            }

            int rowCount = input.Count();
            int columnCount = input.First().Length;

            if (!(rowCount == columnCount))
            {
                throw new ArgumentException("Grid must be square (have equal number of rows and columns).");
            }

            _grid = input;
        }

        // Method to find words from a wordstream in the grid
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            if (wordstream is null) return new List<string>();

            // Extract all words from the grid
            var wordsInMatrixHorizontal = ExtractHorizontalWordsFromMatrix(_grid);
            var wordsInMatrixVertical = ExtractVerticalWordsFromMatrix(_grid);

            // Dictionary to store word frequency
            var wordFrequency = new Dictionary<string, int>();

            // Loop through each word in the wordstream
            foreach (var word in wordstream)
            {
                // Count occurrences of the word in the grid
                int countHorizontal = CountOccurrences(word, wordsInMatrixHorizontal);
                int countVertical = CountOccurrences(word, wordsInMatrixVertical);

                wordFrequency[word] = countHorizontal + countVertical; // Store word frequency
            }

            // Get top N words based on frequency
            return GetTopNWords(wordFrequency, 10);
        }

        // Extracts words from the matrix/grid
        private List<string> ExtractHorizontalWordsFromMatrix(IEnumerable<string> matrix)
        {
            var words = new List<string>();
            foreach (var row in matrix)
            {
                var rowWords = row.Replace(",", "");
                words.Add(rowWords);
            }
            return words;
        }

        private List<string> ExtractVerticalWordsFromMatrix(IEnumerable<string> matrix)
        {
            var verticalWords = new List<string>();

            // Iterates through each column of the matrix
            for (int i = 0; i < matrix.First().Length; i++)
            {
                string verticalWord = "";

                // Iterates through each row in the matrix
                foreach (var row in matrix)
                {
                    //assign the first letter of each row
                    verticalWord += row[i];
                }

                verticalWords.Add(verticalWord);
            }

            return verticalWords;
        }


        // Counts occurrences of a word in the grid
        private int CountOccurrences(string word, List<string> wordsInMatrix)
        {
            var horizontalCount = wordsInMatrix.Count(w => w.Contains(word));
            return horizontalCount;
        }

        // Get top N words based on their frequency
        private List<string> GetTopNWords(Dictionary<string, int> wordFrequency, int n)
        {
            return wordFrequency.OrderByDescending(pair => pair.Value)
                               .Take(n)
                               .Select(pair => $"{pair.Key}: {pair.Value}")
                               .ToList();
        }
    }
}

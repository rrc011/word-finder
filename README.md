# Word Finder Console Application

This console application, `Word Finder`, is designed to search for words in a grid matrix provided as input. The application scans both horizontally and vertically to find the specified words and then ranks them based on their frequency of occurrence.

## Usage

### Installation

No installation steps are required. Simply compile and run the application using your preferred .NET development environment.

### Running the Application

1. Open the solution in your .NET development environment.
2. Locate and run the `WordFinder` project.

### Using the Application

Upon running the application, it prompts the user to input words separated by commas (`,`) that they wish to search for within the grid matrix. Once the words are provided, the application processes the grid to find these words both horizontally and vertically. It then displays the top 10 words based on their frequency of occurrence in the grid.

## Functionality Overview

### `Finder` Class

#### Constructor

- `public Finder(IEnumerable<string> input)`: Initializes the grid with the provided input data.

#### Public Methods

- `public IEnumerable<string> Find(IEnumerable<string> wordstream)`: Searches for words from a wordstream in the grid and returns the top 10 words based on their frequency.

#### Private Methods

- `private List<string> ExtractHorizontalWordsFromMatrix(IEnumerable<string> matrix)`: Extracts words horizontally from the grid matrix.
- `private List<string> ExtractVerticalWordsFromMatrix(IEnumerable<string> matrix)`: Extracts words vertically from the grid matrix.
- `private int CountOccurrences(string word, List<string> wordsInMatrix)`: Counts occurrences of a word in the grid matrix.
- `private List<string> GetTopNWords(Dictionary<string, int> wordFrequency, int n)`: Gets the top N words based on their frequency.

## Testing

This application includes unit tests using NUnit to verify the functionality of the `Finder` class. The tests cover scenarios such as word searching, handling of null or empty inputs, word frequency calculations, and identification of non-existing words within the matrix.

For more details on unit testing, refer to the included test files in the `WordFinder.Tests` project.

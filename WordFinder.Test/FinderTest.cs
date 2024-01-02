using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.Test
{

    public class FinderTest
    {
        private Finder _wordFinder;

        [SetUp]
        public void Setup()
        {
            IEnumerable<string> matrix = new List<string>
            {
                "K,J,T,M,E,D,S,X,E,O,L,B,J,A,T",
                "I,C,Y,Y,A,V,S,S,R,R,P,F,W,P,W",
                "W,O,C,P,V,A,T,W,S,A,U,Q,A,P,B",
                "I,U,A,E,A,R,R,X,Y,N,A,X,T,B,O",
                "X,P,P,L,B,R,A,T,U,G,Z,M,E,A,X",
                "W,L,R,I,L,G,W,U,H,E,S,I,R,N,S",
                "W,L,R,I,L,G,W,U,H,E,S,I,R,A,S",
                "J,O,I,O,A,V,B,B,K,X,M,R,M,N,H",
                "C,G,C,A,C,E,E,X,H,M,R,D,E,A,X",
                "W,S,O,L,K,J,R,U,D,E,Z,X,L,A,U",
                "F,W,T,P,B,G,R,U,X,L,W,W,O,L,W",
                "K,P,L,E,E,K,Y,V,K,O,N,Y,N,U,R",
                "X,P,I,N,R,A,P,P,L,E,U,T,S,A,T",
                "O,E,N,C,R,L,U,C,H,E,R,R,Y,U,E",
                "N,D,B,S,N,Z,G,Y,Y,N,S,K,I,W,I"
            };

            _wordFinder = new Finder(matrix);
        }

        [Test]
        public void Find_WithValidWordStream_ReturnsTopNWords()
        {
            // Arrange
            IEnumerable<string> wordstream = new List<string> { "BANANA", "ORANGE", "KIWI" };

            // Act
            var result = _wordFinder.Find(wordstream);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void Find_WithEmptyWordStream_ReturnsEmptyList()
        {
            // Arrange
            IEnumerable<string> wordstream = new List<string>();

            // Act
            var result = _wordFinder.Find(wordstream);

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void Find_WithNullWordStream_ReturnsTopNWords()
        {
            // Arrange
            IEnumerable<string> wordstream = null;

            // Act
            var result = _wordFinder.Find(wordstream);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Find_WithNonExistingWords_ReturnsZero()
        {
            // Arrange
            IEnumerable<string> wordstream = new List<string> { "HELLO", "WORLD" };

            // Act
            var result = _wordFinder.Find(wordstream);

            // Assert
            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                var split = item.Split(":");
                if(split.Length > 0)
                {
                    int count = int.Parse(split[1]);
                    Assert.AreEqual(0, count);
                }
            }
        }

        [Test]
        public void Find_WithRepeatedWordsInMatrix_ReturnsCorrectFrequency()
        {
            // Arrange
            IEnumerable<string> matrixWithRepeatedWords = new List<string>
            {
                "H,E,L,L,O",
                "H,E,L,L,O" ,
                "W,O,R,L,D",
                "W,O,R,L,D",
                "H,E,L,L,O",
            };

            var finderWithRepeatedWords = new Finder(matrixWithRepeatedWords);

            IEnumerable<string> wordstream = new List<string> { "HELLO", "WORLD" };

            // Act
            var result = finderWithRepeatedWords.Find(wordstream);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count()); // Check if it returns 2 words (top 2)
        }
    }
}

using Game;

namespace WordFinderQUTest
{
    public class WordFinderTests
    {
        [Fact]
        public void FindTopTenMostRepeatedWords()
        {
            var matrix = new List<string>
            {
                "abcd",
                "efgh",
                "ijkl",
                "mnop"
            };
            var wordstream = new List<string> { "abc", "abc", "abcd", "abc", "abc", "def", "ghi" };
            var expectedWords = new List<string> { "abc", "abcd" };
            var wordFinder = new WordFinder(matrix);

            // Act
            var foundWords = wordFinder.Find(wordstream);

            // Assert
            Assert.NotNull(foundWords);
            Assert.Equal(expectedWords.Count, foundWords.Count());
            foreach (var word in expectedWords)
            {
                Assert.Contains(word, foundWords);
            }
        }
    }
}
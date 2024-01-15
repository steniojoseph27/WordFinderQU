namespace Game
{
    public class WordFinder
    {
        private readonly List<string> matrix;
        private readonly List<string> transposedMatrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            this.matrix = matrix.ToList();
            transposedMatrix = TransposedMatrix(matrix);
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var wordCount = wordstream.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            var uniqueWords = wordCount.Keys;
            var foundWords = new Dictionary<string, int>();
            foreach(var word in uniqueWords)
            {
                if(matrix.Any(row => row.Contains(word)) || transposedMatrix.Any(col => col.Contains(word)))
                {
                    foundWords.Add(word, wordCount[word]);
                }
            }
            return foundWords.OrderByDescending(pair => pair.Value)
                .Take(10)
                .Select(pair => pair.Key);
        }

        private List<string> TransposedMatrix(IEnumerable<string> matrix)
        {
            var transposed = new List<string>();
            if (!matrix.Any()) return transposed;

            int rows = matrix.Count();
            int cols = matrix.First().Length;

            for(int col = 0; col < cols; col++)
            {
                char[] colChars = new char[rows];
                int rowIndex = 0;
                foreach(var row in matrix)
                {
                    colChars[rowIndex++] = row[col];
                }
                transposed.Add(new string(colChars));
            }
            return transposed;
        }
    }
}

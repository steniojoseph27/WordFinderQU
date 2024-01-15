using Game;

public class Program
{
    private static void Main(string[] args)
    {
        var matrix = new List<string>
        {
            "abcd",
            "efgh",
            "ijkl",
            "mnop"
        };

        var wordstream = new List<string>
        {
            "ab",
            "efg",
            "hij",
            "klm",
            "nop",
            "abc",
            "mnop",
            "ijkl"
        };

        WordFinder wordFinder = new WordFinder(matrix);

        IEnumerable<string> foundWords = wordFinder.Find(wordstream);
        foreach (var word in foundWords)
        {
            Console.WriteLine(word);
        }
    }
}

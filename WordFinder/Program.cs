namespace WordFinder
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Word Search!");

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
            }; //words= orange,kiwi,banana,melon, etc...

            var finder = new Finder(matrix);

            Console.WriteLine("Input words to search separate by coma (,): ");
            var wordToSearch = Console.ReadLine();

            while (string.IsNullOrEmpty(wordToSearch))
            {
                Console.WriteLine("You must enter at least one word to search. Please enter a word: ");
                wordToSearch = Console.ReadLine();
            }

            var result = finder.Find(wordToSearch.Split(",").Select(x => x.ToUpper()).ToList());

            Console.WriteLine("************RESULTS************");
            foreach (var word in result)
            {
                Console.WriteLine($"{word}");
            }
        }
    }

}
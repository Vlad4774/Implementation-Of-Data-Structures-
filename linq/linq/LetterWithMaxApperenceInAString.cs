
namespace linq
{
    class LetterWithMaxApperenceInAString
    {
        string givenString;
        public LetterWithMaxApperenceInAString(string givenString) 
        {
            this.givenString = givenString;
        }

        public char LetterWithMaxApperence()
        {
            var grouped = givenString.GroupBy(c => c);
            var ordered = grouped.OrderBy(c => c.Count());

            return ordered.Last().Key;
        }
    }
}

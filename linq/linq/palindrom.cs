
using System.Diagnostics.Tracing;

namespace linq
{
    class palindrom
    {
        private string givenString;
        public palindrom(string givenString)
        {
            this.givenString = givenString;
        }

        public List<string> AllPalindroms()
        {
            var palindromList = new List<string>();
            var grouped = givenString.GroupBy(c => c);

            for (int start = 0; start <= givenString.Length; start++)
            {
                for (int end = start; end <= givenString.Length; end++)
                {
                   var word = givenString.Substring(start, end - start);
                }
            }

            return palindromList;
        }
    }
}

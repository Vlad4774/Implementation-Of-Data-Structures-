
namespace linq
{
    class NumberOfVowelAndConsonant
    {
        private string text;

        public NumberOfVowelAndConsonant(string text)
        {
            this.text = text.ToLower();
        }

        public int ReturnNumberOfVowels()
        {
            return text.Count(character => "aeiou".Contains(character));
        }

        public int ReturnNumberOfConsonants()
        {
            return text.Count(character => "bcdfghjklmnpqrstvwxyz".Contains(character));
        }
    }
}

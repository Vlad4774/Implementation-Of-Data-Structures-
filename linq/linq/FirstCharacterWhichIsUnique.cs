
namespace linq
{
    class FirstCharacterWhichIsUnique
    {
        string text;
        public FirstCharacterWhichIsUnique(string text)
        {
            this.text = text;
        }

        public char GetFirstUniqueCharacter()
        {
            var uniqueChars = text.GroupBy(c => c).Where(g => g.Count() == 1);
            return uniqueChars.First().Key;
        }
    }
}

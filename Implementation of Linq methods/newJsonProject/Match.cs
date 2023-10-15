
namespace newJsonProject
{
    class Match : IMatch
    {
        bool success;
        string remainingText;
        public Match(bool result, string remainingText)
        {
            this.success = result;
            this.remainingText = remainingText;
        }

        public string RemainingText()
        {
            return remainingText;
        }

        public bool Success()
        {
            return success;
        }
    }
}

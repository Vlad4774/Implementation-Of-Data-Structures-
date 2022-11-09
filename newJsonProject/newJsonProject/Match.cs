
namespace newJsonProject
{
    class Match : IMatch
    {
        bool success;
        string remainingText;
        public bool Success(bool result)
        {
            this.success = result;
            return success;
        }

        public string RemainingText(string text)
        {
            this.remainingText = text;
            return remainingText;
        }
    }
}

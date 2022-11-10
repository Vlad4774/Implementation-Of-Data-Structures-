
namespace newJsonProject
{
    class Sequence : IPattern
    {
        IPattern[] patterns;
        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            return new Match(true, text);
        }
    }
}

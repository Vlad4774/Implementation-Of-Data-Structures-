
namespace newJsonProject
{
    public class choiseTests
    {
        [Fact]

        public void CasesTrue()
        {
            var digit = new Choice (new Character('0'),
                                   new Range('1', '9') );
        }
    }
}

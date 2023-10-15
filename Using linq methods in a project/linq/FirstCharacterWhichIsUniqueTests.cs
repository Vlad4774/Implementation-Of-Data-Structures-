
namespace linq
{
    public class FirstCharacterWhichIsUniqueTests
    {
        [Fact]
        public void GetFirstUniqueCharacter()
        {
            string text = "hello world";
            var firstElement = new FirstCharacterWhichIsUnique(text);

            char result = firstElement.GetFirstUniqueCharacter();

            Assert.Equal('h', result);
        }
    }
}

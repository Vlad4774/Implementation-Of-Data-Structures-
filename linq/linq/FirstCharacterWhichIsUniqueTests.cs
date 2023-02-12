
namespace linq
{
    public class FirstElementWhichIsUniqueTests
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

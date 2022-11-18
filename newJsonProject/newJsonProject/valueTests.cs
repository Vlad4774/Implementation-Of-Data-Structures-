

namespace newJsonProject
{
    public class valueTests
    {
        [Fact]
        public void ValidateAObject()
        {
            var obj = new Value();
            string text = "{ \"car\" : true , \"house\" : false }";
            Assert.True(obj.Match(text).Success());
        }

        [Fact]
        public void ValidateArray()
        {
            var obj = new Value();
            string text = "[ \"false\" , \"Vlad\" ]";
            Assert.True(obj.Match(text).Success());
        }
    }
}

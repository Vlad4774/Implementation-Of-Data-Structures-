namespace newJsonProject
{
    class Prog
    {
        public static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(args[0]);
            var value = new Value();
            bool result = value.Match(text).Success();
            Console.WriteLine(result);
        }
    }
}

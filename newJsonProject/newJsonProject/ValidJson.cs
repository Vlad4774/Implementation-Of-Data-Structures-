namespace newJsonProject
{
    class Prog
    {
        public static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(args[0]);
            var value = new Value();
            IMatch result = value.Match(text);
            Console.WriteLine(result.Success() && string.IsNullOrEmpty(result.RemainingText()));
        }
    }
}

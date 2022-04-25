namespace ClassLibrary
{
    public static class Text
    {
        public static string? GetWordEndsWith(string input, string letter)
        {
            var wordArray = input.Split(" ");
            return wordArray.SingleOrDefault((word) => word.EndsWith(letter));
        }

        public static string RemoveChar(string input, string letter)
        {
            return new string(input.Where(c => !letter.Contains(c)).ToArray());
        }
    }
}

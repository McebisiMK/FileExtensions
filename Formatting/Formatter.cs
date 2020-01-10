namespace FilesSizeByExtensions.Formatting
{
    public class Formatter : IFormatter
    {
        public int Format(string size)
        {
            var space = 0;
            int.TryParse(size.Replace("b", ""), out space);

            return space;
        }
    }
}
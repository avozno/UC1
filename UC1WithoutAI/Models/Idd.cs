namespace UCWithoutAi.Models
{
    public class Idd
    {
        public string? Root { get; set; }
        public List<string> Suffixes { get; set; }

        public Idd()
        {
            Suffixes = new List<string>();
        }
    }
}

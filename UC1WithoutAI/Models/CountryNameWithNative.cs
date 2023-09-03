namespace UCWithoutAi.Models
{
    public class CountryNameWithNative : CountryName
    {
        public Dictionary<string, CountryName> NativeName { get; set; }

        public CountryNameWithNative()
        {
            NativeName = new Dictionary<string, CountryName>();
        }
    }
}

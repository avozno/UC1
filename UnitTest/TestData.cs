using UCWithoutAi.Models;

namespace UnitTest
{
    public class TestData
    {
        public static List<Country> Data = new List<Country>
        {
            new Country
            {
                Name = new CountryNameWithNative
                {
                    Common = "Ukraine"
                },
                Population = 44000000
            },
            new Country
            {
                Name = new CountryNameWithNative
                {
                    Common = "USA"
                },
                Population = 340000000
            },
            new Country
            {
                Name = new CountryNameWithNative
                {
                    Common = "Japan"
                },
                Population = 140000000
            },
            new Country
            {
                Name = new CountryNameWithNative
                {
                    Common = "russia"
                },
                Population = -151000000
            },
            new Country
            {
                Name = new CountryNameWithNative
                {
                    Common = "Canada"
                },
                Population = 300000000
            },
        };
    }
}

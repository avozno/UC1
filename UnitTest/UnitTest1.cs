using Moq;
using UCWithoutAi.Services;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetCountries_ReturnsData()
        {
            var mockService = new Mock<IDataProviderService>();
            mockService.Setup(i => i.GetData()).Returns(Task.FromResult(TestData.Data));
            var service = new CountriesService(mockService.Object);
            var res = await service.GetCountries();
            Assert.True(res.Count == 5);
        }

        [Fact]
        public async Task GetCountriesFilteredByName_ReturnsUkraine()
        {
            var mockService = new Mock<IDataProviderService>();
            mockService.Setup(i => i.GetData()).Returns(Task.FromResult(TestData.Data));
            var service = new CountriesService(mockService.Object);
            var res = await service.GetCountriesFilteredByName("uk");
            var firstItem = res.FirstOrDefault();
            Assert.True(firstItem != null && firstItem.Name.Common == "Ukraine");
        }

        [Fact]
        public async Task GetCountriesLimitedByPopulationInMillions_ReturnsRussia()
        {
            var mockService = new Mock<IDataProviderService>();
            mockService.Setup(i => i.GetData()).Returns(Task.FromResult(TestData.Data));
            var service = new CountriesService(mockService.Object);
            var res = await service.GetCountriesLimitedByPopulationInMillions(20);
            var firstItem = res.FirstOrDefault();
            Assert.True(firstItem != null && firstItem.Name.Common == "russia");
        }

        [Fact]
        public async Task GetCountriesOrderedByName_CanadaFirst_USALast()
        {
            var mockService = new Mock<IDataProviderService>();
            mockService.Setup(i => i.GetData()).Returns(Task.FromResult(TestData.Data));
            var service = new CountriesService(mockService.Object);
            var res = await service.GetCountriesOrderedByName("ascend");
            var firstItem = res.FirstOrDefault();
            var lastItem = res.LastOrDefault();
            Assert.True(firstItem != null && firstItem.Name.Common == "Canada" && lastItem != null && lastItem.Name.Common == "USA");
        }

        [Fact]
        public async Task GetCountriesWithPagination_ReturnsOnlyLastItem()
        {
            var mockService = new Mock<IDataProviderService>();
            mockService.Setup(i => i.GetData()).Returns(Task.FromResult(TestData.Data));
            var service = new CountriesService(mockService.Object);
            var res = await service.GetCountriesWithPagination(2, 4);
            var firstItem = res.FirstOrDefault();
            Assert.True(firstItem != null && firstItem.Name.Common == "Canada" && res.Count() == 1);
        }

        [Fact]
        public async Task GetCountriesFiltered_ReturnUkraineAndJapan()
        {
            var mockService = new Mock<IDataProviderService>();
            mockService.Setup(i => i.GetData()).Returns(Task.FromResult(TestData.Data));
            var service = new CountriesService(mockService.Object);
            var res = await service.GetCountriesFiltered("n", 200, "descend", 1, 2);
            var firstItem = res.FirstOrDefault();
            var lastItem = res.LastOrDefault();
            Assert.True(firstItem != null && firstItem.Name.Common == "Ukraine" 
                && lastItem != null && lastItem.Name.Common == "Japan"
                && res.Count() == 2);
        }
    }
}
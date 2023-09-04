Use case 1 implementation without help of AI.
UC1 - application developed for simplifying work with Rest Countries API (https://restcountries.com/v3.1/all). Alows to get filtered, pafinated, sorted data from API in stricted form. Information about country includes: name, capital, population, boundaries etc. More detailed information about fields can be found on https://gitlab.com/restcountries/restcountries/-/blob/master/FIELDS.md.

In order ro run application you need:
1. Install .NET 6 SDK 
2. Install VS 2022 or other IDEA that allows you to work with Asp.Net.
3. Press run.

In order to run it in IIS: 
Turn on IIS on windows.
Create port for app.
Create folder for app.
Assign application to folder.
Insert deployed file into folder.

Usage (https://localhost:7277 - must be replaced with your local/deployed link):
1. Get all available countries:
https://localhost:7277/Countries/GetCountries
2. Get all countries which have "uk" in their names:
https://localhost:7277/Countries/GetCountriesFilteredByName?search=uk
3. Get all countries with population less than 40000000:
https://localhost:7277/Countries/GetCountriesLimitedByPopulationInMillions?limit=40
4. Get all countries sorted by name in descend direction:
https://localhost:7277/Countries/GetCountriesOrderedByName?orderDirection=descend
5. Get all countries sorted by name in ascend direction:
https://localhost:7277/Countries/GetCountriesOrderedByName?orderDirection=ascend
6. Get 13-18 country from the list:
https://localhost:7277/Countries/GetNThCountry?page=3&itemsPerPage=6
7. Get 13-18 country from the list of countries with "uk" in their name:
https://localhost:7277/Countries/GetCountriesFiltered?page=3&itemsPerPage=6&search=uk
8. Get list of countries ordered by name, which include only countries that have less than 200 000 000 people:
https://localhost:7277/Countries/GetCountriesFiltered?limit=200&orderDirection=ascend
9. Get list of a countries which name contains "uk" and with population less than 200 000 000
https://localhost:7277/Countries/GetCountriesFiltered?limit=200&search=uk
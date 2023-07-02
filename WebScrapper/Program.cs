using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScrapper
{
    class Program
    {
        static void Main(String[] args)
        {
            String url = "https://weather.com/en-IN/weather/today/l/d8957d01281fef701a5fa057bfd5da7f9674a11f991de86e8a482fd0c92480c8";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);


            // To extract temperature

            var tempElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temp = tempElement.InnerText.Trim();

            Console.WriteLine("Temperature:" + temp);

            // To extract conditions

            var condElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var cond = condElement.InnerText.Trim();

            Console.WriteLine("Conditions:" + cond);


            // To extract air quality index

            var airindElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='AirQualityText--severity--W9CtX']");
            var airqual = airindElement.InnerText.Trim();

            Console.WriteLine("Air Quality Index:" + airqual);
        }
    }
}

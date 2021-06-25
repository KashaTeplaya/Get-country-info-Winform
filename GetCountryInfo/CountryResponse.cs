using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;


namespace GetCountryInfo
{
    class CountryResponse
    {
        public static Country GetCountry { get; set; }
        public static Country GetInfoCountryByName(string countryName)
        {
            try
            {
                WebRequest request = WebRequest.Create($"https://restcountries.eu/rest/v2/name/{countryName}");
                WebResponse response = request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();

                    List<Country> list = JsonConvert.DeserializeObject<List<Country>>(responseFromServer);
                    

                    GetCountry = list[0];
                    return list[0];
                }
            }
            catch (Exception e) { throw new Exception("Ошибка запроса, неверно введено название " + e.Message, e); }

        }

    }
}

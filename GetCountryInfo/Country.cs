using System;
using System.Collections.Generic;


namespace GetCountryInfo
{
    class Country
    {
        public string name { get; set; }
        public List<string> callingCodes { get; set; }
        public string capital { get; set; }
        public string region { get; set; }
        public int population { get; set; }
        public double area { get; set; }


        public int capitalId { get; set; }
        public int regionId { get; set; }
    }
}

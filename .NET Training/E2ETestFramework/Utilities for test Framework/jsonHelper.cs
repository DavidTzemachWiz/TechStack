using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E2ETestFramework.Utilities_for_test_Framework
{
    public class jsonHelper
    {
        public void JsonReader()
        {
        }
        //Handle a single value string
        public string? extractData(string tokenName)
        {
            var myJsonString = File.ReadAllText(@"C:\Users\User\Dropbox\PC (2)\Documents\GitHub\TechStack\.NET Training\E2ETestFramework\Utilities for test Framework\testData.json");
            var jsonObject =  JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        //handle Arrays
        public string [] extractDataArray(string tokenName)
        {
            var myJsonString = File.ReadAllText(@"C:\Users\User\Dropbox\PC (2)\Documents\GitHub\TechStack\.NET Training\E2ETestFramework\Utilities for test Framework\testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            List<string> products =  jsonObject.SelectTokens(tokenName).Values<string>().ToList();
            return products.ToArray();
        }
    }
}

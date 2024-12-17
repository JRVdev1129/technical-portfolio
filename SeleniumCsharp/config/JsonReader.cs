using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace CSharpSelFramework.utilities
{
    public class JsonReader
    {
        public JsonReader()
        {
        }

         
        public string extractData(String tokenName)
        {

          String myJsonString = File.ReadAllText("utilities/testData.json");

           var jsonObject = JToken.Parse(myJsonString);
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8603 // Possible null reference return.
            return jsonObject.SelectToken(tokenName).Value<string>();
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8604 // Possible null reference argument.


        }

        public string[] extractDataArray(String tokenName)
        {

            String myJsonString = File.ReadAllText("utilities/testData.json");

            var jsonObject = JToken.Parse(myJsonString);
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            List<String> productsList=   jsonObject.SelectTokens(tokenName).Values<string>().ToList();
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
            return productsList.ToArray();




        }
    }
}

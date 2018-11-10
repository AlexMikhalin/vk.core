using System;
using System.Collections.Generic;
using System.IO;
using MasterCard.Core;
using MasterCard.Core.Exceptions;
using MasterCard.Core.Model;
using MasterCard.Core.Security.OAuth;
using TestMasterCard;

namespace MasterCard.Api.Locations
{
    public class ATMLocationsTest
    {
        public static ATMLocations Get(double latitude, double longitude)
        {
            string consumerKey = "shbGabkd9bXLE4jnpYlB5AHULo5lUq8PQSZzcSi5d1e6817b!285415dee84e4affb0fb85fee8e4164a0000000000000000";  
            string keyAlias = "keyalias";  
            string keyPassword = "keystorepassword";
            var pathfile = Directory.GetCurrentDirectory();
            string certPath = $"{pathfile}/wwwroot/hackaton-vk-sandbox.p12"; // e.g. /Users/yourname/project/sandbox.p12 | C:\Users\yourname\project\sandbox.p12

            ApiConfig.SetAuthentication(new OAuthAuthentication(consumerKey, certPath, keyAlias, keyPassword));   // You only need to set this once
            ApiConfig.SetSandbox(true); 

            RequestMap map = new RequestMap();

            var stringLatitiude = latitude.ToString().Replace(",", ".");
            var stringLongitude = longitude.ToString().Replace(",", ".");
            map.Set("PageLength", "11");
            map.Set("PostalCode", "191186");
            map.Set("PageOffset", "0");
            map.Set("Latitude", $"{stringLatitiude}");
            map.Set("Longitude", $"{stringLongitude}");
                       
            return ATMLocations.Query(map);
        }
    }
}

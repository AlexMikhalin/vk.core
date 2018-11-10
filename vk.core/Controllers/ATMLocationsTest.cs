using System;
using System.Collections.Generic;
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
            var path = MasterCard.Core.Util.GetCurrenyAssemblyPath(); // This returns the path to your assembly so it be used to locate your cert
            string certPath = "/Users/sasha/source/repos/vk.core/vk.core/wwwroot/hackaton-vk-sandbox.p12"; // e.g. /Users/yourname/project/sandbox.p12 | C:\Users\yourname\project\sandbox.p12

            ApiConfig.SetAuthentication(new OAuthAuthentication(consumerKey, certPath, keyAlias, keyPassword));   // You only need to set this once
            ApiConfig.SetSandbox(true); // For production: use ApiConfig.setSandbox(false)

            RequestMap map = new RequestMap();

            var stringLatitiude = latitude.ToString().Replace(",", ".");
            var stringLongitude = longitude.ToString().Replace(",", ".");
            map.Set("PageLength", "100");
            map.Set("PostalCode", "191186");
            map.Set("PageOffset", "0");
            map.Set("Latitude", $"{stringLatitiude}");
            map.Set("Longitude", $"{stringLongitude}");


            ATMLocations response = ATMLocations.Query(map);

            
            Console.WriteLine("Atms.PageOffset-->" + response["Atms.PageOffset"]); //Atms.PageOffset-->0
            Console.WriteLine("Atms.TotalCount-->" + response["Atms.TotalCount"]); //Atms.TotalCount-->26
            Console.WriteLine("Atms.Atm[0].Location.Name-->" + response["Atms.Atm[0].Location.Name"]); //Atms.Atm[0].Location.Name-->Sandbox ATM Location 1
            Console.WriteLine("Atms.Atm[0].Location.Distance-->" + response["Atms.Atm[0].Location.Distance"]); //Atms.Atm[0].Location.Distance-->0.9320591049747101
            Console.WriteLine("Atms.Atm[0].Location.DistanceUnit-->" + response["Atms.Atm[0].Location.DistanceUnit"]); //Atms.Atm[0].Location.DistanceUnit-->MILE
            Console.WriteLine("Atms.Atm[0].Location.Address.Line1-->" + response["Atms.Atm[0].Location.Address.Line1"]); //Atms.Atm[0].Location.Address.Line1-->4201 Leverton Cove Road
            Console.WriteLine("Atms.Atm[0].Location.Address.City-->" + response["Atms.Atm[0].Location.Address.City"]); //Atms.Atm[0].Location.Address.City-->SPRINGFIELD
            Console.WriteLine("Atms.Atm[0].Location.Address.PostalCode-->" + response["Atms.Atm[0].Location.Address.PostalCode"]); //Atms.Atm[0].Location.Address.PostalCode-->11101
            Console.WriteLine("Atms.Atm[0].Location.Address.CountrySubdivision.Name-->" + response["Atms.Atm[0].Location.Address.CountrySubdivision.Name"]); //Atms.Atm[0].Location.Address.CountrySubdivision.Name-->UYQQQQ
            Console.WriteLine("Atms.Atm[0].Location.Address.CountrySubdivision.Code-->" + response["Atms.Atm[0].Location.Address.CountrySubdivision.Code"]); //Atms.Atm[0].Location.Address.CountrySubdivision.Code-->QQ
            Console.WriteLine("Atms.Atm[0].Location.Address.Country.Name-->" + response["Atms.Atm[0].Location.Address.Country.Name"]); //Atms.Atm[0].Location.Address.Country.Name-->UYQQQRR
            Console.WriteLine("Atms.Atm[0].Location.Address.Country.Code-->" + response["Atms.Atm[0].Location.Address.Country.Code"]); //Atms.Atm[0].Location.Address.Country.Code-->UYQ
            Console.WriteLine("Atms.Atm[0].Location.Point.Latitude-->" + response["Atms.Atm[0].Location.Point.Latitude"]); //Atms.Atm[0].Location.Point.Latitude-->38.76006576913497
            Console.WriteLine("Atms.Atm[0].Location.Point.Longitude-->" + response["Atms.Atm[0].Location.Point.Longitude"]); //Atms.Atm[0].Location.Point.Longitude-->-90.74615107952418
            Console.WriteLine("Atms.Atm[0].Location.LocationType.Type-->" + response["Atms.Atm[0].Location.LocationType.Type"]); //Atms.Atm[0].Location.LocationType.Type-->OTHER
            Console.WriteLine("Atms.Atm[0].HandicapAccessible-->" + response["Atms.Atm[0].HandicapAccessible"]); //Atms.Atm[0].HandicapAccessible-->NO
            Console.WriteLine("Atms.Atm[0].Camera-->" + response["Atms.Atm[0].Camera"]); //Atms.Atm[0].Camera-->NO
            Console.WriteLine("Atms.Atm[0].Availability-->" + response["Atms.Atm[0].Availability"]); //Atms.Atm[0].Availability-->UNKNOWN
            Console.WriteLine("Atms.Atm[0].AccessFees-->" + response["Atms.Atm[0].AccessFees"]); //Atms.Atm[0].AccessFees-->UNKNOWN
            Console.WriteLine("Atms.Atm[0].Owner-->" + response["Atms.Atm[0].Owner"]); //Atms.Atm[0].Owner-->Sandbox ATM 1
            Console.WriteLine("Atms.Atm[0].SharedDeposit-->" + response["Atms.Atm[0].SharedDeposit"]); //Atms.Atm[0].SharedDeposit-->NO
            Console.WriteLine("Atms.Atm[0].SurchargeFreeAlliance-->" + response["Atms.Atm[0].SurchargeFreeAlliance"]); //Atms.Atm[0].SurchargeFreeAlliance-->NO
            Console.WriteLine("Atms.Atm[0].SurchargeFreeAllianceNetwork-->" + response["Atms.Atm[0].SurchargeFreeAllianceNetwork"]); //Atms.Atm[0].SurchargeFreeAllianceNetwork-->DOES_NOT_PARTICIPATE_IN_SFA
            Console.WriteLine("Atms.Atm[0].Sponsor-->" + response["Atms.Atm[0].Sponsor"]); //Atms.Atm[0].Sponsor-->Sandbox
            Console.WriteLine("Atms.Atm[0].SupportEMV-->" + response["Atms.Atm[0].SupportEMV"]); //Atms.Atm[0].SupportEMV-->1
            Console.WriteLine("Atms.Atm[0].InternationalMaestroAccepted-->" + response["Atms.Atm[0].InternationalMaestroAccepted"]); //Atms.Atm[0].InternationalMaestroAccepted-->1


            // This sample shows looping through Atms.Atm
            List<Dictionary<String, Object>> list = (List<Dictionary<String, Object>>)response["Atms.Atm"];
            for (var i = 0; i < list.Count; i++)
            {
                Console.WriteLine("index: " + i);
                Console.WriteLine("Location: [ " + list[i]["Location"] + " ]");
                Console.WriteLine("index: " + i);
                Console.WriteLine("HandicapAccessible: [ " + list[i]["HandicapAccessible"] + " ]");
                Console.WriteLine("index: " + i);
                Console.WriteLine("Camera: [ " + list[i]["Camera"] + " ]");
                Console.WriteLine("index: " + i);
                Console.WriteLine("Availability: [ " + list[i]["Availability"] + " ]");
                Console.WriteLine("index: " + i);
                Console.WriteLine("AccessFees: [ " + list[i]["AccessFees"] + " ]");
                Console.WriteLine("index: " + i);
                Console.WriteLine("Owner: [ " + list[i]["Owner"] + " ]");
                Console.WriteLine("index: " + i);
                Console.WriteLine("SharedDeposit: [ " + list[i]["SharedDeposit"] + " ]");
                Console.WriteLine("index: " + i);
                Console.WriteLine("SurchargeFreeAlliance: [ " + list[i]["SurchargeFreeAlliance"] + " ]");
                Console.WriteLine("index: " + i);
                Console.WriteLine("SurchargeFreeAllianceNetwork: [ " + list[i]["SurchargeFreeAllianceNetwork"] + " ]");
                Console.WriteLine("index: " + i);
                Console.WriteLine("Sponsor: [ " + list[i]["Sponsor"] + " ]");
                Console.WriteLine("index: " + i);
                Console.WriteLine("SupportEMV: [ " + list[i]["SupportEMV"] + " ]");
                Console.WriteLine("index: " + i);
                Console.WriteLine("InternationalMaestroAccepted: [ " + list[i]["InternationalMaestroAccepted"] + " ]");

            }
            return response;
        }
    }
}

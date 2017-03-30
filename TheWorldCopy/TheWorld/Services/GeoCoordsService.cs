using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


//Keys:BingKey
namespace TheWorld.Services
{
    public class GeoCoordsService
    {
        private ILogger<GeoCoordsService> _logger;
        private IConfigurationRoot _config;

        public GeoCoordsService(ILogger<GeoCoordsService> logger,
            IConfigurationRoot config)
        {
            _logger = logger;
            _config = config;
        }

        //public async Task<GeoCoordsResult> GetCoordsAsync(string name)
        //{
        //    var result = new GeoCoordsResult()
        //    {
        //        Success = false,
        //        Message = "Failed to get coordinates"
        //    };

        //    var apiKey =_config["Keys:BingKey"];
        //    var encodeName = WebUtility.UrlEncode(name);
        //    var url = $"";

        //}

        public async Task<GeoCoordsResult> Lookup(string location)
        {
            // Instantiate CoorServiceResult object with default values
            var result = new GeoCoordsResult()
            {
                Success = false,
                Message = "Undetermined failure while looking up coordinates"
            };

            // Lookup Coordinates
            var bingKey = _config["Keys:BingKey"];
            var encodedName = WebUtility.UrlEncode(location);
            var url = $"http://dev.virtualearth.net/REST/v1/Locations?query={encodedName}&key={bingKey}";

            var client = new HttpClient();

            var json = await client.GetStringAsync(url);

            var results = JObject.Parse(json);
            var resources = results["resourceSets"][0]["resources"];
            if (!resources.HasValues)
            {
                result.Message = $"could not find '{location}' as a location";
            }
            else
            {
                var confidence = (string)resources[0]["confidence"];
                if (confidence != "High")
                {
                    result.Message = $"Could not find a confident match for '{location}' as a coordinate point";
                }
                else
                {
                    var coords = resources[0]["geocodePoints"][0]["coordinates"];
                    result.Latitude = (double)coords[0];
                    result.Longitude = (double)coords[1];
                    result.Success = true;
                    result.Message = "Success";
                }
            }

            return result;
        }










    }
}

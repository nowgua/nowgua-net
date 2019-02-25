using Newtonsoft.Json;
using nowguaClient.Models.Interventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace nowgaApi.Core.Helpers
{
	public class Formatter
	{
		public static Address ConvertStringToAddress(string text)
		{
			Address address = new Address();

			var httpClient = new HttpClient();
			var apiKey = "AIzaSyDdtDeLxqgX509xf9eO_hXhx4jvF_5pm1Q";

			Uri urlApiGoogle = new Uri("https://maps.googleapis.com/maps/api/geocode/json?address=" + text + "&components=country:FR|result_type:street_address&components=location_type:ROOFTOP&key=" + apiKey);

			Task<HttpResponseMessage> resultFormApi = httpClient.GetAsync(urlApiGoogle);
			var result = resultFormApi.Result.Content.ReadAsStringAsync().Result;

			var resultJson = JsonConvert.DeserializeObject<GoogleResponseResult>(result);

			address.AddressMode = AddressMode.FreeMode;
			address.Text = text;

			foreach (var item in resultJson.results.Where(add => add.types.Contains("street_address") || add.types.Contains("premise")))
			{
				address.AddressMode = AddressMode.AutoCompletionMode;
				address.Text = item.formatted_address;
				address.Longitude = item.geometry.location.lng;
				address.Latitude = item.geometry.location.lat;
			}
			return address;
		}
	}

	public class GoogleResponseResult
	{
		public List<GoogleResponseAddress> results { get; set; }
		public string status { get; set; }
	}


	public class GoogleResponseAddress
	{
		public string formatted_address { get; set; }
		public geometry geometry { get; set; }
		public List<AddressEntityComponent> address_components { get; set; }
		public List<string> types { get; set; }

	}

	public class geometry
	{
		public location location { get; set; }
		public string location_type { get; set; }

	}

	public class location
	{
		public double lat { get; set; }
		public double lng { get; set; }
	}
}
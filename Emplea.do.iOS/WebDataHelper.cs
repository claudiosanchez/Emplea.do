using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iOS
{

    public class WebDataHelper
    {
        public async Task<T> Get<T>(string url)
        {
            try {
			string rawData = await new HttpClient().GetStringAsync(url);

				Debug.WriteLine(rawData);
				var parsedObject = JsonConvert.DeserializeObject<T>(rawData);
				return parsedObject;
			}
			catch(System.Exception exception) {
				Debug.WriteLine (exception.Message);
				Debug.WriteLine (exception.StackTrace);
				return default(T);
			}
           
        }
    }
}


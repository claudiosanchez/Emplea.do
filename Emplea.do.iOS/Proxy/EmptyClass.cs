using System;
using Newtonsoft.Json;
using iOS.Model;
using System.Linq;
using System.Collections.Generic;
using System.Net;

namespace Empleado
{
	public class Proxy
	{
		public void GetActive(Action<IList<JobPosting>>  success, Action<string> error)
		{
			var client = new RestSharp.RestClient {BaseUrl = "https://www.emplea.do/1.0/jobs_vigentes.json"};
		    
            ServicePointManager.ServerCertificateValidationCallback += (s, c, ch, e) => true;
		    try
		    {
				var response = client.ExecuteAsGet<List<JobPosting>>(new RestSharp.RestRequest(), "GET");
		        
                if (response.StatusCode == HttpStatusCode.OK)
		        {
		            var data = JsonConvert.DeserializeObject<IEnumerable<JobPosting>>(response.Content);
		            success.Invoke(data.ToList());
		        }
				else{
				Console.WriteLine(response.Content);
				error.Invoke(string.Format("El Servidor no me dio la data. {0}{1}", response.Content, response.ErrorMessage));
				}
		    }
		    catch (Exception exception)
		    {
                error.Invoke(string.Format("{0}", exception.StackTrace));
		    }
		}

	}
}

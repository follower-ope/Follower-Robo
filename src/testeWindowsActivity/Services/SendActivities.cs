using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace testeWindowsActivity.Services
{
    class SendActivities
    {
        internal async System.Threading.Tasks.Task SendAsync(string userName, string proccessName, DateTime date)
        {
            HttpClient client = new HttpClient();

            string uri = "http://localhost:3333/activities";


            var values = new Dictionary<string, string>
            {
                { "userName", userName },
                { "proccessName", proccessName },
                {"horario", date.ToString() }
            };

            string json = JsonConvert.SerializeObject(values, Formatting.Indented);

            await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
        }
    }
}

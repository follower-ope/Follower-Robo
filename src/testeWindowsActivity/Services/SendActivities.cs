using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace testeWindowsActivity.Services
{
    class SendActivities
    {
        internal async System.Threading.Tasks.Task SendAsync(string userName, string processName, string softwareName, DateTime date)
        {
            HttpClient client = new HttpClient();

            string uri = "http://localhost:3333/activities";

            var values = new Dictionary<string, string>
            {
                { "username", userName },
                { "process_name", processName },
                { "software_name", softwareName },
                { "time", date.ToString("yyyy-MM-dd HH:mm:ss")}
            };

            string json = JsonConvert.SerializeObject(values, Formatting.Indented);

            await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
        }
    }
}

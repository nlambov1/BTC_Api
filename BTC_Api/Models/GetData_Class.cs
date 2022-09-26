using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BTC_Api.Classes
{
    public class GetData_Class
    {
        public static string GetData()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var baseUrl = "https://api.coindesk.com/v1/bpi/currentprice.json";
                // var baseUrl = "https://api.coinbase.com/v2/prices/spot?currency=USD";
                var task = client.GetAsync(baseUrl);
                task.Wait();

                if (!task.Result.IsSuccessStatusCode)
                {
                    throw new Exception(task.Result.StatusCode.ToString());
                }

                var readTask = task.Result.Content.ReadAsStringAsync();
                readTask.Wait();
                return readTask.Result;
            }
        }
    }
}

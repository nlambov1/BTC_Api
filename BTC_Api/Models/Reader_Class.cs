using BTC_Api.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_Api.Models
{
    public class Reader_Class
    {
        public static async Task<double> ResultBuilder(string input)
        {
            List<double> qt = new List<double>();
            double result = 0;
            try
            {                   
                    var apiResults = GetData_Class.GetData();
                  
                    RootObject_Class currentObject = JsonConvert.DeserializeObject<RootObject_Class>(apiResults);
                    
                    switch (input)
                    {
                        case "USD":
                            result = Convert.ToDouble(currentObject.bpi.USD.rate);
                            break;
                        case "GBP":
                            result = Convert.ToDouble(currentObject.bpi.GBP.rate);
                            break;
                        default:
                            result = Convert.ToDouble(currentObject.bpi.EUR.rate);
                            
                            input = "EUR";
                            break;
                    }
                    
                    
                    System.Threading.Thread.Sleep(1000);
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
            return result;
        }

    }
  
}

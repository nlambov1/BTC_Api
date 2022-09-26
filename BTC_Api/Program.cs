using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BTC_Api.Models;
using System.Threading;
using System.Globalization;

namespace BTC_Api
{
    class Program
    {


        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            //Read currency
            Console.WriteLine("Please input currency: ");
            string input = Console.ReadLine().ToUpper();

            //Validate input
            ValidateInput(ref input);


            //Read 5 responses over 5 min
            List<double> qt = new List<double>();

                while (true)
                {
                Console.Clear();
                if (qt.Count >=5)
                {
                    qt.RemoveAt(4);
                }             
                    var result = Reader_Class.ResultBuilder(input).Result;

                qt.Insert(0, result);
                //Calculate avarage and maximun
                
                Console.WriteLine("Accepted results: " + qt.Count );
                    Console.WriteLine("Avarage Price is " + qt.Average() + " " + input);
                    Console.WriteLine("Maximum Price is " + qt.Max() + " " + input + " Before " + qt.IndexOf(qt.Max()) + " minutes ago.");
                    Console.WriteLine("");

                //1 minute timeout timer until next call
                CountDownTimer();
                
                    
                };
        }
        public static void CountDownTimer()
        {
            for (int a = 10; a >= 0; a--)
            {
                Console.Write("\rGenerating next update in {0:00}", a);
                System.Threading.Thread.Sleep(1000);
            }
        }

        public static void ValidateInput(ref string input)
        {
            if (input != "USD" && input != "GBP")
            {
                input = "EUR";
            }
            Console.WriteLine("Accepted currency is: " + input);
            System.Threading.Thread.Sleep(2000);
        }
    }
}

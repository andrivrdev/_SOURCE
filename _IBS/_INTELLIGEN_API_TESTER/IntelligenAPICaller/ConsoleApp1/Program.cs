using IntelligenAPICaller.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://www.intelligen.co.za/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            try
            {
                // Get a new token
                tblUser xclsUser = new tblUser
                {
                    userName = "andri",
                    password = "Andri123!",
                    grant_type = "password"
                };

                string x;

                x = await IntelligenAPICaller.API.GetAccessToken("https://www.intelligen.co.za/", xclsUser);
                Console.WriteLine(x);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}

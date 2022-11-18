using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {

                RonVSKanyeAPI.kanyeQuote();
                Console.WriteLine();
                RonVSKanyeAPI.ronQuote();
                Console.WriteLine();
            }
        }
    }
}

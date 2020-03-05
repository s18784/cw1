using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //string tmp1 = null;
            //string tmp2 = "ala bardzo";
            //string tmp3 = "lubi";
            //string tmp4 = "xd";

            //console.writeline($"{tmp2} {tmp3} {tmp4}");

            //console.writeline("hello world!");
            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl/";
            using (var client = new HttpClient())
            {
                var content = await client.GetAsync(url);

                //200, 201, 2xx - gity , 4xx - posrednie, 5xx - slabo
                if (content.IsSuccessStatusCode == true)
                {
                    var sourceCode = await content.Content.ReadAsStringAsync();
                    var regex = new Regex(@"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
         + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
         + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
         + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})", RegexOptions.IgnoreCase);
                    var matche = regex.Matches(sourceCode);

                    foreach (var match in matche)
                    {
                        Console.WriteLine(match);
                    }
                    Console.WriteLine(matche.Count);
                }



            }
        }
    }
}

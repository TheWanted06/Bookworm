using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm
{
    public class Generate
    {
        public static Random random = new Random();

        public static List<string> CallNumber()
        {
            List<string> list = new List<string>();
            string randomNumber;

            for (int i = 0; i < 10; i++)
            {
                const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                var randomString = new string(Enumerable.Repeat(allowedChars, 1)
                    .Select(a => a[random.Next(a.Length)]).ToArray());

                //generates random numbers
                var randomNumber1 = random.Next(100, 999);
                var randomNumber2 = random.Next(10, 99);

                //joins the random string and number to make a call number
                randomNumber = randomNumber1 + "." + randomNumber2 + " " + randomString;
                list.Add(randomNumber);

            }

            return list;
        }
            
    }
}

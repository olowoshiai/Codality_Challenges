using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Accenture
{
    class CodalityPratice
    {
        public static void Main(string[] args)
        {
            string str = "a0Bb";
            // Console.WriteLine(solution("100:42", "199:42"));

            // int integerHours = Int32.Parse("03");
            // Console.WriteLine(integerHours);
            Console.WriteLine(WholeSquare(4, 17));

        }

        //find all integers between int A,B that is a perfect square
        public static int WholeSquare (int A, int B)
        {
            //take the two integers
            //add the numbers to an array
            //go through the array and rake the sqrt of each value
            //check if the reminder of the value/1 == 0 ( not decimals);
            //increment the variable count & return count

            int wholeSquareCount = 0;
            int[]wholeSquares = Enumerable.Range(0, 15).ToArray();

            foreach (int number in wholeSquares)
            {
                double doubleNumber = Convert.ToDouble(number);
                double result = Math.Sqrt(doubleNumber);
                //Console.WriteLine(result);
                bool isSquare = result % 1 == 0;

                if (isSquare == true && result != 1)
                {
                   
                    wholeSquareCount += 1;
                }
            }
            return wholeSquareCount;
        }



        //calculate a parking ticket
        //where string E,L are the starting and ending time in the lot.
        public static int solution(string E, string L)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            int firstHourFee = 3;
            int succesivePartialHrs = 4;
            int parkingFee = 2;
            string hr;
            string minutes;
            int integerHours;
            int integerMinutes;
            DateTime startTimeTest;
            DateTime endTimeTest;

            //s = dt.ToString("HH:mm");

            bool dateTimeOne = DateTime.TryParse(E, out startTimeTest);
            bool dateTimeTwo = DateTime.TryParse(E, out endTimeTest);

            if (dateTimeOne == true && dateTimeTwo == true)
            {

                var startTime = Convert.ToDateTime(E);
                var endTime = Convert.ToDateTime(L);


                TimeSpan parkingDuration = endTime - startTime;
                //Console.WriteLine(parkingDuration);


                string[] splitTimes = (parkingDuration.ToString()).Split(new char[] { ':' });
                //foreach (string hms in splitTimes)

                hr = splitTimes[0];
                minutes = splitTimes[1];

                integerHours = Int32.Parse(hr);

                integerMinutes = Int32.Parse(minutes);

                if ((IsWithin(integerHours, 0, 23) == true) && integerHours <= 1)
                {
                    parkingFee += integerHours * firstHourFee;
                }
                else if (IsWithin(integerHours, 0, 23) == true)
                {
                    parkingFee += firstHourFee + ((integerHours - 1) * succesivePartialHrs);
                    //Console.WriteLine("after1: " + parkingFee);
                }

                if (integerMinutes > 0 && integerMinutes <= 60)
                {
                    parkingFee += succesivePartialHrs;
                }


                return parkingFee;
            }

            else
            {
                return -1;
            }

        }

        public static bool IsWithin(int value, int minimum, int maximum)
        {
            return value >= minimum && value <= maximum;
        }

        //find the longest substring that is a valid password
        public static int validPassword(string str)
        {
            List<int> strLength = new List<int>();
            if (!(str.All(Char.IsDigit)))
            {
                //string str = "a0Bb";
                string[] splitStrs = str.Split(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
               

                //check if each string contains a upper case
                foreach (string s in splitStrs)
                {
                    //Console.WriteLine(s);
                    if (s.Any(char.IsUpper) && s.Any(char.IsLower) || s.Any(char.IsUpper))
                    {
                        strLength.Add(s.Length);
                    }
                }

                if (strLength.Count == 0)
                {
                    return -1;
                }

                foreach (int i in strLength)
                {
                    //Console.WriteLine(i);

                }
                return strLength.Max();
            }
      
            else
            {
                return -1;
            }
           
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deleterq
{
    class Program
    {
        static void Main(string[] args)
        {

            //Drill
            //Write a C# program that prompts the user to input three integer values and find the greatest value of the three values.

            Console.WriteLine("Please enter 3 numbers seperated by commas or spaces:");
            var input = Console.ReadLine();

            //split the input string, convert to a list, convert each element to an int and then take the max of the resulting list.
            var maxNumber = input.Split(new[] { ' ', ',' }).ToList().ConvertAll(x => int.Parse(x)).Max();

            Console.WriteLine("The largest number you entered was: {0}", maxNumber);
            Console.ReadLine();
        }
    }
}

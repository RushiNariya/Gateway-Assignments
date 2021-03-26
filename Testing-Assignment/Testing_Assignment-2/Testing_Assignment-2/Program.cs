using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            //Case 1
            Console.WriteLine("UppartoLower : " + inputString.UppartoLower());

            //Case 2
            Console.WriteLine("TitleCase : " + inputString.TitleCase());

            //Case 3
            Console.WriteLine("Capitalized : " + inputString.Capitalized());

            //Case 4
            Console.WriteLine("CheckLower :" + inputString.CheckLower());

            //Case 5
            Console.WriteLine("CheckUppar : " + inputString.CheckUppar());

            //Case 6
            Console.WriteLine("CheckforInt : " + inputString.CheckforInt());

            //Case 7
            Console.WriteLine("RemoveLastChar : " + inputString.RemoveLastChar());

            //Case 8
            Console.WriteLine("WordCount : " + inputString.WordCount());

            //Case 9
            Console.WriteLine("inputString : " + inputString.StringToInt());

            Console.ReadLine();
        }
    }
}

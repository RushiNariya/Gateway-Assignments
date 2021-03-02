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
            string input = Console.ReadLine();
            string outputString;

            //Case 1
            outputString = ExtensionMethods.StringConvert(input, "UppartoLower");

            //Case 2
            outputString = ExtensionMethods.StringConvert(input, "TitleCase");

            //Case 3
            outputString = ExtensionMethods.StringConvert(input, "Capitalized");

            //Case 4
            outputString = ExtensionMethods.StringConvert(input, "CheckLower");

            //Case 5
            outputString = ExtensionMethods.StringConvert(input, "CheckUppar");

            //Case 6
            outputString = ExtensionMethods.StringConvert(input, "CheckforInt");

            //Case 7
            outputString = ExtensionMethods.StringConvert(input, "RemoveLastChar");

            //Case 8
            outputString = ExtensionMethods.StringConvert(input, "WordCount");

            //Case 9
            outputString = ExtensionMethods.StringConvert(input, "StringToInt");
        }
    }
}

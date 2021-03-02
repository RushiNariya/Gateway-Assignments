using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Assignment_2
{
    public class ExtensionMethods
    {
            public static string StringConvert(string inputString, string op)
            {
                string outputString = "";
                int asciiValue = 0;
                if (op.Equals("UppartoLower"))
                {
                    foreach (var ch in inputString)
                    {
                        asciiValue = (int)ch;
                        if (asciiValue >= 65 && asciiValue <= 90)
                            asciiValue += 32;
                        else if (asciiValue >= 97 && asciiValue <= 122)
                            asciiValue -= 32;
                        outputString += (char)asciiValue;
                    }
                    return outputString;
                }
                else if (op.Equals("TitleCase") || op.Equals("Capitalized"))
                {
                    TextInfo text = new CultureInfo("en-us", false).TextInfo;
                    return text.ToTitleCase(inputString);
                }

                else if (op.Equals("CheckLower"))
                {
                    foreach (var item in inputString)
                    {
                        asciiValue = (int)item;
                        bool status = false;
                        if (asciiValue >= 97 && asciiValue <= 122)
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                        if (status)
                        {
                            return "lowerCase";
                        }
                    }
                }
                else if (op.Equals("CheckUppar"))
                {
                    foreach (var item in inputString)
                    {
                        asciiValue = (int)item;
                        bool status = false;
                        if (asciiValue >= 65 && asciiValue <= 90)
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                        if (status)
                        {
                            return "upparCase";
                        }
                    }
                }
                else if (op.Equals("CheckforInt"))
                {
                    try
                    {
                        int x = int.Parse(inputString);
                        return "Success";
                    }
                    catch (Exception)
                    {

                        return "Failed";
                    }
                }
                else if (op.Equals("RemoveLastChar"))
                {
                    return inputString.Substring(0,inputString.Length - 1);
                }
                else if (op.Equals("WordCount"))
                {
                    return "" + inputString.Count();
                }
                else if (op.Equals("StringToInt"))
                {
                    try
                    {
                        return "" + int.Parse(inputString);
                    }
                    catch (Exception)
                    {

                        return "null";
                    }
                }
                return "";
            }
        }
    }
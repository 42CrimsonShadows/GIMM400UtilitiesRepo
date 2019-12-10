using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp1
{
    //Utilities*******************
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //C# string basics
            //https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/

            //use $ {variable} for writing variables in line with strings
            string firstFriend = "Maria";
            string secondFriend = "Sage";
            Console.WriteLine($"[My friends are {firstFriend} and {secondFriend}]");

            //use TrimStart() to remove proceeding spaces
            string greeting = "          WASSSSSUUPPPPPP!!            ";
            string trimmedGreeting = greeting.TrimStart();
            Console.WriteLine($"[{trimmedGreeting}]");

            //is TrimEnd() to remove trailing spaces
            trimmedGreeting = greeting.TrimEnd();
            Console.WriteLine($"[{trimmedGreeting}]");

            //use Trim() to remove proceeding and trailing spaces
            trimmedGreeting = greeting.Trim();
            Console.WriteLine($"[{trimmedGreeting}]");

            //replace a word in the string
            string sayHello = "Hello World";
            Console.WriteLine(sayHello);
            sayHello = sayHello.Replace("Hello", "Greetings");
            Console.WriteLine(sayHello);

            //uppercase and lowercase
            Console.WriteLine(sayHello.ToLower());
            Console.WriteLine(sayHello.ToUpper());

            //search for words in a string and return a true/false bool
            string songLyric = "You say goodbye, and I say hello";
            Console.WriteLine(songLyric.Contains("goodbye")); //true
            Console.WriteLine(songLyric.Contains("greetings")); //false
            Console.WriteLine(songLyric.StartsWith("You")); //true
            Console.WriteLine(songLyric.EndsWith("greetings")); //false

            //deviding and getting the remainder using % character "modulo"
            int a = 7;
            int b = 4;
            int c = 3;
            int d = (a + b) / c;
            int e = (a + b) % c;
            Console.WriteLine($"quotient {d}");     //3
            Console.WriteLine($"remainder {e}");    //2
            //or just use a double to get a demical point (range of double much greater than int)
            double a2 = 5;
            double b2 = 4;
            double c2 = 2;
            double d2 = (a2 + b2) / c2;
            Console.WriteLine($"{d2}");  //4.5

            //int type varables have a min and a max
            int intMax = int.MaxValue;
            int intMin = int.MinValue;
            Console.WriteLine($"The range of ints are min({intMin}) to max({intMax})");
            int what = intMax + 3;
            Console.WriteLine($"An example of overflow: {what}"); //wrapped around the max and add to the min value

            //decimal type variables have greater precision but smaller range
            decimal decMin = decimal.MinValue;
            decimal decMax = decimal.MaxValue;
            Console.WriteLine($"The range of decimals are min({decMin}) to max({decMax})");

            //beware of rounding errors with doubles
            double third = 1.0 / 3.0;
            Console.WriteLine($"{third}"); // 0.333333333 isn't truely the same as 1/3

            // while loop and do/while loop are the same
            int counter = 0;
            while (counter < 10)
            {
                Console.WriteLine($"The counter is now at {counter}");
                counter++;
            }
            do
            {
                Console.WriteLine($"The second counter is now at {counter}");
                counter++;
            }
            while (counter < 20);

            //for loop, "initializer" - "condition" - "itorater"
            for(int forCounter = 0; forCounter < 10; forCounter++)
            {
                Console.WriteLine($"The forCounter is now at {forCounter}");
            }

            //create a list of strings and print each string in the list
            var names = new List<string> { "Chris", "Anna", "Felipe" };
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
            //add and remove strings from the list
            Console.WriteLine();
            names.Add("Maria");
            names.Add("Bill");
            names.Remove("Chris");
            foreach (var name in names)
            {
                Console.WriteLine($"New names = {name.ToUpper()}!");
            }
            //reference the index of the name you want to output
            Console.WriteLine($"Output name[0] = {names[0]}");
            //get the amount of indexes
            Console.WriteLine($"Total amount of names in the list now is {names.Count}.");

            //find the index of the string you want in the list, if it is there (not 01))
            var index = names.IndexOf("Bill");
            if (index != -1)
            {
                Console.WriteLine($"The name {names[index]} is at index of {index}");
            }
            var notFound = names.IndexOf("BlankMan");
            Console.WriteLine($"When an item is not found, IndexOf returns {notFound}");

            //sort your list of strings in alphebetical order
            names.Sort();
            foreach(var poop in names)
            {
                Console.WriteLine($"Hello, {poop.ToUpper()}!"); //alphabet poop
            }

            //list fo numbers
            var fibonacciNumbers = new List<int> { 1, 1, 2, 3, 4};
            var previousNumber = fibonacciNumbers[fibonacciNumbers.Count - 1];
            var beforePreviousNumber = fibonacciNumbers[fibonacciNumbers.Count - 2];
            fibonacciNumbers.Add(previousNumber + beforePreviousNumber);
            //don't need bracketes for a loop if only doing one thing
            foreach (var shit in fibonacciNumbers)
                Console.WriteLine($"Fibonacci numbers {shit}.");

            //-----------------------------------------------------------------------------------
            Console.WriteLine("-------------------------------------------------------------------------"); 




            //Parsing string/number mixes to numbers
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number

            var str = "  10FFxxx";
            string numericString = String.Empty;
            foreach (var c3 in str)
            {
                // Check for numeric characters (hex in this case) or leading or trailing spaces.
                if ((c3 >= '0' && c3 <= '9') || (Char.ToUpperInvariant(c3) >= 'A' && Char.ToUpperInvariant(c3) <= 'F') || c3 == ' ')
                {
                    numericString = String.Concat(numericString, c3.ToString());
                }
                else
                {
                    break;
                }
            }
            if (int.TryParse(numericString, System.Globalization.NumberStyles.HexNumber, null, out int i2))
                Console.WriteLine($"'{str}' --> '{numericString}' --> {i2}"); // Output: '  10FFxxx' --> '  10FF' --> 4351


            str = "   -10FFXXX";
            numericString = "";
            foreach (char c4 in str)
            {
                // Check for numeric characters (0-9), a negative sign, or leading or trailing spaces.
                if ((c4 >= '0' && c4 <= '9') || c4 == ' ' || c4 == '-')
                {
                    numericString = String.Concat(numericString, c4);
                }
                else
                    break;
            }
            if (int.TryParse(numericString, out int j2))
                Console.WriteLine($"'{str}' --> '{numericString}' --> {j2}"); // Output: '   -10FFXXX' --> '   -10' --> -10

            //-----------------------------------------------------------------------------------
            Console.WriteLine("-------------------------------------------------------------------------"); 




            //Parsing strings to numbers
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number

            string input = String.Empty;
            try
            {
                int result = Int32.Parse(input); //can't parse an empty string into a number****************
                Console.WriteLine(result);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{input}'"); // Output: Unable to parse ''
            }     
            //---------
            try
            {
                int numVal = Int32.Parse("-105");
                Console.WriteLine(numVal); // Output: -105
            }
            catch (FormatException e2)
            {
                Console.WriteLine(e2.Message); 
            }
            //----------
            if (Int32.TryParse("-105", out int j))
                Console.WriteLine(j); // Output: -105
            else
                Console.WriteLine("String could not be parsed.");
           
            try
            {
                int m = Int32.Parse("abc"); //can't parse a string word into a number**************
            }
            catch (FormatException e2)
            {
                Console.WriteLine(e2.Message); // Output: Input string was not in a correct format.
            }
            
            string inputString = "abc";
            if (Int32.TryParse(inputString, out int numValue))
                Console.WriteLine(inputString);
            else
                Console.WriteLine($"Int32.TryParse could not parse '{inputString}' to an int."); // Output: Int32.TryParse could not parse 'abc' to an int.

            //-----------------------------------------------------------------------------------
            Console.WriteLine("-------------------------------------------------------------------------"); 





            //Parse Numeric Strings
            //https://docs.microsoft.com/en-us/dotnet/standard/base-types/parsing-numeric

            string[] values = { "1,304.16", "$1,456.78", "1,094", "152", "123,45 €", "1 304,16", "Ae9f" };

            double number;
            CultureInfo culture = null;

            foreach (string value in values)
            {
                try
                {
                    culture = CultureInfo.CreateSpecificCulture("en-US");
                    number = Double.Parse(value, culture);
                    Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number);
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0}: Unable to parse '{1}'.", culture.Name, value);
                    culture = CultureInfo.CreateSpecificCulture("fr-FR");
                    try
                    {
                        number = Double.Parse(value, culture);
                        Console.WriteLine("{0}: {1} --> {2}.", culture.Name, value, number);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("{0}: Unable to parse '{1}'.", culture.Name, value);
                    }
                }
                Console.WriteLine();
            }

            // The example displays the following output:
            //    en-US: 1,304.16 --> 1304.16
            //    
            //    en-US: Unable to parse '$1,456.78'.
            //    fr-FR: Unable to parse '$1,456.78'.
            //    
            //    en-US: 1,094 --> 1094
            //    
            //    en-US: 152 --> 152
            //    
            //    en-US: Unable to parse '123,45 €'.
            //    fr-FR: Unable to parse '123,45 €'.
            //    
            //    en-US: Unable to parse '1 304,16'.
            //    fr-FR: 1 304,16 --> 1304.16
            //    
            //    en-US: Unable to parse 'Ae9f'.
            //    fr-FR: Unable to parse 'Ae9f'.

            //-----------------------------------------------------------------------------------
            Console.WriteLine("-------------------------------------------------------------------------"); 





            //parsing number styles
            //https://docs.microsoft.com/en-us/dotnet/standard/base-types/parsing-numeric

            string myValue = "1,304";
            int myNumber;
            IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
            if (Int32.TryParse(myValue, out myNumber))
                Console.WriteLine("{0} --> {1}", myValue, myNumber);
            else
                Console.WriteLine("Unable to convert '{0}'", myValue);

            if (Int32.TryParse(myValue, NumberStyles.Integer | NumberStyles.AllowThousands,
                              provider, out myNumber))
                Console.WriteLine("{0} --> {1}", myValue, myNumber);
            else
                Console.WriteLine("Unable to convert '{0}'", myValue);

            // The example displays the following output:
            //       Unable to convert '1,304'
            //       1,304 --> 1304

            //-----------------------------------------------------------------------------------
            Console.WriteLine("-------------------------------------------------------------------------"); 





            //Parsing with Unicode Digits
            //https://docs.microsoft.com/en-us/dotnet/standard/base-types/parsing-numeric

            string uValue;
            // Define a string of basic Latin digits 1-5.
            uValue = "\u0031\u0032\u0033\u0034\u0035";
            ParseDigits(uValue);

            // Define a string of Fullwidth digits 1-5.
            uValue = "\uFF11\uFF12\uFF13\uFF14\uFF15";
            ParseDigits(uValue);

            // Define a string of Arabic-Indic digits 1-5.
            uValue = "\u0661\u0662\u0663\u0664\u0665";
            ParseDigits(uValue);

            // Define a string of Bangla digits 1-5.
            uValue = "\u09e7\u09e8\u09e9\u09ea\u09eb";
            ParseDigits(uValue);

            // The example displays the following output:
            //       '12345' --> 12345
            //       Unable to parse '１２３４５'.
            //       Unable to parse '١٢٣٤٥'.
            //       Unable to parse '১২৩৪৫'

            //-----------------------------------------------------------------------------------
            Console.WriteLine("-------------------------------------------------------------------------");

            //Parsing using Splits
            //https://docs.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split

            //splt phrase nto array of strings for each word
            char[] delimiterCharacters = { ' ', ',', '.', ':', '\t' };

            string phrase = "The quick brown fox jumps over the lazy dog.";
            Console.WriteLine($"Original phrase: '{phrase}'");
            string[] phraseWords = phrase.Split(delimiterCharacters);
            Console.WriteLine($"There are {phraseWords.Length} words in the phrase.");
            foreach (var word in phraseWords)
            {
                System.Console.WriteLine($"<{word}>"); //outputs each word at a time
            }

            string text = "one\ttwo three:four,five six seven";
            Console.WriteLine($"Original text: '{text}'");
            string[] textWords = text.Split(delimiterCharacters); //this splits the phrase using spaces into words
            Console.WriteLine($"There are {textWords.Length} words in the text.");

            foreach (var t in textWords)
            {
                System.Console.WriteLine($"<{t}>");
            }

            //can also use multiple characts instead of a simgle string character to act like a delimiter
            string[] separatingStrings = { "<<", "..." };
            string myText = "one<<two......three<four";
            Console.WriteLine($"Original text: '{myText}'");
            string[] mWords = myText.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);  //optional: StringSplitOptions.RemoveEmptyEntries gets rid of blank words
            Console.WriteLine($"{mWords.Length} substrings in text:");

            foreach (var word in mWords)
            {
                Console.WriteLine(word);
            }
        }

        static void ParseDigits(string uValue)
        {
            try
            {
                int number = Int32.Parse(uValue);
                Console.WriteLine("'{0}' --> {1}", uValue, number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse '{0}'.", uValue);
            }
        }
    }
}

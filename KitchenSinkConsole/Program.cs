using System;
using System.IO;
using System.Text;
using System.Threading;

namespace KitchenSinkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /*  2.2 Declaring variables
             *  Notes:
             *     Variables are containers that hold data.
             *
             *     C# is a strongly typed language, meaning you have to specify
             *     what kind of information a variable can hold.  At not time may you change
             *     the type, like you can say, in JavaScript.
             *
             *     There are two different syntaxes you can use:  explicit and implicit.
             *
             *     C# uses block scope.  More on this later.
             */

            //explicit typing:  You tell it what kind of data will be used
            string brandName = "Kohler";
            int onHandInventory = 10;
            float price = 234.56f;
            bool overnightDelivery = true;

            //    implicit typing:  .NET runtime guesses based on initial assignment (it's not always correct)
            var sinkFlowRate = 1.26f;  //here, it knows it's a float because of the hint

            /*    2.3  Casting and Out Variables
             *
             *    Every strongly typed language needs a way to convert between types when needed.
             *    For example, in an ASP.NET web project, data coming in from a RESTful call will always
             *    be a string, even if it needs to be a number.  So how do we convert the string "56" to
             *    the number 56?
             */

            var castOne = int.Parse("56");

            int castTwo; //note no assignment is made so var won't work here

            //    Parse is fine for well behaved inputs.  For badly behaving input, we need something
            //    more robust.

            var castTestOne = int.TryParse("42", out castTwo);  

            //    If "42" can be parsed as an integer (it can), castTestOne will be true
            //    and castTestTwo will be set to the converted value, 42.  Out variables allow
            //    you to take multiple values from methods like TryParse.
            //    If we had passed in "bad", which cannot be converted into an integer, castTestOne would
            //    be false and castTwo would have no value.

            /*    2.5  Everything is an object
             *
             *    C# is a fully object oriented language.  You really can't write code any other way.
             *    Below, "Console" is an object.  Objects have variables attached to them, as well as methods.
             *    More on this later.
             *
             *    C# uses dot syntax to split class or variable names from the properties and methods
             *    you're working with.
             */

            Console.WriteLine("The price of a sink made by " + brandName + " is " + price);

            /*   2.6  Working with Strings
             *
             *   A string is effectively a collection of letters, numbers, or characters.  If you
             *   can type it into a text file, it's a string.  C# strings are objects, like everything
             *   else.  There are dozens of useful properties and methods you can use to manipulate strings.
             *
             */

            var exampleCopy = "This code contains everything INCLUDING the kitchen sink!  ";
            Console.WriteLine(exampleCopy.ToUpper());
            Console.WriteLine(exampleCopy.ToLower());
            Console.WriteLine("The exampleCopy string is " + exampleCopy.Length + " characters long.");
            Console.WriteLine("Always cleanse and validate your data: " + exampleCopy.Trim());
            Console.WriteLine(exampleCopy.Replace("INCLUDING", "except"));

            /*   2.7  String Builders
             *
             *   If you need to generate a lot of copy, it is easier to use a string builder
             *   rather than concatenation.
             */

            var concat = "The price of a sink made by " + brandName + " is " + price;
            concat += ". Which is nice, but if you want a really long string separated by new lines...";
            concat += "\nYou're going to have to do some work which can be error prone.";

            var stringBuilder = new StringBuilder("The price of a sink made by " + brandName + " is " + price);
            stringBuilder.Append(". ");
            stringBuilder.Append("Which is even easier and cleaner with string builders.");
            stringBuilder.AppendLine("Here if you want a new line, just append it that way.");
            stringBuilder.AppendLine("Generally, this code is easier to understand and maintain.");

            /*  2.8  String Formatters
             *
             *  Another convenience feature in C# is a string formatter.
             *  Just about every language has these.  They are meant to take
             *  the tedium out of concatenation.
             *
             */

            var pricePerPound = 23.33m;
            var strPricePerPound = string.Format("The current price is {0:C2} per pound.", pricePerPound);
            Console.WriteLine(strPricePerPound);

            //you can do multiples, too.
            var timeAndTemperature = String.Format("At {0}, the temperature is {1}°F.",
                DateTime.Now, 20.4);
            Console.WriteLine(timeAndTemperature);

            /*  2.9  Interpolated & Verbatim Strings
             *
             *   Most languages have strings that feature escape characters.
             *   For example \n means "new line" and \t means "tab".  But sometimes
             *   you just want your strings to behave exactly how you type them.
             */

            var inventorName = "Jim Schmendrick";
            var rightNow = DateTime.Now;

            // There are two ways to use interpolated strings.
            // First, composite formatting
            Console.WriteLine("Did you know the kitchen sink was invented by {0}", inventorName);

            //  This looks the same as the string formatter example except that it
            //  lacks the string.formatter statement.

            //The other way is to use $ to put expressions directly in the code.
            Console.WriteLine($"It is currently {rightNow.DayOfWeek} and the current time is {rightNow:HH:mm}");
            var thisFile = new FileInfo(@"c:\temp\test.txt");

            //  If you find yourself want to to use $ and @ together, you can
            //  easily in C# 8, but in earlier version it had to be in a
            //  particular order.
            
            var triangleBase = 16;
            var triangleHeight = 32;
            var triangleArea = (triangleBase * triangleHeight) / 2;

            // Here, $ token appears before @ token 
            Console.WriteLine("Finding the area of a triangle:");
            Console.WriteLine($@"Height = ""{triangleHeight}"" and Base = ""{triangleBase}""");
            Console.WriteLine($@"Area = ""{triangleArea}""");

            //as of C# 8, the order no longer matters
            Console.WriteLine("Finding the area of a triangle AGAIN:");
            Console.WriteLine(@$"Height = ""{triangleHeight}"" and Base = ""{triangleBase}""");
            Console.WriteLine(@$"Area = ""{triangleArea}""");
        }
    }
}

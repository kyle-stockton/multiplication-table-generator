using System;
using System.Collections.Generic;
using System.Linq;

namespace StocktonKyle_CSharpCourseStep23p_Enumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Program title
            Console.Title = "Multiplication Table Generator";
            // stores user main menu selection
            char userInput;
            // array of acceptable user selections
            string options = "dce";
            // loops between menu and tables until user opts to exit
            do
            {
                // presents main menu until user enters valid selection
                do
                {
                    Console.Write(
                        "Select option - [d]efault, [c]ustom, [e]xit: ");
                    userInput = char.ToLower(Console.ReadKey().KeyChar);
                    Console.WriteLine("\n");
                } while (options.IndexOf(userInput) == -1);
                // interprets user input
                switch (userInput)
                {
                    // default table: all products up to 20x20
                    case ('d'):
                        MultiTable(Enumerable.Range(1, 20));
                        break;
                    // custom table: passes user-defined values
                    case ('c'):
                        MultiTable(CustomList());
                        break;
                }
            //program exit condition
            } while (userInput != 'e');
        }
        // creates custom list from user-provided values
        static List<int> CustomList()
        {
            Console.WriteLine(
                "Enter desired integers, seperated by spaces " +
                "(example:2 4 8 16):");
            string input = "1 " + Console.ReadLine();
            string[] values = input.Split(' ');
            List<int> returnValues = new List<int>();
            foreach (string value in values)
            {
                int i;
                if (int.TryParse(value, out i))
                    returnValues.Add(i);
                else Console.WriteLine(
                    "'{0}' was not a valid value.", value);
            }
            Console.WriteLine();
            return returnValues;
        }
        // creates multiplication table from supplied integer collection
        static void MultiTable(IEnumerable<int> numbers)
        {
            // stores column widths
            List<int> width = new List<int>();
            foreach (int value in numbers)
            {
                // column width is one more than length of largest value
                width.Add((value * numbers.Max()).ToString().Length + 1);
            }
            // create row for each value
            foreach (int x in numbers)
            {
                // initialize column width index
                int index = 0;
                // create column entry for each value
                foreach (int y in numbers)
                {
                    // access stored column width; set up next iteration
                    int columnWidth = width[index++];
                    // build format notation placeholder
                    string format = "{0," + columnWidth + "}";
                    // calculate product of given values
                    long product = x * y;
                    // display product in table; 1x1 unnecessary
                    Console.Write(format, 
                        product == 1 ? "" : product.ToString());
                }
                // after all columns created, start new row
                Console.WriteLine();
                // alternate text color for improved readability
                if (Console.ForegroundColor == ConsoleColor.Gray)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else Console.ForegroundColor = ConsoleColor.Gray; 
            }
            // reset text color and prompt user to return to main menu
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPress any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();

        }
    }
}


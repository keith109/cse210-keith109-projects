using System;

class Program
{
    static void Main(string[] args)
    {
        Reference MyRef = new Reference("John", 3, 16);
        Scripture MyScripture = new Scripture(MyRef, "For God so loved the world that he gave his one and only Son");

        string input = "";

        while (input.ToLower() != "quit" && !MyScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(MyScripture.GetDisplayText());
            Console.WriteLine("\nPress enter to hide words or type 'quit' to exit.");
            
            input = Console.ReadLine();

            if (input.ToLower() != "quit")
            {
                MyScripture.HideRandomWords(3);
            }
        }

        if (MyScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(MyScripture.GetDisplayText());
            Console.WriteLine("\nAll words are hidden. Goodbye!");
        }
    }
}
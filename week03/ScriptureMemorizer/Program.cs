using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        string scriptureText = "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life";

        Scripture scripture = new Scripture(reference, scriptureText);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            int remaining = scripture.GetVisibleWordCount();
            int total = scripture.GetTotalWordCount();
            Console.WriteLine($"\nProgress: {remaining} words remaining out of {total}");

            Console.WriteLine("\nPress Enter to continue more words, or type 'quit' to end.");

            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
            {
                Console.WriteLine("Goodbye! Keep memorizing.");
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words hidden! You've memorized it!");
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
                break;
            }
        }
    }
}
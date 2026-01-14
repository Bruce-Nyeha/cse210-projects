using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Journal Program ===");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Load journal from file");
            Console.WriteLine("4. Save journal to file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");

            string choice = Console.ReadLine().Trim();

            if (choice == "1")
            {
                string prompt = journal.GetRandomPrompt();
                Console.WriteLine("\n" + prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();
                Entry entry = new Entry(date, prompt, response);
                journal.AddEntry(entry);

                Console.WriteLine("Entry added!");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine().Trim();
                journal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine().Trim();
                journal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye! Keep journaling.");
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 1-5.");
            }
        }
    }
}
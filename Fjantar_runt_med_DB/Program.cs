namespace Fjantar_runt_med_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the database control.\n");

            UI.Menu.MenuChoices();
        }

        internal static void ApplicationShutdown()
        {
            // This method will be called when the game is closed
            // It will be used to save the game state, and do any other necessary cleanup

            Console.WriteLine("Hope you enjoyed your stay, welcome back any time.");
            Console.WriteLine("Press any key to shut down the application:");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}

using System;

namespace DesignPatternsCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManager configManager = ConfigurationManager.Instance;

            // Display the initial configuration
            Console.WriteLine("Initial Configuration:");
            configManager.DisplayConfiguration();

            // Modify the configuration
            configManager.AppName = "Advanced Design Patterns App";
            configManager.Version = "2.0";

            // Save the updated configuration
            configManager.SaveConfiguration();

            // Display the updated configuration
            Console.WriteLine("\nUpdated Configuration:");
            configManager.DisplayConfiguration();
        }
    }
}

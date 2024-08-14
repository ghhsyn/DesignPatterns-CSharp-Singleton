using System;
using System.IO;

namespace DesignPatternsCSharp
{
    // Singleton Class
    public sealed class ConfigurationManager
    {
        private static readonly ConfigurationManager _instance = new ConfigurationManager();
        private readonly string _configFilePath = "config.txt";

        private ConfigurationManager()
        {
            AppName = "Design Patterns App";
            Version = "1.0";
            LoadConfiguration();
        }

        public static ConfigurationManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public string AppName { get; private set; }
        public string Version { get; private set; }

        private void LoadConfiguration()
        {
            try
            {
                if (File.Exists(_configFilePath))
                {
                    string[] configLines = File.ReadAllLines(_configFilePath);
                    foreach (string line in configLines)
                    {
                        string[] keyValue = line.Split('=');
                        if (keyValue[0] == "AppName")
                        {
                            AppName = keyValue[1];
                        }
                        else if (keyValue[0] == "Version")
                        {
                            Version = keyValue[1];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Error loading configuration: {ex.Message}");
            }
        }

        public void SaveConfiguration()
        {
            try
            {
                File.WriteAllLines(_configFilePath, new[]
                {
                    $"AppName={AppName}",
                    $"Version={Version}"
                });
            }
            catch (Exception ex)
            {
                LogError($"Error saving configuration: {ex.Message}");
            }
        }

        public void LogError(string message)
        {
            Console.WriteLine($"[ERROR] {message}");
            // Alternatively, you could log to a file or another logging system.
        }

        public void DisplayConfiguration()
        {
            Console.WriteLine($"App Name: {AppName}");
            Console.WriteLine($"Version: {Version}");
        }
    }
}

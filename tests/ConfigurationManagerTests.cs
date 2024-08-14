using System;
using DesignPatternsCSharp;
using Xunit;

namespace DesignPatternsCSharp.Tests
{
    public class ConfigurationManagerTests
    {
        [Fact]
        public void SingletonInstance_ShouldReturnSameInstance()
        {
            // Arrange & Act
            ConfigurationManager instance1 = ConfigurationManager.Instance;
            ConfigurationManager instance2 = ConfigurationManager.Instance;

            // Assert
            Assert.Same(instance1, instance2);
        }

        [Fact]
        public void DefaultConfiguration_ShouldBeCorrect()
        {
            // Arrange
            ConfigurationManager configManager = ConfigurationManager.Instance;

            // Act
            string appName = configManager.AppName;
            string version = configManager.Version;

            // Assert
            Assert.Equal("Design Patterns App", appName);
            Assert.Equal("1.0", version);
        }

        [Fact]
        public void Configuration_ShouldBeSavedAndLoadedCorrectly()
        {
            // Arrange
            ConfigurationManager configManager = ConfigurationManager.Instance;
            configManager.AppName = "Test App";
            configManager.Version = "3.0";

            // Act
            configManager.SaveConfiguration();
            configManager.AppName = "Dummy";
            configManager.Version = "0.0";
            configManager.LoadConfiguration();

            // Assert
            Assert.Equal("Test App", configManager.AppName);
            Assert.Equal("3.0", configManager.Version);
        }
    }
}

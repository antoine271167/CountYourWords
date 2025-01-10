using FluentAssertions;
using Microsoft.Extensions.Hosting;

namespace CountYourWords.ConsoleApp.Tests;

public class DependencyTests
{
    [Test]
    public void DependencyTest()
    {
        // Arrange
        var builder = Host.CreateDefaultBuilder().ConfigureServices(Program.ConfigureServices);
        builder.UseDefaultServiceProvider((_, serviceProviderOptions) =>
        {
            serviceProviderOptions.ValidateScopes = true;
            serviceProviderOptions.ValidateOnBuild = true;
        });

        // Act
        var actual = () => builder.Build();

        // Assert
        actual.Should().NotThrow();
    }
}
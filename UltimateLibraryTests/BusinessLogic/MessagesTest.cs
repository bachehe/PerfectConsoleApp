using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using UltimateLibrary.BusinessLogic;
using UltimateLibrary.Interfaces;

namespace UltimateLibraryTests.BusinessLogic;

public class MessagesTest
{
    private readonly Messages _msg;
    private readonly Mock<IConsoleHelper> _mockHelper;
    private readonly Mock<ILogger<Messages>> _mockLogger;
    private readonly Mock<IInputReader> _mockInputReader;


    public MessagesTest()
    {
        _mockHelper = new Mock<IConsoleHelper>();
        _mockLogger = new Mock<ILogger<Messages>>();
        _mockInputReader = new Mock<IInputReader>();

        _msg = new Messages(_mockLogger.Object, _mockHelper.Object, _mockInputReader.Object);
    }

    [Fact]
    public void Greeting_ReturnsInvalidKey_WhenSelectedLanguageIsNullOrEmpty()
    {
        _mockInputReader.Setup(r => r.ReadLine()).Returns(string.Empty);
        var result = _msg.Greeting();

        Assert.Equal(_mockHelper.Object.InvalidKey, result);
    }

    [Theory]
    [InlineData("en", "Hello World")]
    [InlineData("es", "Hola Mundo")]
    public void Greetig_ForKey_ReturnCorrectTranslation(string key, string expected)
    {
        _mockInputReader.Setup(r => r.ReadLine()).Returns(key);
        var result = _msg.Greeting();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("test")]
    [InlineData(" ")]
    [InlineData("-1!%51.31/5")]
    public void IsValidString_ForInput_ShouldReturnTrue(string value)
    {
        Assert.True(_msg.IsValidString(value));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void IsValidString_ForInput_ShouldReturnFalse(string value)
    {
        Assert.False(_msg.IsValidString(value));
    }
}

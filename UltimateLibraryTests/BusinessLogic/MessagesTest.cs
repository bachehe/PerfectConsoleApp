using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using UltimateLibrary.BusinessLogic;
using UltimateLibrary.Interfaces;

namespace UltimateLibraryTests.BusinessLogic;

public class MessagesTest
{
    private Messages _msg;
    private readonly Mock<IConsoleHelper> _mockHelper;
    private readonly Mock<ILogger<Messages>> _mockLogger;

    public MessagesTest()
    {
        _mockHelper = new Mock<IConsoleHelper>();
        _mockLogger = new Mock<ILogger<Messages>>();
        _msg = new Messages(_mockLogger.Object, _mockHelper.Object);
    }
    public virtual string GetLanguageTranslation()
    {
        return "es";
    }

    [Theory]
    [InlineData("en", "Hello World")]
    [InlineData("es", "Hola Mundo")]
    public void Greetig_ForKey_ReturnCorrectTranslation(string key, string expected)
    {
        ILogger<Messages> logger = new NullLogger<Messages>();

        //Messages msgs = new(logger, _mockHelper.Object);
        Messages msgs =  _msg;


        var result = _msg.Greeting();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Greetig_IncorrectKey_ReturnHandlingException()
    {
        var key = "idontexist";
        var expected = "Sequence contains no elements";
        ILogger<Messages> logger = new NullLogger<Messages>();

        Messages msgs = new(logger, _mockHelper.Object);

        Assert.Throws<Exception>(
            () => msgs.Greeting());
    }
    [Theory]
    [InlineData("test")]
    [InlineData(" ")]
    [InlineData("-1!%51.31/5")]
    public void IsValidString_ForInput_ShouldReturnTrue(string value)
    {
        ILogger<Messages> logger = new NullLogger<Messages>();

        Messages msgs = new(logger, _mockHelper.Object);

        Assert.True(msgs.IsValidString(value));
    } 
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void IsValidString_ForInput_ShouldReturnFalse(string value)
    {
        ILogger<Messages> logger = new NullLogger<Messages>();

        Messages msgs = new(logger, _mockHelper.Object);

        Assert.False(msgs.IsValidString(value));
    }
}

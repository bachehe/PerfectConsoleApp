using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using UltimateLibrary.BusinessLogic;

namespace UltimateLibraryTests.BusinessLogic;

public class MessagesTest
{
    [Theory]
    [InlineData("en", "Hello World")]
    [InlineData("es", "Hola Mundo")]
    public void Greetig_ForKey_ReturnCorrectTranslation(string key, string expected)
    {
        ILogger<Messages> logger = new NullLogger<Messages>();

        Messages msgs = new(logger, null);

        var result = msgs.Greeting();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Greetig_IncorrectKey_ReturnHandlingException()
    {
        var key = "idontexist";
        var expected = "Sequence contains no elements";
        ILogger<Messages> logger = new NullLogger<Messages>();

        Messages msgs = new(logger, null);

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

        Messages msgs = new(logger, null);

        Assert.True(msgs.IsValidString(value));
    } 
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void IsValidString_ForInput_ShouldReturnFalse(string value)
    {
        ILogger<Messages> logger = new NullLogger<Messages>();

        Messages msgs = new(logger, null);

        Assert.False(msgs.IsValidString(value));
    }
}

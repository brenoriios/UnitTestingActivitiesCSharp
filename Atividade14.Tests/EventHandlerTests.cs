using NSubstitute;

namespace Atividade14.Tests;
public class EventHandlerTests
{
    private readonly IEmailService _emailService = Substitute.For<IEmailService>();
    private readonly EventHandler _sut;

    public EventHandlerTests()
    {
        _sut = new EventHandler(_emailService);
    }

    [Fact]
    public void HandleEvent_WithMessage_SendsEmail()
    {
        // Arrange
        string eventMessage = "An event has occurred";

        // Act
        _sut.HandleEvent(eventMessage);

        // Assert
        _emailService.Received(1).SendEmail("test@example.com", "Event Occurred", eventMessage);
    }
}

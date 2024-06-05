namespace Atividade14.Tests;

public class EmailServiceTests
{
    private EmailService _emailService;

    public EmailServiceTests()
    {
        _emailService = new EmailService();
    }

    [Fact]
    public void SendEmail_ShouldReturnSuccess()
    {
        try
        {
            _emailService.SendEmail("test@example.com", "Test Subject", "Test Body");
        }
        catch (Exception ex)
        {
            Assert.Fail("Expected no exception, but got: " + ex.Message);
        }
    }
}

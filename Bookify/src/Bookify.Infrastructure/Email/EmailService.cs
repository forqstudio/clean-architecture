using Bookify.Application.Abstractions.Email;
using Microsoft.Extensions.Logging;

namespace Bookify.Infrastructure.Email;

internal sealed class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }

    public  Task SendEmailAsync(Domain.Users.Email recipient, string subject, string body)
    {
        _logger.LogInformation("Sending email to {Recipient} with subject {Subject}", recipient, subject);
        return Task.CompletedTask;
    }
}

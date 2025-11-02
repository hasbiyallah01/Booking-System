using Booking_System.Core.Application.Interfaces.Services;
using Booking_System.Core.Entity.Models;
using Booking_System.Models;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using System.Net.Mail;

namespace Booking_System.Core.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IWebHostEnvironment _hostenv;
        private readonly EmailConfiguration _emailConfiguration;
        public EmailService(IWebHostEnvironment hostenv, IOptions<EmailConfiguration> emailConfiguration)
        {
            _hostenv = hostenv;
            _emailConfiguration = emailConfiguration.Value;
        }

        public async Task<bool> SendEmailAsync(MailReceiverRequest request, MailRequest mail)
        {
            try
            {
                Console.WriteLine("Calling email client");
                string buildContent = $"Dear {request.Name}," +
                                            $"<p>{mail.Body}</p>";

                if (string.IsNullOrWhiteSpace(mail.HtmlContent))
                {
                    throw new ArgumentNullException(nameof(mail.HtmlContent), "Email cannot be null or empty");
                }
                await SendEmailClient(mail.HtmlContent, mail.Title, request.Email);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("There was an error while sending email");
            }
        }

        public Task<string> SendEmailClient(string msg, string title, string email)
        {
            if (string.IsNullOrEmpty(msg))
            {
                Console.WriteLine("Error: Email message content is null or empty.");
                throw new ArgumentNullException(nameof(msg), "Email message content cannot be null or empty");
            }

            try
            {
                var emailAddress = MailboxAddress.Parse(email);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Email Address.");
                return Task.FromResult("Invalid Email");
            }

            var message = new MimeMessage();
            message.To.Add(MailboxAddress.Parse(email));
            message.From.Add(new MailboxAddress(_emailConfiguration.EmailSenderName, _emailConfiguration.EmailSenderAddress));
            message.Subject = title;

            message.Body = new TextPart("html")
            {
                Text = msg
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    Console.WriteLine("Inside email client");
                    client.Connect(_emailConfiguration.SMTPServerAddress, _emailConfiguration.SMTPServerPort, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfiguration.EmailSenderAddress, _emailConfiguration.EmailSenderPassword);
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred in email client: {ex.Message}", DateTime.UtcNow.ToLongTimeString());
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }

            return Task.FromResult("Email Sent");
        }

        public async Task<BaseResponse> SendEmailAsync(User user)
        {
            var mailRecieverRequestDto = new MailReceiverRequest
            {
                Email = user.Email,
                Name = user.FullName
            };

            string imageUrl = "";

            string emailBody = $@"";

            var mailRequest = new MailRequest
            {
                Body = emailBody,
                Title = "🎉 Welcome to Linnked! ❤️",
                HtmlContent = emailBody
            };

            await SendEmailAsync(mailRecieverRequestDto, mailRequest);

            return new BaseResponse
            {
                Message = "Welcome email sent successfully",
                IsSuccessful = true,
            };
        }
    }
}

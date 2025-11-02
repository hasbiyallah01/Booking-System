namespace Booking_System.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string HtmlContent { get; set; }
        public string Subject { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class MailReceiverRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

}

public class EmailSettings
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string DisplayName { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
}

interface IEmailService
{
    Task<string> SendEmailAsync(string ToEmailName, string Subject, EventModel Data);
    Task<string> SendEmailAsync(List<string> ToEmailNames, string Subject, EventModel Data);
    bool IsValidEmail(string EmailName);
}
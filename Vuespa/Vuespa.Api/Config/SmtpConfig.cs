namespace Vuespa.Api.Config;

public class SmtpConfig
{
    public string Host { get; set; } = null!;
    public int Port { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool UseSSL { get; set; }
}

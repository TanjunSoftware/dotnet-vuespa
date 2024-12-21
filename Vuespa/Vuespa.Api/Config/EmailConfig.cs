namespace Vuespa.Api.Config;

public class EmailConfig
{
    public static string Key { get; } = "Email";
    public string From { get; set; } = null!;
    public string ResetLink { get; set; } = null!;
    public SmtpConfig Smtp { get; set; } = null!;
}
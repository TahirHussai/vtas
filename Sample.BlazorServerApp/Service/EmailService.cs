using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.IO;

public static class EmailService
{
    public static void SendEmail(string toEmail, string userName, string title, string message)
    {
        string body = CreateEmailBody(userName, title, message);
        SendHtmlFormattedEmail("", body, toEmail);
    }

    private static string CreateEmailBody(string userName, string title, string message)
    {
        string body = LoadEmailTemplate();
        body = body.Replace("_UserName_", userName);
        body = body.Replace("_Title_", title);
        body = body.Replace("_Message_", message);
        return body;
    }

    private static string LoadEmailTemplate()
    {
        string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "SendEmail.html");

        if (File.Exists(templatePath))
        {
            return File.ReadAllText(templatePath);
        }
        else
        {
            throw new FileNotFoundException("Email template file not found.");
        }
    }

    private static void SendHtmlFormattedEmail(string subject, string body, string toEmail)
    {
        using (MailMessage mailMessage = new MailMessage())
        {
            try
            {
                mailMessage.From = new MailAddress(Configuration["Smtp:UserName"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(toEmail)); // Use the provided recipient's email address.

                SmtpClient smtp = new SmtpClient
                {
                    Host = Configuration["Smtp:Host"],
                    EnableSsl = Convert.ToBoolean(Configuration["Smtp:EnableSsl"]),
                    Credentials = new NetworkCredential(Configuration["Smtp:UserName"], Configuration["Smtp:Password"]),
                    Port = int.Parse(Configuration["Smtp:Port"])
                };

                smtp.Send(mailMessage);
            }
            catch (SmtpException ex)
            {
                // Handle SMTP-specific exceptions here.
                // You can log the exception details and take appropriate action.
            }
            catch (Exception ex)
            {
                // Handle other exceptions here.
                // You can log the exception details and take appropriate action.
            }
        }
    }


    private static IConfiguration Configuration => new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
}

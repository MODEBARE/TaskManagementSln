﻿using System.Net;
using System.Net.Mail;

public class EmailService
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _smtpUsername;
    private readonly string _smtpPassword;

    public EmailService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
    {
        _smtpServer = smtpServer;
        _smtpPort = smtpPort;
        _smtpUsername = smtpUsername;
        _smtpPassword = smtpPassword;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        using (var smtpClient = new SmtpClient(_smtpServer)
        {
            Port = _smtpPort,
            Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
            EnableSsl = true,
        })
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpUsername),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}

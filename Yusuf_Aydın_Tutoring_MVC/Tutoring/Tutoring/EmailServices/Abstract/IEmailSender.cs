﻿namespace Tutoring.EmailServices.Abstract
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string emailAdress, string subject, string emailBody);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DoroboShop.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }

        public void MySendCode()
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add("veremeychukden@gmail.com");
            mail.From = new MailAddress("veremeychukdenis2@gmail.com", "Email head", System.Text.Encoding.UTF8);
            mail.Subject = "This mail is send from asp.net application";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "This is Email Body Text";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("veremeychukdenis2@gmail.com", "AcVsMXKhw8nc1cc4");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);

            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
            }
        }
    }
}
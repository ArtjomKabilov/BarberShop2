using MimeKit;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace WebApplication1.Models
{
    public class Service
    {
        /*private readonly ILogger<Service> logger;

        public Service(ILogger<Service> logger)
        {
            this.logger = logger;
        }*/

        //System.Net.Mail.SmtpClient

        public async void SendEmailDefault(string aeg, string Kuupaev, string email)
        {
            
            try
            {
               
                MailMessage message = new MailMessage();
             
                message.IsBodyHtml = true; 
                message.From = new MailAddress("irina1223148@hotmail.com", "MetroBarber"); 
                message.To.Add(email +"irina1223148@hotmail.com"); //адресат сообщения
                message.Subject = "Сообщение от System.Net.Mail"; //тема сообщения
                message.Body = "<div style=\"color: black;\">Tere, täname, et kasutasite meie teenuseid, teie soeng on plaanitud " + Kuupaev +" в " + aeg + ". Soovime teile parimat päeva</div>";
                //message.Attachments.Add(new Attachment("... путь к файлу ...")); 

                var client = new SmtpClient("smtp.office365.com", 587)
                {
                    //Credentials = new NetworkCredential("16285c1bbabdd1", "f9122b3e2925fd"),
                    Credentials = new NetworkCredential("irina1223148@hotmail.com", "Amonra6657"),
                    EnableSsl = true
                };
                client.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               // logger.LogError(e.GetBaseException().Message);
            }
        }

        //MailKit.Net.Smtp.SmtpClient
        /* public void SendEmailCustom()
         {
             try
             {
                 MimeMessage message = new MimeMessage();
                 message.From.Add(new MailboxAddress("Моя компания", "admin@mycompany.com")); //отправитель сообщения
                 message.To.Add(new MailboxAddress("mail@yandex.ru")); //адресат сообщения
                 message.Subject = "Сообщение от MailKit"; //тема сообщения
                 message.Body = new BodyBuilder() { HtmlBody = "<div style=\"color: green;\">Сообщение от MailKit</div>" }.ToMessageBody(); //тело сообщения (так же в формате HTML)

                 using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                 {
                     client.Connect("smtp.gmail.com", 587, true); //либо использум порт 465
                     client.Authenticate("mail@gmail.com", "secret"); //логин-пароль от аккаунта
                     client.Send(message);

                     client.Disconnect(true);
                     logger.LogInformation("Сообщение отправлено успешно!");
                 }
             }
             catch (Exception e)
             {
                 logger.LogError(e.GetBaseException().Message);
             }
         }*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MailAddress from = new MailAddress("kupryashin.stepan@yandex.ru", "SK");
            MailAddress to = new MailAddress($"kupryashin.stepan@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Подтверждение почты";
            Console.WriteLine("Введите собщение: \n");
            m.Body = $"{Console.ReadLine()}<br/>Отправлено с лабы.";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
            smtp.Credentials = new NetworkCredential("kupryashin.stepan@yandex.ru", "пароль");
            smtp.EnableSsl = true;

            smtp.Send(m);
            Console.WriteLine("\nСообщение отправлено!");
            Console.ReadLine();
        }
    }
}

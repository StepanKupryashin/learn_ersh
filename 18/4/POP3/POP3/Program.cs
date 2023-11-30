using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenPop.Mime;
using OpenPop.Pop3;
using System.Text;
namespace POP3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pop3Client client = new Pop3Client();
            MessageModel message = new MessageModel();
            client.Connect("pop.yandex.ru", 995, true);
            client.Authenticate("kupryashin.stepan@yandex.ru", "nemeckiy228");

            try
            {
                for (int i = 1; i <= client.GetMessageCount(); i++)
                {
                    message = GetEmailContent(i, ref client);
                    if (message != null)
                    {
                        Console.WriteLine(message.FromName
                        + " " + message.Subject + "\n");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Больше писем нет");

                return;

            }
            Console.ReadKey();
        }
        public static MessageModel GetEmailContent(int intMessageNumber, ref Pop3Client client)
        {
            MessageModel message = new MessageModel();
            Message objMessage;
            MessagePart plainTextPart = null, HTMLTextPart = null;

            objMessage = client.GetMessage(intMessageNumber);

            message.MessageID = objMessage.Headers.MessageId == null ? "" : objMessage.Headers.MessageId.Trim();

            message.FromID = objMessage.Headers.From.Address.Trim();
            message.FromName = objMessage.Headers.From.DisplayName.Trim();
            message.Subject = objMessage.Headers.Subject.Trim();

            plainTextPart = objMessage.FindFirstPlainTextVersion();
            message.Body = (plainTextPart == null) ? "" : plainTextPart.GetBodyAsText().Trim();
            HTMLTextPart = objMessage.FindFirstHtmlVersion();

            return message;
        }
    }
}
class MessageModel
{
    public string MessageID;
    public string FromID;
    public string FromName;
    public string Subject;
    public string Body;
}


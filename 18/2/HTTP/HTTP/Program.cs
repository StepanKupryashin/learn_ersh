using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class HTTP
{
    static void Main(string[] args)
    {
        int port = 8080; // Указанный порт
        string directoryPath = "C:\\Users\\X_daydeneg_X\\Desktop\\learn_ersh\\18\\2\\Web\\"; // Путь к каталогу с файлами для сервера

        TcpListener listener = new TcpListener(IPAddress.Any, port);
        listener.Start();

        Console.WriteLine("HTTP-сервер запущен на порту " + port);

        while (true)
        {
            using (TcpClient client = listener.AcceptTcpClient())
            using (NetworkStream stream = client.GetStream())
            {
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                string[] requestData = request.Split(' ');
                string requestedFile = requestData[1].Trim('/');

                string filePath = Path.Combine(directoryPath, requestedFile);

                if (File.Exists(filePath))
                {
                    string contentType = "text/plain";
                    if (requestedFile.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || requestedFile.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    {
                        contentType = "image/jpeg";


                        byte[] fileData = File.ReadAllBytes(filePath);
                        string response = $"HTTP/1.1 200 OK\r\nContent-Type: {contentType}\r\nContent-Length: {fileData.Length}\r\n\r\n";

                        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                        stream.Write(responseBytes, 0, responseBytes.Length);
                        stream.Write(fileData, 0, fileData.Length);

                    }
                    if (requestedFile.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        StreamReader sr = new StreamReader(filePath);

                        string s = sr.ReadToEnd();

                        string response = $"HTTP/1.1 200 OK\r\nContent-Type: text/html\r\n\r\n<h1>{s}</h1>";

                        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                        stream.Write(responseBytes, 0, responseBytes.Length);

                    }
                }
                else
                    {
                    string notFoundResponse = "HTTP/1.1 404 Not Found\r\nContent-Type: text/html\r\n\r\n<h1>Message</h1>";
                    byte[] notFoundBytes = Encoding.UTF8.GetBytes(notFoundResponse);
                    stream.Write(notFoundBytes, 0, notFoundBytes.Length);
                }
            }
        }
    }
}

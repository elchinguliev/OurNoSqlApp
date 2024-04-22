using AzureStorageLibrary;
using AzureStorageLibrary.Services;
using System.Text;

namespace QueueConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetData();
            Console.ReadLine();
        }
        static async void GetData()
        {
            ConnectionStrings.AzureStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=strogestep;AccountKey=ahVeCB5/rQ//fqdGmxmq2Ywr6qXA4besLULuasYsBZ9nyGBuJg+hcafVZ4unVPfmGC1iHZuFSxGe+AStC+quFQ==;EndpointSuffix=core.windows.net";

            AzQueue queue = new AzQueue("testqueue");

            string base64message = Convert.ToBase64String(Encoding.UTF8.GetBytes("Salam Amin"));

            await queue.SendMessageAsync(base64message);

            //Console.WriteLine("Message Send Queue Successfuly");

            //var result = await queue.RetrieveMessageAsync();
            //var message = Encoding.UTF8.GetString(Convert.FromBase64String(result.MessageText));
            //Console.WriteLine(message);


            //await queue.DeleteMessage(result.MessageId, result.PopReceipt);
            //await Console.Out.WriteLineAsync("Message Delete");

        }
    }


}
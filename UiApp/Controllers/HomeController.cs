using AzureStorageLibrary;
using AzureStorageLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using UiApp.Models;
using UiApp.ViewModels;

namespace UiApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {

            ConnectionStrings.AzureStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=strogestep;AccountKey=ahVeCB5/rQ//fqdGmxmq2Ywr6qXA4besLULuasYsBZ9nyGBuJg+hcafVZ4unVPfmGC1iHZuFSxGe+AStC+quFQ==;EndpointSuffix=core.windows.net";
            AzQueue queue = new AzQueue("testqueue");


            var result = await queue.RetrieveMessageAsync();

            if (result != null)
            {
                var message = Encoding.UTF8.GetString(Convert.FromBase64String(result.MessageText));


                await queue.DeleteMessage(result.MessageId, result.PopReceipt);
                await Console.Out.WriteLineAsync("Message Delete");

                var vm = new MessageViewModel { Message = message };

                return View(vm);
            }

            return View(new MessageViewModel { });
        }
    }
}

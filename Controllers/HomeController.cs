using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet_newbie.Models;

using System.Net;
using Newtonsoft.Json;
using System.Text.Json;


namespace dotnet_newbie.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient client;
    public HomeController(ILogger<HomeController> logger, HttpClient client)
    {
        this.client = client;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<ActionResult> Privacy()
    {
        var url = "https://newsapi.org/v2/top-headlines?country=us&from=2024-01-11&apiKey=API_KEY_HERE";

        using (var request = new HttpRequestMessage(HttpMethod.Get, url))
        {
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                NewsResponse? newsResponse = JsonConvert.DeserializeObject<NewsResponse>(json);
                List<NewsArticle>? newsArticles = newsResponse?.Articles;
                Console.WriteLine(json);
                return View(newsArticles ?? new List<NewsArticle>());
            }
            else
            {
                // Handle error, e.g., display error message
                return View(new List<NewsArticle>());
            }
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

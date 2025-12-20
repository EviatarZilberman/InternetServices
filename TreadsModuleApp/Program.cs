using static System.Console;

static void CheckHttpStatus(string url)
{
    HttpClient client = new();
    var response = client.GetAsync(url).Result;
    WriteLine($"The HTTP status code of {url} is {response.StatusCode}");

}

List<string> urls = new(){
    "https://www.google.com/",
    "https://www.duckduckgo.com/",
    "https://www.yahoo.com/",
};

foreach (var url in urls)
{
    ThreadPool.QueueUserWorkItem((state) => CheckHttpStatus(url));
}


// wait for all thread to complete
// and press a key
Console.Read();
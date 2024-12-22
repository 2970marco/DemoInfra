using System.Diagnostics;
using System.Text.Json;
using DemoInfra;
using NUnit.Framework;

public class ApiDemoInfra
{
    public async Task<WeatherData[]> GetWebApi(string url)
    {
        Stopwatch stopwatch = new Stopwatch();
        using HttpClient client = new HttpClient();
        string responseString = string.Empty;
        WeatherData[] weatherArray;

        stopwatch.Start();
        client.BaseAddress = new Uri(url);
        Task<HttpResponseMessage> response = client.GetAsync(url);

        response.Wait();
        response.Result.EnsureSuccessStatusCode();
        responseString = await response.Result.Content.ReadAsStringAsync();

        stopwatch.Stop();
        weatherArray = JsonSerializer.Deserialize<WeatherData[]>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.That(weatherArray, Is.Not.Null);
        Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(3000));
        Assert.That(weatherArray.Length, Is.EqualTo(int.Parse(url.Split('/').Last())),"Mismatch");

        return weatherArray;
    }
}
namespace DemoInfra;

public class WeatherData
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF { get; set; }

    public string Summary { get; set; }
}

public class WeatherDataClass
{
    public int Id { get; set; }
    public string Status { get; set; }
    public string Method { get; set; }
    public List<WeatherData> Result { get; set; }
}
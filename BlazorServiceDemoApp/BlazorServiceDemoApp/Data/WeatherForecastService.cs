namespace BlazorServiceDemoApp.Data
{
  public class WeatherForecastService: IWeatherForecastService
  {
    private static int _instanceCount = 0;

    public WeatherForecastService()
    {
      _instanceCount++;
      Console.WriteLine("WeatherForecastService Instance Count: " + _instanceCount.ToString());
    }


    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
      Console.WriteLine("GetForecastAsync");
      return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = startDate.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
      }).ToArray());
    }
  }
}
﻿namespace BlazorServiceDemoApp.Data
{
  public interface IWeatherForecastService
  {
    Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
  }
}

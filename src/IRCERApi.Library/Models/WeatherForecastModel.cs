using System;
using System.Diagnostics.CodeAnalysis;

namespace IRCERApi.Library.Models
{
	[ExcludeFromCodeCoverage]
	public class WeatherForecastModel
	{
		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public int TemperatureF { get; set; }

		public string Summary { get; set; }
	}
}

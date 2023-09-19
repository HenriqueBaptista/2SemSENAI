namespace webapi.event_.tarde
{
    /// <summary>
    /// Class responsible for WheaterForecast object 
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Date
        /// </summary>
        public DateOnly Date { get; set; }


        /// <summary>
        /// Temperacture by Celcius
        /// </summary>
        public int TemperatureC { get; set; }


        /// <summary>
        /// Temperature by Farenheight
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);


        /// <summary>
        /// Sumary
        /// </summary>
        public string? Summary { get; set; }
    }
}
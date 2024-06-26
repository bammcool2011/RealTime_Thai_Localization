// IWeatherInfo.cs

namespace RealTime.Simulation
{
    /// <summary>
    /// An interface for a service that provides the game's weather information.
    /// </summary>
    internal interface IWeatherInfo
    {
        /// <summary>Gets a value indicating whether current weather conditions cause citizens not to stay outside.</summary>
        bool IsBadWeather { get; }
    }
}

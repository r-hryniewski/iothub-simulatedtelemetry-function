using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SimulatedTelemetryFunction
{
    public static class Thermometer
    {
        private static readonly string connectionString = Environment.GetEnvironmentVariable("DeviceEndpoint");
        private static readonly Random random = new Random();

        private static DeviceClient _deviceClient;
        private static DeviceClient deviceClient => _deviceClient ?? (_deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Mqtt));


        [FunctionName(nameof(Thermometer))]
        public static async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

                var temperature = new
                {
                    degrees = random.Next(10, 30)
                };

                var messageString = JsonConvert.SerializeObject(temperature);
                var message = new Message(Encoding.ASCII.GetBytes(messageString));

                message.Properties.Add("temperatureAlert", (temperature.degrees > 26) ? "true" : "false");

                await deviceClient.SendEventAsync(message);
            }
            catch (Exception e)
            {
                log.LogError(e, "Error occurred!");
            }
        }
    }
}

# iothub-simulatedtelemetry-function
Simple function to send simulated telemetry to IoT Hub

Simple Azure function to simulate thermometer device that sends random temperature readings to Azure IoT Hub every one minute.

Just fill in `DeviceEndpoint` setting in your Azure Function with your IoT Hub Device endpoint, publish this project and have fun.

Sample message in IoT Hub (retrieved in Stream Analytics) looks just like that:

```json
{
	"degrees":27,
	"EventProcessedUtcTime":"2018-12-24T20:12:23.2158015Z",
	"PartitionId":0,
	"EventEnqueuedUtcTime":"2018-12-24T20:11:00.2900000Z",
	"IoTHub":{
		"MessageId":null,
		"CorrelationId":null,
		"ConnectionDeviceId":"thermometer",
		"ConnectionDeviceGenerationId":"636812039420199009",
		"EnqueuedTime":"2018-12-24T20:11:00.3000000Z",
		"StreamId":null
		}
}
```

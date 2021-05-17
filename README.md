# MQTest
A simple desktop application to test connection to MQ **server**. This application will require you to include amqmdnetstd.dll to work properly.

You could change the method/transport property in file `AditMQHelper.cs`

```cs
connectionProperties.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
```

using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFServiceLayer.RabitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public async Task SendProductMessage<T>(T message)
        {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = await factory.CreateConnectionAsync();

            using var channel = await connection.CreateChannelAsync();

            //Here we create channel with session and model
           // using var channel = connection.CreateModel();

            //declare the queue after mentioning name and a few property related to that
            channel.QueueDeclareAsync("product", exclusive: false);

            //Serialize the message
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            //put the data on to the product queue
            channel.BasicPublishAsync(exchange: "", routingKey: "product", body: body);
        }
    }
}
